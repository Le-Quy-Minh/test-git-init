namespace Doctor
{
    partial class DoctorDashboardForm
    {
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTodayAppointments;
        private System.Windows.Forms.PictureBox picDoctor;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblNoAppointments;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.picDoctor = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTodayAppointments = new System.Windows.Forms.Label();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.lblNoAppointments = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDoctor)).BeginInit();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            
            // headerPanel
            this.headerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headerPanel.Controls.Add(this.btnLogout);
            this.headerPanel.Controls.Add(this.lblDate);
            this.headerPanel.Controls.Add(this.picDoctor);
            this.headerPanel.Controls.Add(this.lblWelcome);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(900, 140);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.BackColor = Color.FromArgb(52, 152, 219); // Soft blue
            
            // lblDate
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(650, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(180, 19);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            
            // picDoctor
            this.picDoctor.Location = new System.Drawing.Point(30, 30);
            this.picDoctor.Name = "picDoctor";
            this.picDoctor.Size = new System.Drawing.Size(80, 80);
            this.picDoctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDoctor.TabIndex = 1;
            this.picDoctor.TabStop = false;
            this.picDoctor.BackColor = Color.White;
            this.picDoctor.BorderStyle = BorderStyle.None;
            // Create a circular region for the picture box
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 80, 80);
            this.picDoctor.Region = new Region(path);
            
            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(120, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Dr. [Name]";
            
            // pnlCard (Main content card)
            this.pnlCard.Controls.Add(this.btnRefresh);
            this.pnlCard.Controls.Add(this.lblTodayAppointments);
            this.pnlCard.Controls.Add(this.dgvBookings);
            this.pnlCard.Controls.Add(this.lblNoAppointments);
            this.pnlCard.Location = new System.Drawing.Point(30, 160);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(840, 380);
            this.pnlCard.TabIndex = 1;
            this.pnlCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            
            // btnRefresh
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = Color.FromArgb(46, 204, 113);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(740, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // lblTodayAppointments
            this.lblTodayAppointments.AutoSize = true;
            this.lblTodayAppointments.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTodayAppointments.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTodayAppointments.Location = new System.Drawing.Point(20, 20);
            this.lblTodayAppointments.Name = "lblTodayAppointments";
            this.lblTodayAppointments.Size = new System.Drawing.Size(275, 25);
            this.lblTodayAppointments.TabIndex = 1;
            this.lblTodayAppointments.Text = "Today's Patient Appointments";
            
            // dgvBookings
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBookings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookings.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(236, 240, 241);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookings.EnableHeadersVisualStyles = false;
            this.dgvBookings.GridColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.dgvBookings.Location = new System.Drawing.Point(20, 60);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.RowHeadersWidth = 40;
            this.dgvBookings.RowTemplate.Height = 35;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(800, 300);
            this.dgvBookings.TabIndex = 0;
            this.dgvBookings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookings_CellClick);
            
            // lblNoAppointments
            this.lblNoAppointments.AutoSize = true;
            this.lblNoAppointments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblNoAppointments.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblNoAppointments.Location = new System.Drawing.Point(350, 180);
            this.lblNoAppointments.Name = "lblNoAppointments";
            this.lblNoAppointments.Size = new System.Drawing.Size(200, 21);
            this.lblNoAppointments.TabIndex = 3;
            this.lblNoAppointments.Text = "No appointments scheduled for today";
            this.lblNoAppointments.Visible = false;
            
            // footerPanel
            this.footerPanel.BackColor = Color.FromArgb(52, 152, 219);
            this.footerPanel.Controls.Add(this.lblFooter);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 560);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(900, 40);
            this.footerPanel.TabIndex = 2;
            
            // lblFooter
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(366, 13);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(168, 15);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "Hospital Management System";
            
            // btnLogout
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(790, 50);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            
            // DoctorDashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DoctorDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor Dashboard";
            this.Load += new System.EventHandler(this.DoctorDashboardForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDoctor)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}