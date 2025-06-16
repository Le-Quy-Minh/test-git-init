using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms;
using Serilog;
using Polly;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

namespace Doctor
{
    public partial class LoginForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HMSConnection"].ConnectionString;
        private static Dictionary<string, (int Attempts, DateTime LastAttempt)> loginAttempts = new();
        private const int MaxLoginAttempts = 5;
        private const int LockoutMinutes = 15;
        private const string IconPath = @"D:\C# learning\Doctor\Doctor\firefly_icon.ico";
        private const string LogoPath = @"D:\C# learning\Doctor\Doctor\logo.png";
        private const string SidePicturePath = @"D:\C# learning\Doctor\Doctor\sidePicture.png";

        private static class Constants
        {
            public const int ErrorPanelHideDelayMs = 5000;
            public const int FormCornerRadius = 15;
            public const string NotifyIconText = "Hospital Management System";
            public const string WelcomeMessage = "Welcome back, Dr. {0}!";
        }

        public LoginForm()
        {
            InitializeComponent();
            try
            {
                if (File.Exists(IconPath))
                {
                    this.Icon = new Icon(IconPath);
                    notifyIcon.Icon = new Icon(IconPath);
                    Console.WriteLine("Icon loaded successfully from " + IconPath);
                }
                else
                {
                    throw new FileNotFoundException($"Icon file not found at {IconPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting form icon: {ex.Message}");
                MessageBox.Show($"Failed to load icon: {ex.Message}", "Icon Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ApplyTextBoxPlaceholders();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Shadow.SetShadowForm(this);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, Constants.FormCornerRadius, Constants.FormCornerRadius));
            notifyIcon.Text = Constants.NotifyIconText;

            // Load images for logoBox and sidePicture
            try
            {
                if (File.Exists(LogoPath))
                {
                    logoBox.Image = Image.FromFile(LogoPath);
                    Console.WriteLine("Logo image loaded successfully from " + LogoPath);
                }
                else
                {
                    throw new FileNotFoundException($"Logo image not found at {LogoPath}");
                }

                if (File.Exists(SidePicturePath))
                {
                    sidePicture.Image = Image.FromFile(SidePicturePath);
                    Console.WriteLine("Side picture loaded successfully from " + SidePicturePath);
                }
                else
                {
                    throw new FileNotFoundException($"Side picture not found at {SidePicturePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading images: {ex.Message}");
                MessageBox.Show($"Failed to load images: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyTextBoxPlaceholders()
        {
            txtPhoneNumber.PlaceholderText = "Enter your phone number";
            txtPhoneNumber.PlaceholderForeColor = Color.Silver;
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.PlaceholderForeColor = Color.Silver;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text != txtPhoneNumber.PlaceholderText)
            {
                txtPhoneNumber.PlaceholderText = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPassword.PlaceholderText)
            {
                txtPassword.PlaceholderText = "";
            }
        }

        private void togglePasswordVisibility_CheckedChanged(object sender, EventArgs e)
        {
            if (togglePasswordVisibility.Checked)
            {
                // Show the password as plain text
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';  // No masking character
            }
            else
            {
                // Mask the password
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.PasswordChar = '●';  // Use bullet character for masking
            }
            // Force the control to redraw and reflect the changes
            txtPassword.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCloseError_Click(object sender, EventArgs e)
        {
            errorPanel.Visible = false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Please enter both phone number and password.");
                return;
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                ShowErrorMessage("Invalid phone number format.");
                return;
            }

            if (loginAttempts.TryGetValue(phoneNumber, out var attemptInfo) &&
                attemptInfo.Attempts >= MaxLoginAttempts &&
                DateTime.Now < attemptInfo.LastAttempt.AddMinutes(LockoutMinutes))
            {
                ShowErrorMessage($"Too many login attempts. Try again in {LockoutMinutes} minutes.");
                return;
            }

            spinner.Visible = true;
            btnLogin.Text = "Authenticating...";
            btnLogin.Enabled = false;

            await PerformAuthenticationAsync(phoneNumber, password);
        }

        private async Task PerformAuthenticationAsync(string phoneNumber, string password)
        {
            var retryPolicy = Policy
                .Handle<MySqlException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            await retryPolicy.ExecuteAsync(async () =>
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        await conn.OpenAsync();
                        string query = "SELECT fullname, password FROM doctor WHERE phone_number = @phoneNumber";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                            using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    string? storedHash = reader["password"]?.ToString();
                                    string? doctorName = reader["fullname"]?.ToString();

                                    if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(doctorName))
                                    {
                                        UpdateLoginAttempts(phoneNumber);
                                        ShowErrorMessage("Invalid user data.");
                                        return;
                                    }

                                    string inputHash = ComputeSha256Hash(password);
                                    if (inputHash == storedHash)
                                    {
                                        notifyIcon.BalloonTipTitle = "Login Successful";
                                        notifyIcon.BalloonTipText = string.Format(Constants.WelcomeMessage, doctorName);
                                        notifyIcon.ShowBalloonTip(3000);

                                        loginAttempts.Remove(phoneNumber);

                                        // Hide the LoginForm before showing the dashboard
                                        this.Hide();

                                        // Show the DoctorDashboardForm
                                        DoctorDashboardForm dashboard = new DoctorDashboardForm(phoneNumber, doctorName);
                                        dashboard.FormClosed += (s, args) => Application.Exit();
                                        dashboard.Show();
                                    }
                                    else
                                    {
                                        UpdateLoginAttempts(phoneNumber);
                                        ShowErrorMessage("Invalid phone number or password.");
                                    }
                                }
                                else
                                {
                                    UpdateLoginAttempts(phoneNumber);
                                    ShowErrorMessage("Invalid phone number or password.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Authentication failed for phone number {PhoneNumber}", phoneNumber);
                        ShowErrorMessage($"Database Error: {ex.Message}");
                    }
                    finally
                    {
                        spinner.Visible = false;
                        btnLogin.Text = "Login";
                        btnLogin.Enabled = true;
                    }
                }
            });
        }

        private void UpdateLoginAttempts(string phoneNumber)
        {
            if (loginAttempts.TryGetValue(phoneNumber, out var attempts))
            {
                loginAttempts[phoneNumber] = (attempts.Attempts + 1, DateTime.Now);
            }
            else
            {
                loginAttempts[phoneNumber] = (1, DateTime.Now);
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 10;
        }

        private void ShowErrorMessage(string message)
        {
            errorPanel.Visible = true;
            lblErrorMessage.Text = message;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = Constants.ErrorPanelHideDelayMs;
            timer.Tick += (s, e) =>
            {
                errorPanel.Visible = false;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

            spinner.Visible = false;
            btnLogin.Text = "Login";
            btnLogin.Enabled = true;
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Guna2MessageDialog msgDialog = new Guna2MessageDialog();
            msgDialog.Style = MessageDialogStyle.Light;
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Caption = "Password Recovery";
            msgDialog.Text = "Please contact your administrator to reset your password.";
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show();
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            notifyIcon.Dispose();
            base.OnFormClosing(e);
        }
    }
}