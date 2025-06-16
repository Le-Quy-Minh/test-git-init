namespace Doctor
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        
        // Guna UI Components
        private Guna.UI2.WinForms.Guna2Elipse FormElipse;
        private Guna.UI2.WinForms.Guna2ShadowForm Shadow;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel sidePanel;
        private Guna.UI2.WinForms.Guna2PictureBox logoBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcome;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitle;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2ToggleSwitch togglePasswordVisibility;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblShowPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox sidePicture;
        private Guna.UI2.WinForms.Guna2Panel errorPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblErrorMessage;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator spinner;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private Guna.UI2.WinForms.Guna2Button btnCloseError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            
            // Form styling
            this.FormElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.FormElipse.BorderRadius = 15;
            this.FormElipse.TargetControl = this;
            
            // Shadow
            this.Shadow = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            
            // Drag Control
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.DragControl.DockIndicatorTransparencyValue = 0.6D;
            this.DragControl.TargetControl = this;
            this.DragControl.UseTransparentDrag = true;
            
            // NotifyIcon
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon.Text = "Hospital Management System";
            this.notifyIcon.Visible = true;
            
            // Main panels
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.sidePanel = new Guna.UI2.WinForms.Guna2Panel();
            
            // Control buttons
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            
            // Logo
            this.logoBox = new Guna.UI2.WinForms.Guna2PictureBox();
            
            // Side Image
            this.sidePicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            
            // Labels
            this.lblWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubtitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblShowPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            
            // TextBoxes
            this.txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            
            // Toggle
            this.togglePasswordVisibility = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            
            // Button
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            
            // Link Label
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            
            // Error Panel
            this.errorPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblErrorMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCloseError = new Guna.UI2.WinForms.Guna2Button();
            
            // Spinner
            this.spinner = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            
            // Configure Controls
            this.mainPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.errorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidePicture)).BeginInit();
            this.SuspendLayout();
            
            // mainPanel
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.spinner);
            this.mainPanel.Controls.Add(this.errorPanel);
            this.mainPanel.Controls.Add(this.linkForgotPassword);
            this.mainPanel.Controls.Add(this.btnLogin);
            this.mainPanel.Controls.Add(this.lblShowPassword);
            this.mainPanel.Controls.Add(this.togglePasswordVisibility);
            this.mainPanel.Controls.Add(this.txtPassword);
            this.mainPanel.Controls.Add(this.txtPhoneNumber);
            this.mainPanel.Controls.Add(this.lblSubtitle);
            this.mainPanel.Controls.Add(this.lblWelcome);
            this.mainPanel.Controls.Add(this.logoBox);
            this.mainPanel.Controls.Add(this.btnMinimize);
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainPanel.Location = new System.Drawing.Point(350, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(450, 550);
            
            // sidePanel
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.sidePanel.Controls.Add(this.sidePicture);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(350, 550);
            
            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnClose.HoverState.IconColor = System.Drawing.Color.White;
            this.btnClose.IconColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(410, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 28);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // btnMinimize
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconColor = System.Drawing.Color.Gray;
            this.btnMinimize.Location = new System.Drawing.Point(376, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 28);
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            
            // logoBox
            this.logoBox.ImageRotate = 0F;
            this.logoBox.Location = new System.Drawing.Point(180, 50);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(90, 90);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            
            // sidePicture
            this.sidePicture.ImageRotate = 0F;
            this.sidePicture.Location = new System.Drawing.Point(75, 150);
            this.sidePicture.Name = "sidePicture";
            this.sidePicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.sidePicture.Size = new System.Drawing.Size(200, 200);
            this.sidePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            
            // lblWelcome
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.lblWelcome.Location = new System.Drawing.Point(176, 150);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(153, 39);
            this.lblWelcome.Text = "Doctor Login";
            
            // lblSubtitle
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(130, 195);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(190, 19);
            this.lblSubtitle.Text = "Hospital Management System";
            
            // txtPhoneNumber
            this.txtPhoneNumber.BorderRadius = 8;
            this.txtPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneNumber.DefaultText = "";
            this.txtPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.txtPhoneNumber.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtPhoneNumber.IconLeftSize = new System.Drawing.Size(18, 18);
            this.txtPhoneNumber.Location = new System.Drawing.Point(75, 250);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.PasswordChar = '\0';
            this.txtPhoneNumber.PlaceholderText = "Enter your phone number";
            this.txtPhoneNumber.SelectedText = "";
            this.txtPhoneNumber.Size = new System.Drawing.Size(300, 45);
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            
            // txtPassword
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.txtPassword.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtPassword.IconLeftSize = new System.Drawing.Size(18, 18);
            this.txtPassword.Location = new System.Drawing.Point(75, 320);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Enter your password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(300, 45);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            
            // togglePasswordVisibility
            this.togglePasswordVisibility.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.togglePasswordVisibility.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.togglePasswordVisibility.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.togglePasswordVisibility.CheckedState.InnerColor = System.Drawing.Color.White;
            this.togglePasswordVisibility.Location = new System.Drawing.Point(75, 375);
            this.togglePasswordVisibility.Name = "togglePasswordVisibility";
            this.togglePasswordVisibility.Size = new System.Drawing.Size(35, 20);
            this.togglePasswordVisibility.TabIndex = 2;
            this.togglePasswordVisibility.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.togglePasswordVisibility.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.togglePasswordVisibility.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.togglePasswordVisibility.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.togglePasswordVisibility.CheckedChanged += new System.EventHandler(this.togglePasswordVisibility_CheckedChanged);
            
            // lblShowPassword
            this.lblShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblShowPassword.ForeColor = System.Drawing.Color.Gray;
            this.lblShowPassword.Location = new System.Drawing.Point(116, 375);
            this.lblShowPassword.Name = "lblShowPassword";
            this.lblShowPassword.Size = new System.Drawing.Size(84, 15);
            this.lblShowPassword.Text = "Show Password";
            
            // btnLogin
            this.btnLogin.BorderRadius = 8;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            this.btnLogin.Location = new System.Drawing.Point(75, 420);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 45);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            
            // linkForgotPassword
            this.linkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkForgotPassword.Location = new System.Drawing.Point(250, 375);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(125, 15);
            this.linkForgotPassword.TabIndex = 3;
            this.linkForgotPassword.Text = "Forgot Password?";
            this.linkForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            
            // errorPanel
            this.errorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.errorPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.errorPanel.BorderRadius = 8;
            this.errorPanel.BorderThickness = 1;
            this.errorPanel.Controls.Add(this.btnCloseError);
            this.errorPanel.Controls.Add(this.lblErrorMessage);
            this.errorPanel.Location = new System.Drawing.Point(75, 480);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(300, 40);
            this.errorPanel.Visible = false;
            
            // lblErrorMessage
            this.lblErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblErrorMessage.Location = new System.Drawing.Point(15, 12);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(76, 15);
            this.lblErrorMessage.Text = "Error Message";
            
            // btnCloseError
            this.btnCloseError.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseError.ImageSize = new System.Drawing.Size(16, 16);
            this.btnCloseError.Location = new System.Drawing.Point(270, 12);
            this.btnCloseError.Name = "btnCloseError";
            this.btnCloseError.Size = new System.Drawing.Size(20, 20);
            this.btnCloseError.Text = "";
            this.btnCloseError.Click += new System.EventHandler(this.btnCloseError_Click);
            
            // spinner
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(210, 430);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(30, 30);
            this.spinner.UseTransparentBackground = true;
            this.spinner.Visible = false;
            
            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management System - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidePicture)).EndInit();
            this.ResumeLayout(false);
        }
    }
}