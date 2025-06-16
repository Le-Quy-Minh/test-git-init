using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Doctor
{
    partial class CheckupForm
    {
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.TextBox txtMedicine;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnAddMedicine;
        private System.Windows.Forms.ListBox lstMedicines;
        private System.Windows.Forms.Button btnRemoveMedicine;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnToggleFullScreen;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMedicines;
        private System.Windows.Forms.GroupBox grpMedicines;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.ToolTip toolTip;
        
        // New modern components
        private Panel pnlMainContainer;
        private Panel pnlCardMedicines;
        private Panel pnlCardNotes;
        private Panel pnlMedicineInput;
        private Panel pnlGradientHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private PictureBox picHeaderIcon;
        private Panel pnlShadowTop;
        private Panel pnlShadowMedicines;
        private Panel pnlShadowNotes;
        private Panel pnlButtonContainer;

        private FormWindowState lastWindowState;
        private Size lastWindowSize;
        private Point lastWindowLocation;


        private void InitializeComponent()
        {
            this.toolTip = new System.Windows.Forms.ToolTip();
            
            // Initialize all components
            InitializeBasicComponents();
            InitializeModernComponents();
            InitializePanels();
            InitializeControls();
            InitializeForm();
            
            this.SuspendLayout();
            SetupLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeBasicComponents()
        {
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.txtMedicine = new System.Windows.Forms.TextBox();
            this.lblDosage = new System.Windows.Forms.Label();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnAddMedicine = new System.Windows.Forms.Button();
            this.lstMedicines = new System.Windows.Forms.ListBox();
            this.btnRemoveMedicine = new System.Windows.Forms.Button();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnToggleFullScreen = new System.Windows.Forms.Button();
        }

        private void InitializeModernComponents()
        {
            this.pnlMainContainer = new Panel();
            this.pnlGradientHeader = new Panel();
            this.pnlHeader = new Panel();
            this.pnlCardMedicines = new Panel();
            this.pnlMedicines = new Panel();
            this.pnlMedicineInput = new Panel();
            this.grpMedicines = new System.Windows.Forms.GroupBox();
            this.pnlCardNotes = new Panel();
            this.pnlNotes = new Panel();
            this.pnlFooter = new Panel();
            this.pnlButtonContainer = new Panel();
            this.lblHeaderTitle = new Label();
            this.lblHeaderSubtitle = new Label();
            this.picHeaderIcon = new PictureBox();
            this.pnlShadowTop = new Panel();
            this.pnlShadowMedicines = new Panel();
            this.pnlShadowNotes = new Panel();
        }

        private void InitializePanels()
        {
            // Main Container
            this.pnlMainContainer.Dock = DockStyle.Fill;
            this.pnlMainContainer.BackColor = Color.FromArgb(248, 249, 252);
            this.pnlMainContainer.Padding = new Padding(25);

            // Gradient Header Panel
            this.pnlGradientHeader.Dock = DockStyle.Top;
            this.pnlGradientHeader.Height = 200;
            this.pnlGradientHeader.Paint += PnlGradientHeader_Paint;

            // Header Panel (inside gradient)
            this.pnlHeader.Dock = DockStyle.Fill;
            this.pnlHeader.BackColor = Color.Transparent;
            this.pnlHeader.Padding = new Padding(30, 20, 30, 20);

            // Shadow panels for depth
            this.pnlShadowTop.Height = 6;
            this.pnlShadowTop.Dock = DockStyle.Top;
            this.pnlShadowTop.Paint += PnlShadow_Paint;

            this.pnlShadowMedicines.Height = 4;
            this.pnlShadowMedicines.Dock = DockStyle.Top;
            this.pnlShadowMedicines.Paint += PnlShadow_Paint;

            this.pnlShadowNotes.Height = 4;
            this.pnlShadowNotes.Dock = DockStyle.Top;
            this.pnlShadowNotes.Paint += PnlShadow_Paint;

            // Medicine Card Panel - Increased height
            this.pnlCardMedicines.Dock = DockStyle.Top;
            this.pnlCardMedicines.Height = 420; // Increased from 350
            this.pnlCardMedicines.BackColor = Color.Transparent;
            this.pnlCardMedicines.Padding = new Padding(0, 15, 0, 15);

            // Medicine Panel (inside card) - Organized with TableLayout
            this.pnlMedicines.Dock = DockStyle.Fill;
            this.pnlMedicines.BackColor = Color.White;
            this.pnlMedicines.Paint += PnlCard_Paint;
            this.pnlMedicines.Padding = new Padding(25);

            // Medicine Input Panel - Fixed height
            this.pnlMedicineInput.Dock = DockStyle.Top;
            this.pnlMedicineInput.Height = 100; // Reduced from 120
            this.pnlMedicineInput.BackColor = Color.Transparent;

            // Notes Card Panel
            this.pnlCardNotes.Dock = DockStyle.Top;
            this.pnlCardNotes.Height = 280; // Increased from 250
            this.pnlCardNotes.BackColor = Color.Transparent;
            this.pnlCardNotes.Padding = new Padding(0, 15, 0, 15);

            // Notes Panel (inside card)
            this.pnlNotes.Dock = DockStyle.Fill;
            this.pnlNotes.BackColor = Color.White;
            this.pnlNotes.Paint += PnlCard_Paint;
            this.pnlNotes.Padding = new Padding(25);

            // Footer Panel - Increased height
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Height = 120; // Increased from 100
            this.pnlFooter.BackColor = Color.Transparent;
            this.pnlFooter.Padding = new Padding(0, 20, 0, 20);

            // Button Container
            this.pnlButtonContainer.Dock = DockStyle.Fill;
            this.pnlButtonContainer.BackColor = Color.Transparent;
        }

        private void InitializeControls()
        {
            // ToolTip
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.BackColor = Color.FromArgb(45, 45, 48);
            this.toolTip.ForeColor = Color.White;

            // Header Icon
            this.picHeaderIcon.Size = new Size(48, 48);
            this.picHeaderIcon.Location = new Point(30, 30);
            this.picHeaderIcon.BackColor = Color.Transparent;
            this.picHeaderIcon.Paint += PicHeaderIcon_Paint;

            // Header Title
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = Color.White;
            this.lblHeaderTitle.BackColor = Color.Transparent;
            this.lblHeaderTitle.Location = new Point(90, 25);
            this.lblHeaderTitle.Text = "Patient Checkup";

            // Header Subtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new Font("Segoe UI", 11F);
            this.lblHeaderSubtitle.ForeColor = Color.FromArgb(220, 230, 255); // Fixed typo
            this.lblHeaderSubtitle.BackColor = Color.Transparent;
            this.lblHeaderSubtitle.Location = new Point(90, 62);
            this.lblHeaderSubtitle.Text = "Complete patient examination and prescription";

            // Toggle Full Screen Button
            this.btnToggleFullScreen.Size = new Size(140, 40);
            this.btnToggleFullScreen.BackColor = Color.FromArgb(255, 255, 255, 30);
            this.btnToggleFullScreen.FlatStyle = FlatStyle.Flat;
            this.btnToggleFullScreen.FlatAppearance.BorderSize = 1;
            this.btnToggleFullScreen.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255, 80);
            this.btnToggleFullScreen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnToggleFullScreen.ForeColor = Color.White;
            this.btnToggleFullScreen.Text = "⛶ Full Screen";
            this.btnToggleFullScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnToggleFullScreen.Click += new EventHandler(this.btnToggleFullScreen_Click);
            this.btnToggleFullScreen.Paint += BtnModern_Paint;
            this.toolTip.SetToolTip(this.btnToggleFullScreen, "Toggle full-screen mode");

            // Doctor, Patient, Date Labels
            SetupInfoLabels();

            // Medicine Input Controls
            SetupMedicineInputs();

            // Medicine List
            SetupMedicineList();

            // Notes
            SetupNotes();

            // Action Buttons
            SetupActionButtons();
        }

        private void SetupInfoLabels()
        {
            // Doctor Name
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblDoctorName.ForeColor = Color.White;
            this.lblDoctorName.BackColor = Color.Transparent;
            this.lblDoctorName.Location = new Point(30, 110);
            this.lblDoctorName.Text = "👨‍⚕️ Doctor: [Name]";

            // Patient Name
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblPatientName.ForeColor = Color.White;
            this.lblPatientName.BackColor = Color.Transparent;
            this.lblPatientName.Location = new Point(30, 140);
            this.lblPatientName.Text = "👤 Patient: [Name]";

            // Date
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblDate.ForeColor = Color.White;
            this.lblDate.BackColor = Color.Transparent;
            this.lblDate.Location = new Point(30, 170);
            this.lblDate.Text = "📅 Date: [Date]";
        }

        private void SetupMedicineInputs()
        {
            // Create TableLayoutPanel for organized input layout
            TableLayoutPanel tblMedicineInput = new TableLayoutPanel();
            tblMedicineInput.Dock = DockStyle.Fill;
            tblMedicineInput.ColumnCount = 4;
            tblMedicineInput.RowCount = 2;
            tblMedicineInput.BackColor = Color.Transparent;
            
            // Increase column widths for Medicine, Dosage, and Unit
            tblMedicineInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // Medicine (wider)
            tblMedicineInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Dosage (wider)
            tblMedicineInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F)); // Unit (wider)
            tblMedicineInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // Button (smaller to fit)

            tblMedicineInput.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Labels
            tblMedicineInput.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Controls

            // Medicine Label & TextBox
            this.lblMedicine.Text = "💊 Medicine Name";
            this.lblMedicine.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMedicine.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblMedicine.Anchor = AnchorStyles.Left;
            this.lblMedicine.Margin = new Padding(0, 0, 10, 5);
            this.lblMedicine.AutoSize = true;

            this.txtMedicine.Dock = DockStyle.Fill;
            this.txtMedicine.Height = 55;
            this.txtMedicine.Font = new Font("Segoe UI", 11F);
            this.txtMedicine.BorderStyle = BorderStyle.None;
            this.txtMedicine.BackColor = Color.FromArgb(200, 200, 200); // Darker gray
            this.txtMedicine.Margin = new Padding(0, 0, 10, 10);
            this.txtMedicine.Paint += TxtModern_Paint;
            this.toolTip.SetToolTip(this.txtMedicine, "💡 Type medicine name (supports autocomplete)");

            // Dosage Label & TextBox
            this.lblDosage.Text = "⚖️ Dosage";
            this.lblDosage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDosage.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblDosage.Anchor = AnchorStyles.Left;
            this.lblDosage.Margin = new Padding(0, 0, 10, 5);
            this.lblDosage.AutoSize = true;

            this.txtDosage.Dock = DockStyle.Fill;
            this.txtDosage.Height = 55;
            this.txtDosage.Font = new Font("Segoe UI", 11F);
            this.txtDosage.BorderStyle = BorderStyle.None;
            this.txtDosage.BackColor = Color.FromArgb(200, 200, 200); // Darker gray
            this.txtDosage.Margin = new Padding(0, 0, 10, 10);
            this.txtDosage.Paint += TxtModern_Paint;
            this.toolTip.SetToolTip(this.txtDosage, "💡 Enter dosage amount (e.g., 500)");

            // Unit Label & TextBox
            this.lblUnit.Text = "📏 Unit";
            this.lblUnit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblUnit.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblUnit.Anchor = AnchorStyles.Left;
            this.lblUnit.Margin = new Padding(0, 0, 10, 5);
            this.lblUnit.AutoSize = true;

            this.txtUnit.Dock = DockStyle.Fill;
            this.txtUnit.Height = 55;
            this.txtUnit.Font = new Font("Segoe UI", 11F);
            this.txtUnit.BorderStyle = BorderStyle.None;
            this.txtUnit.BackColor = Color.FromArgb(200, 200, 200); // Darker gray
            this.txtUnit.Margin = new Padding(0, 0, 10, 10);
            this.txtUnit.Paint += TxtModern_Paint;
            this.toolTip.SetToolTip(this.txtUnit, "💡 Select unit (mg, ml, tablet, etc.)");

            // Add Medicine Button (no changes here)
            this.btnAddMedicine.Dock = DockStyle.Fill;
            this.btnAddMedicine.Height = 40;
            this.btnAddMedicine.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAddMedicine.FlatStyle = FlatStyle.Flat;
            this.btnAddMedicine.FlatAppearance.BorderSize = 0;
            this.btnAddMedicine.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnAddMedicine.ForeColor = Color.White;
            this.btnAddMedicine.Text = "➕ Add";
            this.btnAddMedicine.UseVisualStyleBackColor = false;
            this.btnAddMedicine.Margin = new Padding(5, 0, 0, 10);
            this.btnAddMedicine.Click += new EventHandler(this.btnAddMedicine_Click);
            this.btnAddMedicine.MouseEnter += new EventHandler(this.btnAddMedicine_MouseEnter);
            this.btnAddMedicine.MouseLeave += new EventHandler(this.btnAddMedicine_MouseLeave);
            this.btnAddMedicine.Paint += BtnModern_Paint;
            this.toolTip.SetToolTip(this.btnAddMedicine, "Add medicine to prescription list");

            // Add controls to table layout
            tblMedicineInput.Controls.Add(this.lblMedicine, 0, 0);
            tblMedicineInput.Controls.Add(this.txtMedicine, 0, 1);
            tblMedicineInput.Controls.Add(this.lblDosage, 1, 0);
            tblMedicineInput.Controls.Add(this.txtDosage, 1, 1);
            tblMedicineInput.Controls.Add(this.lblUnit, 2, 0);
            tblMedicineInput.Controls.Add(this.txtUnit, 2, 1);
            tblMedicineInput.Controls.Add(this.btnAddMedicine, 3, 1);

            // Add table to panel
            this.pnlMedicineInput.Controls.Clear();
            this.pnlMedicineInput.Controls.Add(tblMedicineInput);
        }

        private TableLayoutPanel SetupMedicineList()
        {
            // Create TableLayoutPanel for list and button
            TableLayoutPanel tblMedicineList = new TableLayoutPanel();
            tblMedicineList.Dock = DockStyle.Fill;
            tblMedicineList.ColumnCount = 2;
            tblMedicineList.RowCount = 1;
            tblMedicineList.BackColor = Color.Transparent;
            tblMedicineList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78F));
            tblMedicineList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblMedicineList.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Medicine List
            this.lstMedicines.Dock = DockStyle.Fill;
            this.lstMedicines.Font = new Font("Segoe UI", 11F);
            this.lstMedicines.BackColor = Color.FromArgb(180, 180, 180);  // Darkened from (200, 200, 200)
            this.lstMedicines.ForeColor = Color.FromArgb(52, 73, 94);  // Text color unchanged for contrast
            this.lstMedicines.BorderStyle = BorderStyle.None;
            this.lstMedicines.ItemHeight = 32;
            this.lstMedicines.Margin = new Padding(0, 0, 15, 0);
            this.lstMedicines.Paint += LstModern_Paint;
            this.toolTip.SetToolTip(this.lstMedicines, "📋 Selected medicines with dosage information");

            // Remove Medicine Button
            this.btnRemoveMedicine.Dock = DockStyle.Top;
            this.btnRemoveMedicine.Height = 45;
            this.btnRemoveMedicine.BackColor = Color.FromArgb(231, 76, 60);
            this.btnRemoveMedicine.FlatStyle = FlatStyle.Flat;
            this.btnRemoveMedicine.FlatAppearance.BorderSize = 0;
            this.btnRemoveMedicine.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnRemoveMedicine.ForeColor = Color.White;
            this.btnRemoveMedicine.Text = "❌ Remove";
            this.btnRemoveMedicine.UseVisualStyleBackColor = false;
            this.btnRemoveMedicine.Margin = new Padding(0, 0, 0, 0);
            this.btnRemoveMedicine.Click += new EventHandler(this.btnRemoveMedicine_Click);
            this.btnRemoveMedicine.MouseEnter += new EventHandler(this.btnRemoveMedicine_MouseEnter);
            this.btnRemoveMedicine.MouseLeave += new EventHandler(this.btnRemoveMedicine_MouseLeave);
            this.btnRemoveMedicine.Paint += BtnModern_Paint;
            this.toolTip.SetToolTip(this.btnRemoveMedicine, "Remove selected medicine from list");

            // Add controls to table layout
            tblMedicineList.Controls.Add(this.lstMedicines, 0, 0);
            tblMedicineList.Controls.Add(this.btnRemoveMedicine, 1, 0);

            return tblMedicineList; // Return the table layout panel
        }

        private void SetupNotes()
        {
            // Notes Label
            this.lblNotes.Text = "📝 Additional Notes & Instructions";
            this.lblNotes.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblNotes.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblNotes.Location = new Point(0, 0);
            this.lblNotes.AutoSize = true;

            // Notes TextBox
            this.txtNotes.Location = new Point(0, 35);
            this.txtNotes.Size = new Size(900, 150); // Wider than before
            this.txtNotes.Font = new Font("Segoe UI", 11F);
            this.txtNotes.BackColor = Color.FromArgb(200, 200, 200); // Darker gray
            this.txtNotes.ForeColor = Color.FromArgb(52, 73, 94);
            this.txtNotes.BorderStyle = BorderStyle.None;
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = ScrollBars.Vertical;
            this.txtNotes.Paint += TxtModern_Paint;
            this.toolTip.SetToolTip(this.txtNotes, "💡 Enter additional medical notes or special instructions");
        }

        private void SetupActionButtons()
        {
            // Preview Button
            this.btnPreview.Size = new Size(200, 55);
            this.btnPreview.Location = new Point(150, 0);
            this.btnPreview.BackColor = Color.FromArgb(52, 152, 219);
            this.btnPreview.FlatStyle = FlatStyle.Flat;
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnPreview.ForeColor = Color.White;
            this.btnPreview.Text = "👁️ Preview PDF";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new EventHandler(this.btnPreview_Click);
            this.btnPreview.MouseEnter += new EventHandler(this.btnPreview_MouseEnter);
            this.btnPreview.MouseLeave += new EventHandler(this.btnPreview_MouseLeave);
            this.btnPreview.Paint += BtnModern_Paint;
            this.toolTip.SetToolTip(this.btnPreview, "Preview the prescription PDF before saving");

            // Finish Button
            this.btnFinish.Size = new Size(200, 55);
            this.btnFinish.Location = new Point(370, 0);
            this.btnFinish.BackColor = Color.FromArgb(46, 204, 113);
            this.btnFinish.FlatStyle = FlatStyle.Flat;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnFinish.ForeColor = Color.White;
            this.btnFinish.Text = "✅ Finish & Save";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new EventHandler(this.btnFinish_Click);
            this.btnFinish.MouseEnter += new EventHandler(this.btnFinish_MouseEnter);
            this.btnFinish.MouseLeave += new EventHandler(this.btnFinish_MouseLeave);
            this.btnFinish.Paint += BtnModern_Paint;
            this.toolTip.SetToolTip(this.btnFinish, "Complete checkup and save prescription");
        }

        private void InitializeForm()
        {
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi; // Better for different DPI settings
            this.BackColor = Color.FromArgb(248, 249, 252);
            this.ClientSize = new Size(1000, 900); // Increased height from 800 to 900
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new Size(800, 650); // Increased minimum height from 600 to 650
            this.Name = "CheckupForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Patient Checkup - Hospital Management System";
            this.Load += new EventHandler(this.CheckupForm_Load);
            this.Resize += new EventHandler(this.CheckupForm_Resize);
            
            // Enable double buffering for smoother painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint | 
                          ControlStyles.DoubleBuffer | 
                          ControlStyles.ResizeRedraw, true);
        }

        private void SetupLayout()
        {
            // Add controls to their respective containers
            this.pnlGradientHeader.Controls.Add(this.pnlHeader);
            this.pnlHeader.Controls.AddRange(new Control[] {
                this.picHeaderIcon, this.lblHeaderTitle, this.lblHeaderSubtitle,
                this.lblDoctorName, this.lblPatientName, this.lblDate, this.btnToggleFullScreen
            });

            // Create organized medicine section with TableLayoutPanel
            TableLayoutPanel tblMedicineSection = new TableLayoutPanel();
            tblMedicineSection.Dock = DockStyle.Fill;
            tblMedicineSection.RowCount = 3;
            tblMedicineSection.ColumnCount = 1;
            tblMedicineSection.BackColor = Color.Transparent;
            tblMedicineSection.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Input section
            tblMedicineSection.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F)); // Spacer
            tblMedicineSection.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // List section

            // Add medicine input panel
            tblMedicineSection.Controls.Add(this.pnlMedicineInput, 0, 0);

            // Add spacer panel
            Panel spacer = new Panel();
            spacer.BackColor = Color.Transparent;
            spacer.Dock = DockStyle.Fill;
            tblMedicineSection.Controls.Add(spacer, 0, 1);

            // Get the medicine list layout and add it
            TableLayoutPanel medicineListLayout = SetupMedicineList();
            tblMedicineSection.Controls.Add(medicineListLayout, 0, 2);

            // Add the organized section to medicine panel
            this.pnlMedicines.Controls.Clear();
            this.pnlMedicines.Controls.Add(tblMedicineSection);

            this.pnlCardMedicines.Controls.Add(this.pnlMedicines);

            this.pnlNotes.Controls.AddRange(new Control[] {
                this.lblNotes, this.txtNotes
            });

            this.pnlCardNotes.Controls.Add(this.pnlNotes);

            this.pnlButtonContainer.Controls.AddRange(new Control[] {
                this.btnPreview, this.btnFinish
            });

            this.pnlFooter.Controls.Add(this.pnlButtonContainer);

            this.pnlMainContainer.Controls.AddRange(new Control[] {
                this.pnlFooter, this.pnlCardNotes, this.pnlShadowNotes,
                this.pnlCardMedicines, this.pnlShadowMedicines, this.pnlShadowTop, this.pnlGradientHeader
            });

            this.Controls.Add(this.pnlMainContainer);
        }

        // Custom Paint Events
        private void PnlGradientHeader_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.pnlGradientHeader.ClientRectangle,
                Color.FromArgb(74, 144, 226),
                Color.FromArgb(52, 73, 94),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, this.pnlGradientHeader.ClientRectangle);
            }
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (GraphicsPath path = CreateRoundedRectangle(panel.ClientRectangle, 12))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(panel.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void PnlShadow_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, panel.Width, panel.Height),
                Color.FromArgb(30, 0, 0, 0),
                Color.Transparent,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        private void PicHeaderIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255, 40)))
            {
                e.Graphics.FillEllipse(brush, 0, 0, 48, 48);
            }
            using (Pen pen = new Pen(Color.White, 2))
            {
                e.Graphics.DrawEllipse(pen, 1, 1, 46, 46);
            }
            
            // Draw medical cross
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush, 20, 14, 8, 20);
                e.Graphics.FillRectangle(brush, 14, 20, 20, 8);
            }
        }

        private void BtnModern_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            using (GraphicsPath path = CreateRoundedRectangle(btn.ClientRectangle, 8))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(btn.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            // Draw the text
            string text = btn.Text;
            Font font = btn.Font;
            Brush textBrush = new SolidBrush(btn.ForeColor);
            SizeF textSize = e.Graphics.MeasureString(text, font);

            // Calculate text position based on TextAlign
            float x, y;
            switch (btn.TextAlign)
            {
                case ContentAlignment.TopLeft:
                    x = 0;
                    y = 0;
                    break;
                case ContentAlignment.TopCenter:
                    x = (btn.Width - textSize.Width) / 2;
                    y = 0;
                    break;
                case ContentAlignment.TopRight:
                    x = btn.Width - textSize.Width;
                    y = 0;
                    break;
                case ContentAlignment.MiddleLeft:
                    x = 0;
                    y = (btn.Height - textSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    x = (btn.Width - textSize.Width) / 2;
                    y = (btn.Height - textSize.Height) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    x = btn.Width - textSize.Width;
                    y = (btn.Height - textSize.Height) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    x = 0;
                    y = btn.Height - textSize.Height;
                    break;
                case ContentAlignment.BottomCenter:
                    x = (btn.Width - textSize.Width) / 2;
                    y = btn.Height - textSize.Height;
                    break;
                case ContentAlignment.BottomRight:
                    x = btn.Width - textSize.Width;
                    y = btn.Height - textSize.Height;
                    break;
                default:
                    x = (btn.Width - textSize.Width) / 2; // Default to MiddleCenter
                    y = (btn.Height - textSize.Height) / 2;
                    break;
            }

            e.Graphics.DrawString(text, font, textBrush, x, y);
        }

        private void TxtModern_Paint(object sender, PaintEventArgs e)
        {
            TextBox txt = sender as TextBox;
            using (GraphicsPath path = CreateRoundedRectangle(new Rectangle(0, 0, txt.Width, txt.Height), 6))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(txt.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void LstModern_Paint(object sender, PaintEventArgs e)
        {
            ListBox lst = sender as ListBox;
            using (GraphicsPath path = CreateRoundedRectangle(new Rectangle(0, 0, lst.Width, lst.Height), 6))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(lst.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
        // Helper method to create rounded rectangles
        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = cornerRadius * 2;
            
            // Top-left corner
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Top-right corner
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Bottom-right corner
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            // Bottom-left corner
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            
            path.CloseFigure();
            return path;
        }

        // Event Handlers
        private void CheckupForm_Load(object sender, EventArgs e)
        {
            // Store initial window state
            this.lastWindowState = this.WindowState;
            this.lastWindowSize = this.Size;
            this.lastWindowLocation = this.Location;
            
            // Set focus to first input
            this.txtMedicine.Focus();
            this.btnToggleFullScreen.Visible = false;
            
            // Initialize form data
            lblDoctorName.Text = $"👨‍⚕️ Doctor: {doctorName}";
            lblPatientName.Text = $"👤 Patient: {patientName}";
            lblDate.Text = $"📅 Date: {date:MMM dd, yyyy}";
            lblHeaderSubtitle.Text = $"Complete patient examination and prescription - {DateTime.Now:MMM dd, yyyy HH:mm}";
            
            LoadMedicineSuggestions();
            LoadUnitSuggestions();

            Console.WriteLine($"CheckupForm_Load - lblDoctorName.Text: {lblDoctorName.Text}");
            Console.WriteLine($"CheckupForm_Load - lblPatientName.Text: {lblPatientName.Text}");
            Console.WriteLine($"CheckupForm_Load - lblDate.Text: {lblDate.Text}");
            Console.WriteLine($"CheckupForm_Load - txtNotes: {(txtNotes != null ? txtNotes.Text : "null")}");
        }

        private void CheckupForm_Resize(object sender, EventArgs e)
        {
            // Handle responsive layout adjustments
            AdjustLayoutForSize();
        }

        private void btnToggleFullScreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Exit full screen
                this.WindowState = this.lastWindowState;
                this.Size = this.lastWindowSize;
                this.Location = this.lastWindowLocation;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.btnToggleFullScreen.Text = "⛶ Full Screen";
                this.toolTip.SetToolTip(this.btnToggleFullScreen, "Enter full-screen mode");
            }
            else
            {
                // Store current state
                this.lastWindowState = this.WindowState;
                this.lastWindowSize = this.Size;
                this.lastWindowLocation = this.Location;
                
                // Enter full screen
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.btnToggleFullScreen.Text = "🗗 Exit Full Screen";
                this.toolTip.SetToolTip(this.btnToggleFullScreen, "Exit full-screen mode");
            }
        }

        // Button hover effects
        private void btnAddMedicine_MouseEnter(object sender, EventArgs e)
        {
            this.btnAddMedicine.BackColor = Color.FromArgb(34, 139, 34);
            this.Cursor = Cursors.Hand;
        }

        private void btnAddMedicine_MouseLeave(object sender, EventArgs e)
        {
            this.btnAddMedicine.BackColor = Color.FromArgb(40, 167, 69);
            this.Cursor = Cursors.Default;
        }

        private void btnRemoveMedicine_MouseEnter(object sender, EventArgs e)
        {
            this.btnRemoveMedicine.BackColor = Color.FromArgb(192, 0, 0);
            this.Cursor = Cursors.Hand;
        }

        private void btnRemoveMedicine_MouseLeave(object sender, EventArgs e)
        {
            this.btnRemoveMedicine.BackColor = Color.FromArgb(220, 53, 69);
            this.Cursor = Cursors.Default;
        }

        private void btnPreview_MouseEnter(object sender, EventArgs e)
        {
            this.btnPreview.BackColor = Color.FromArgb(255, 165, 0);
            this.Cursor = Cursors.Hand;
        }

        private void btnPreview_MouseLeave(object sender, EventArgs e)
        {
            this.btnPreview.BackColor = Color.FromArgb(255, 193, 7);
            this.Cursor = Cursors.Default;
        }

        private void btnFinish_MouseEnter(object sender, EventArgs e)
        {
            this.btnFinish.BackColor = Color.FromArgb(34, 139, 34);
            this.Cursor = Cursors.Hand;
        }

        private void btnFinish_MouseLeave(object sender, EventArgs e)
        {
            this.btnFinish.BackColor = Color.FromArgb(40, 167, 69);
            this.Cursor = Cursors.Default;
        }

        // Medicine management methods
        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            if (ValidateMedicineInput())
            {
                string medicine = txtMedicine.Text.Trim();
                string dosage = txtDosage.Text.Trim();
                string unit = txtUnit.Text.Trim();

                Console.WriteLine($"btnAddMedicine_Click - Medicine: {medicine ?? "null"}, Dosage: {dosage ?? "null"}, Unit: {unit ?? "null"}");

                if (!string.IsNullOrEmpty(medicine) && !string.IsNullOrEmpty(dosage) && !string.IsNullOrEmpty(unit))
                {
                    var medicineInfo = new MedicineInfo(medicine, dosage, unit);
                    if (!selectedMedicines.Exists(m => m.Name == medicine && m.Dosage == dosage && m.Unit == unit))
                    {
                        selectedMedicines.Add(medicineInfo);
                        lstMedicines.Items.Add(medicineInfo);
                        txtMedicine.Clear();
                        txtDosage.Clear();
                        txtUnit.Clear();
                        txtMedicine.Focus();
                        Console.WriteLine($"btnAddMedicine_Click - Medicine added: {medicineInfo}, Total medicines: {selectedMedicines.Count}");
                        ShowTemporaryMessage("Medicine added successfully!", Color.FromArgb(46, 204, 113));
                    }
                    else
                    {
                        Console.WriteLine("btnAddMedicine_Click - Medicine not added: Duplicate entry");
                        ShowTemporaryMessage("Medicine already exists in the list.", Color.FromArgb(243, 156, 18));
                    }
                }
                else
                {
                    ShowTemporaryMessage("Please fill in all fields: Medicine Name, Dosage, and Unit.", Color.FromArgb(231, 76, 60));
                    Console.WriteLine("btnAddMedicine_Click - Medicine not added: Missing fields");
                }
            }
        }

        private void btnRemoveMedicine_Click(object sender, EventArgs e)
        {
            if (lstMedicines.SelectedItem != null)
            {
                var medicineInfo = lstMedicines.SelectedItem as MedicineInfo;
                selectedMedicines.Remove(medicineInfo);
                lstMedicines.Items.Remove(medicineInfo);
                Console.WriteLine($"btnRemoveMedicine_Click - Medicine removed: {medicineInfo}, Total medicines: {selectedMedicines.Count}");
                ShowTemporaryMessage("Medicine removed successfully!", Color.FromArgb(231, 76, 60));
            }
            else
            {
                ShowTemporaryMessage("Please select a medicine to remove.", Color.FromArgb(243, 156, 18));
            }
        }

        // Form action methods
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Console.WriteLine($"btnPreview_Click - Doctor Name: {doctorName ?? "null"}");
                Console.WriteLine($"btnPreview_Click - Patient Name: {patientName ?? "null"}");
                Console.WriteLine($"btnPreview_Click - Medicines: {(selectedMedicines != null ? string.Join(", ", selectedMedicines) : "null")}");
                Console.WriteLine($"btnPreview_Click - Notes: {(txtNotes != null ? txtNotes.Text : "null")}");

                try
                {
                    GeneratePDF(true);
                    ShowTemporaryMessage("PDF preview opened successfully!", Color.FromArgb(52, 152, 219));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error previewing PDF: {ex.Message}", "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowTemporaryMessage("Failed to preview PDF.", Color.FromArgb(231, 76, 60));
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string notes = txtNotes != null ? txtNotes.Text.Trim() : string.Empty;

                if (selectedMedicines.Count == 0)
                {
                    MessageBox.Show("Please add at least one medicine to the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ShowTemporaryMessage("Please add at least one medicine.", Color.FromArgb(231, 76, 60));
                    return;
                }

                string connectionString = "server=172.19.105.74;user=onii;database=HMS;password=onii123@";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE schedule SET current_status = 'Done', notes = @notes WHERE id = @scheduleId";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@notes", notes);
                            cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ShowTemporaryMessage("Failed to update schedule.", Color.FromArgb(231, 76, 60));
                        return;
                    }
                }

                try
                {
                    string pdfPath = GeneratePDF(false);
                    
                    if (SavePrescriptionToDatabase(pdfPath))
                    {
                        MessageBox.Show($"Checkup completed. PDF saved to database and locally at {pdfPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowTemporaryMessage("Checkup completed and saved successfully!", Color.FromArgb(46, 204, 113));
                    }
                    else
                    {
                        MessageBox.Show($"Checkup completed. PDF saved locally at {pdfPath}, but failed to save to database.", "Partial Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ShowTemporaryMessage("Failed to save to database.", Color.FromArgb(231, 76, 60));
                    }
                    
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating PDF: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowTemporaryMessage("Failed to generate PDF.", Color.FromArgb(231, 76, 60));
                }
            }
        }

        // Validation methods
        private bool ValidateMedicineInput()
        {
            if (string.IsNullOrWhiteSpace(txtMedicine.Text))
            {
                ShowTemporaryMessage("Please enter medicine name.", Color.FromArgb(231, 76, 60));
                txtMedicine.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDosage.Text))
            {
                ShowTemporaryMessage("Please enter dosage amount.", Color.FromArgb(231, 76, 60));
                txtDosage.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                ShowTemporaryMessage("Please enter dosage unit.", Color.FromArgb(231, 76, 60));
                txtUnit.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateForm()
        {
            if (lstMedicines.Items.Count == 0)
            {
                ShowTemporaryMessage("Please add at least one medicine to the prescription.", Color.FromArgb(231, 76, 60));
                txtMedicine.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNotes.Text))
            {
                var result = MessageBox.Show(
                    "No additional notes have been added. Do you want to continue?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.No)
                {
                    txtNotes.Focus();
                    return false;
                }
            }

            return true;
        }

        // Helper methods
        // private void InitializeFormData()
        // {
        //     // Set default values - these would typically come from the calling form
        //     lblDoctorName.Text = "👨‍⚕️ Doctor: Dr. [Doctor Name]";
        //     lblPatientName.Text = "👤 Patient: [Patient Name]";
        //     lblDate.Text = $"📅 Date: {DateTime.Now:MMM dd, yyyy}";
            
        //     // Update header subtitle with current date/time
        //     lblHeaderSubtitle.Text = $"Complete patient examination and prescription - {DateTime.Now:MMM dd, yyyy HH:mm}";
        // }

        private void AdjustLayoutForSize()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            
            // Adjust padding and spacing based on screen size
            if (formWidth < 900)
            {
                // Small screen adjustments
                pnlMainContainer.Padding = new Padding(10);
                pnlHeader.Padding = new Padding(15, 10, 15, 10);
                pnlMedicines.Padding = new Padding(15);
                pnlNotes.Padding = new Padding(15);
                
                // Adjust header height for small screens
                pnlGradientHeader.Height = 180;
                
                // Adjust card heights for small screens
                pnlCardMedicines.Height = Math.Min(380, formHeight * 45 / 100);
                pnlCardNotes.Height = Math.Min(250, formHeight * 30 / 100);
                
                // Stack buttons vertically on very small screens
                if (formWidth < 700)
                {
                    pnlFooter.Height = 140;
                    pnlButtonContainer.Height = 100;
                    btnPreview.Size = new Size(Math.Min(250, formWidth - 60), 45);
                    btnFinish.Size = new Size(Math.Min(250, formWidth - 60), 45);
                    
                    int btnX = (pnlButtonContainer.Width - btnPreview.Width) / 2;
                    btnPreview.Location = new Point(btnX, 0);
                    btnFinish.Location = new Point(btnX, 55);
                }
                else
                {
                    // Side by side buttons for medium screens
                    pnlFooter.Height = 120;
                    pnlButtonContainer.Height = 80;
                    btnPreview.Size = new Size(160, 45);
                    btnFinish.Size = new Size(160, 45);
                    
                    int centerX = pnlButtonContainer.Width / 2;
                    btnPreview.Location = new Point(centerX - 170, 20);
                    btnFinish.Location = new Point(centerX + 10, 20);
                }
            }
            else if (formWidth < 1200)
            {
                // Medium screen adjustments
                pnlMainContainer.Padding = new Padding(20);
                pnlHeader.Padding = new Padding(25, 15, 25, 15);
                pnlMedicines.Padding = new Padding(20);
                pnlNotes.Padding = new Padding(20);
                
                pnlGradientHeader.Height = 190;
                pnlCardMedicines.Height = Math.Min(420, formHeight * 48 / 100);
                pnlCardNotes.Height = Math.Min(280, formHeight * 32 / 100);
                pnlFooter.Height = 120;
                
                // Button layout for medium screens
                btnPreview.Size = new Size(180, 50);
                btnFinish.Size = new Size(180, 50);
                
                int centerX = pnlButtonContainer.Width / 2;
                btnPreview.Location = new Point(centerX - 190, 20);
                btnFinish.Location = new Point(centerX + 10, 20);
            }
            else
            {
                // Large screen adjustments
                pnlMainContainer.Padding = new Padding(30);
                pnlHeader.Padding = new Padding(35, 20, 35, 20);
                pnlMedicines.Padding = new Padding(30);
                pnlNotes.Padding = new Padding(30);
                
                pnlGradientHeader.Height = 200;
                pnlCardMedicines.Height = Math.Min(450, formHeight * 50 / 100);
                pnlCardNotes.Height = Math.Min(320, formHeight * 35 / 100);
                pnlFooter.Height = 120;
                
                // Button layout for large screens
                btnPreview.Size = new Size(200, 55);
                btnFinish.Size = new Size(200, 55);
                
                int centerX = pnlButtonContainer.Width / 2;
                btnPreview.Location = new Point(centerX - 210, 20);
                btnFinish.Location = new Point(centerX + 10, 20);
            }
            
            // Adjust button positions for full-screen toggle
            if (pnlHeader.Controls.Contains(btnToggleFullScreen))
            {
                btnToggleFullScreen.Location = new Point(
                    pnlHeader.Width - btnToggleFullScreen.Width - 30,
                    30
                );
            }
        }

        private void ShowTemporaryMessage(string message, Color color)
        {
            // Create a temporary label to show feedback messages
            Label tempLabel = new Label();
            tempLabel.Text = message;
            tempLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tempLabel.ForeColor = color;
            tempLabel.BackColor = Color.Transparent;
            tempLabel.AutoSize = true;
            tempLabel.Location = new Point(10, this.Height - 50);
            
            this.Controls.Add(tempLabel);
            tempLabel.BringToFront();
            
            // Remove the message after 3 seconds
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(tempLabel);
                tempLabel.Dispose();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        // Public methods for setting form data
        public void SetDoctorName(string doctorName)
        {
            lblDoctorName.Text = $"👨‍⚕️ Doctor: {doctorName}";
        }

        public void SetPatientName(string patientName)
        {
            lblPatientName.Text = $"👤 Patient: {patientName}";
        }

        public void SetDate(DateTime date)
        {
            lblDate.Text = $"📅 Date: {date:MMM dd, yyyy}";
        }

        // Public methods for getting form data
        public string[] GetMedicines()
        {
            string[] medicines = new string[lstMedicines.Items.Count];
            for (int i = 0; i < lstMedicines.Items.Count; i++)
            {
                medicines[i] = lstMedicines.Items[i].ToString();
            }
            return medicines;
        }

        public string GetNotes()
        {
            return txtNotes.Text.Trim();
        }

        // Dispose pattern
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of custom resources
                toolTip?.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
    }
}

        