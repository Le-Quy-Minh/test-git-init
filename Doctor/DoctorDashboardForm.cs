using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Doctor
{
    public partial class DoctorDashboardForm : Form
    {
        private string connectionString = "server=172.19.105.74;user=onii;database=HMS;password=onii123@";
        private string phoneNumber;
        private string doctorName;

        public DoctorDashboardForm(string phoneNumber, string doctorName)
        {
            this.phoneNumber = phoneNumber;
            this.doctorName = doctorName;
            InitializeComponent();
            CustomizeButtonColumn();
            try
            {
                string iconPath = @"D:\C# learning\Doctor\Doctor\firefly_icon.ico";
                if (File.Exists(iconPath))
                {
                    this.Icon = new System.Drawing.Icon(iconPath);
                    Console.WriteLine("Icon loaded successfully.");
                }
                else
                {
                    throw new FileNotFoundException($"Icon file not found at {iconPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting form icon: {ex.Message}");
                MessageBox.Show($"Failed to load icon: {ex.Message}", "Icon Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoctorDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, Dr. {doctorName}";
            lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            LoadDoctorProfileImage();
            LoadPatientBookings();
            
            // Apply shadow effect to panels
            ApplyShadowEffect(pnlCard);
        }
        
        private void LoadDoctorProfileImage()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT image_profile FROM doctor WHERE phone_number = @phoneNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        object result = cmd.ExecuteScalar();
                        
                        if (result != null && result != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])result;
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                try
                                {
                                    Image img = Image.FromStream(ms);
                                    picDoctor.Image = img;
                                }
                                catch
                                {
                                    // If image can't be loaded, use default image
                                    picDoctor.Image = SystemIcons.Information.ToBitmap();
                                }
                            }
                        }
                        else
                        {
                            // No profile image found, use default
                            picDoctor.Image = SystemIcons.Information.ToBitmap();
                        }
                    }
                }
                catch (Exception)
                {
                    // If there's an error loading the image, use default
                    picDoctor.Image = SystemIcons.Information.ToBitmap();
                }
            }
        }

        private void ApplyShadowEffect(Panel panel)
        {
            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = Color.White;
            panel.Padding = new Padding(2);

            // Create a panel to simulate the shadow
            Panel shadowPanel = new Panel
            {
                BackColor = Color.FromArgb(200, 200, 200),
                Size = new Size(panel.Width + 4, panel.Height + 4),
                Location = new Point(panel.Location.X - 2, panel.Location.Y - 2),
                BorderStyle = BorderStyle.None
            };

            // Add the shadow panel to the form's controls and position it behind the target panel
            this.Controls.Add(shadowPanel);
            shadowPanel.SendToBack();
            panel.BringToFront();

            // Store the shadow panel in the Tag property for later use (e.g., resizing)
            panel.Tag = shadowPanel;
        }

        private void CustomizeButtonColumn()
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
            {
                Name = "Checkup",
                HeaderText = "Action",
                Text = "Checkup",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(39, 174, 96),
                    SelectionForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Padding = new Padding(10, 5, 10, 5)
                }
            };
            
            if (!dgvBookings.Columns.Contains("Checkup"))
            {
                dgvBookings.Columns.Add(btnColumn);
            }
        }

        private void LoadPatientBookings()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Step 1: Check if the doctor has any schedules at all
                    string checkScheduleQuery = @"
                        SELECT COUNT(*) 
                        FROM schedule s
                        JOIN doctor d ON s.doctor_id = d.id
                        WHERE d.phone_number = @phoneNumber";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkScheduleQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        long scheduleCount = (long)checkCmd.ExecuteScalar();

                        if (scheduleCount == 0)
                        {
                            using (var msgForm = new Form
                            {
                                Size = new Size(400, 200),
                                FormBorderStyle = FormBorderStyle.FixedDialog,
                                StartPosition = FormStartPosition.CenterParent,
                                MaximizeBox = false,
                                MinimizeBox = false,
                                Text = "Information",
                                BackColor = Color.White
                            })
                            {
                                var iconPic = new PictureBox
                                {
                                    Image = SystemIcons.Information.ToBitmap(),
                                    SizeMode = PictureBoxSizeMode.AutoSize,
                                    Location = new Point(20, 20)
                                };
                                
                                var messageLabel = new Label
                                {
                                    Text = $"Dr. {doctorName}, you have no schedules.",
                                    Font = new Font("Segoe UI", 10F),
                                    AutoSize = true,
                                    Location = new Point(80, 25)
                                };
                                
                                var okButton = new Button
                                {
                                    Text = "OK",
                                    Size = new Size(100, 35),
                                    Location = new Point(150, 120),
                                    BackColor = Color.FromArgb(46, 204, 113),
                                    ForeColor = Color.White,
                                    FlatStyle = FlatStyle.Flat
                                };
                                
                                okButton.Click += (s, args) => msgForm.Close();
                                
                                msgForm.Controls.Add(iconPic);
                                msgForm.Controls.Add(messageLabel);
                                msgForm.Controls.Add(okButton);
                                
                                msgForm.ShowDialog(this);
                            }
                        }
                    }

                    // Step 2: Load bookings for the current date
                    string query = @"
                        SELECT s.id, p.fullname AS PatientName, s.date, t.slot_label AS TimeSlot
                        FROM schedule s
                        JOIN patient p ON s.patient_id = p.id
                        JOIN time_slot t ON s.time_slot_id = t.id
                        JOIN doctor d ON s.doctor_id = d.id
                        WHERE d.phone_number = @phoneNumber 
                        AND DATE(s.date) = @currentDate
                        AND (LOWER(s.current_status) = 'not done' OR LOWER(s.current_status) = 'none')
                        AND s.is_booked = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@currentDate", DateTime.Today);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvBookings.DataSource = dt;

                        if (dt.Rows.Count > 0)
                        {
                            lblNoAppointments.Visible = false;
                            dgvBookings.Visible = true;
                            dgvBookings.Columns["id"].Visible = false;
                            dgvBookings.Columns["PatientName"].HeaderText = "Patient Name";
                            dgvBookings.Columns["date"].HeaderText = "Date";
                            dgvBookings.Columns["TimeSlot"].HeaderText = "Time Slot";
                            dgvBookings.Columns["date"].DefaultCellStyle.Format = "MMMM dd, yyyy";
                            dgvBookings.Columns["PatientName"].FillWeight = 40;
                            dgvBookings.Columns["date"].FillWeight = 30;
                            dgvBookings.Columns["TimeSlot"].FillWeight = 15;
                            dgvBookings.Columns["Checkup"].FillWeight = 15;
                        }
                        else
                        {
                            lblNoAppointments.Visible = true;
                            dgvBookings.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    using (var errorForm = new Form
                    {
                        Size = new Size(500, 300),
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        StartPosition = FormStartPosition.CenterParent,
                        MaximizeBox = false,
                        MinimizeBox = false,
                        Text = "Database Error",
                        BackColor = Color.White
                    })
                    {
                        var iconPic = new PictureBox
                        {
                            Image = SystemIcons.Error.ToBitmap(),
                            SizeMode = PictureBoxSizeMode.AutoSize,
                            Location = new Point(20, 20)
                        };
                        
                        var messageLabel = new Label
                        {
                            Text = $"Error: {ex.Message}",
                            Font = new Font("Segoe UI", 10F),
                            AutoSize = true,
                            Location = new Point(80, 25)
                        };
                        
                        var detailsTextBox = new TextBox
                        {
                            Multiline = true,
                            ReadOnly = true,
                            ScrollBars = ScrollBars.Vertical,
                            Text = ex.StackTrace,
                            Size = new Size(460, 120),
                            Location = new Point(20, 80),
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        
                        var okButton = new Button
                        {
                            Text = "OK",
                            Size = new Size(100, 35),
                            Location = new Point(200, 220),
                            BackColor = Color.FromArgb(231, 76, 60),
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat
                        };
                        
                        okButton.Click += (s, args) => errorForm.Close();
                        
                        errorForm.Controls.Add(iconPic);
                        errorForm.Controls.Add(messageLabel);
                        errorForm.Controls.Add(detailsTextBox);
                        errorForm.Controls.Add(okButton);
                        
                        errorForm.ShowDialog(this);
                    }
                }
            }
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBookings.Columns["Checkup"].Index)
            {
                int scheduleId = Convert.ToInt32(dgvBookings.Rows[e.RowIndex].Cells["id"].Value);
                string patientName = dgvBookings.Rows[e.RowIndex].Cells["PatientName"].Value.ToString();
                DateTime date = Convert.ToDateTime(dgvBookings.Rows[e.RowIndex].Cells["date"].Value);

                CheckupForm checkupForm = new CheckupForm(scheduleId, doctorName, patientName, date);
                checkupForm.ShowDialog();
                LoadPatientBookings();
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatientBookings();
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?", 
                "Confirm Logout",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );
            
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (picDoctor.Image != null)
            {
                picDoctor.Image.Dispose();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState == FormWindowState.Maximized)
            {
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                headerPanel.Height = (int)(screenHeight * 0.15);
                footerPanel.Height = (int)(screenHeight * 0.05);
                btnLogout.Left = this.Width - btnLogout.Width - 30;
                lblDate.Left = this.Width - lblDate.Width - btnLogout.Width - 40;
                dgvBookings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                // Adjust shadow effect on resize
                if (pnlCard.Tag != null)
                {
                    var shadow = (Panel)pnlCard.Tag; // Cast to Panel instead of Control
                    shadow.Size = new Size(pnlCard.Width + 4, pnlCard.Height + 4);
                    shadow.Location = new Point(pnlCard.Location.X - 2, pnlCard.Location.Y - 2);
                }
            }
        }
    }
}