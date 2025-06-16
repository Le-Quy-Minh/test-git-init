using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Doctor
{
    public class MedicineInfo
    {
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Unit { get; set; }

        public MedicineInfo(string name, string dosage, string unit)
        {
            Name = name;
            Dosage = dosage;
            Unit = unit;
        }

        public override string ToString()
        {
            return $"{Name} ({Dosage} {Unit})";
        }
    }

    public partial class CheckupForm : Form
    {
        private string connectionString = "server=172.19.105.74;user=onii;database=HMS;password=onii123@";
        private int scheduleId;
        private string doctorName;
        private string patientName;
        private DateTime date;
        private int doctorId;
        private int patientId;
        private List<MedicineInfo> selectedMedicines;

        public CheckupForm(int scheduleId, string doctorName, string patientName, DateTime date, int doctorId = 0, int patientId = 0)
        {
            this.scheduleId = scheduleId;
            this.doctorName = string.IsNullOrEmpty(doctorName) ? "(Unknown Doctor)" : doctorName;
            this.patientName = string.IsNullOrEmpty(patientName) ? "(Unknown Patient)" : patientName;
            this.date = date;
            this.doctorId = doctorId;
            this.patientId = patientId;
            this.selectedMedicines = new List<MedicineInfo>();

            Console.WriteLine($"CheckupForm Constructor - Schedule ID: {scheduleId}");
            Console.WriteLine($"CheckupForm Constructor - Doctor Name: {this.doctorName}");
            Console.WriteLine($"CheckupForm Constructor - Patient Name: {this.patientName}");
            Console.WriteLine($"CheckupForm Constructor - Date: {this.date.ToShortDateString()}");
            Console.WriteLine($"CheckupForm Constructor - Doctor ID: {this.doctorId}");
            Console.WriteLine($"CheckupForm Constructor - Patient ID: {this.patientId}");

            InitializeComponent();
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

            if (doctorId == 0 || patientId == 0)
            {
                GetDoctorAndPatientIds();
            }
        }

        private void GetDoctorAndPatientIds()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT doctor_id, patient_id FROM schedule WHERE id = @scheduleId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                    doctorId = reader.GetInt32(0);
                                if (!reader.IsDBNull(1))
                                    patientId = reader.GetInt32(1);
                                
                                Console.WriteLine($"GetDoctorAndPatientIds - Doctor ID: {doctorId}, Patient ID: {patientId}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting doctor and patient IDs: {ex.Message}");
            }
        }

        private void LoadMedicineSuggestions()
        {
            txtMedicine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMedicine.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT name FROM medicine";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                collection.Add(reader["name"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            txtMedicine.AutoCompleteCustomSource = collection;
        }

        private void LoadUnitSuggestions()
        {
            txtUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUnit.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(new[] { "mg", "ml", "tablet", "capsule", "unit" });
            txtUnit.AutoCompleteCustomSource = collection;
        }

        private string GeneratePDF(bool preview)
        {
            try
            {
                string pdfFolder = @"D:\C# learning\PDF-Export";
                if (!Directory.Exists(pdfFolder))
                {
                    Directory.CreateDirectory(pdfFolder);
                }

                string fileName = $"Checkup_{scheduleId}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
                string pdfPath = Path.Combine(pdfFolder, fileName);

                Console.WriteLine($"GeneratePDF - Attempting to write PDF to: {pdfPath}");

                if (File.Exists(pdfPath))
                {
                    try 
                    { 
                        File.Delete(pdfPath); 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"GeneratePDF - File already existed, using new path: {pdfPath}, Error: {ex.Message}");
                        fileName = $"Checkup_{scheduleId}_{DateTime.Now.Ticks}.pdf";
                        pdfPath = Path.Combine(pdfFolder, fileName);
                        Console.WriteLine($"GeneratePDF - New path: {pdfPath}");
                    }
                }

                try
                {
                    using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Close();
                    }
                    File.Delete(pdfPath);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Cannot write to file path {pdfPath}: {ex.Message}", ex);
                }

                using (var printDocument = new System.Drawing.Printing.PrintDocument())
                {
                    printDocument.PrintPage += (sender, args) =>
                    {
                        Console.WriteLine($"GeneratePDF - Doctor Name: {doctorName ?? "null"}");
                        Console.WriteLine($"GeneratePDF - Patient Name: {patientName ?? "null"}");
                        Console.WriteLine($"GeneratePDF - Medicines: {(selectedMedicines != null ? string.Join(", ", selectedMedicines) : "null")}");
                        string notesText = txtNotes != null ? txtNotes.Text : "(txtNotes is null)";
                        Console.WriteLine($"GeneratePDF - Notes: {notesText}");

                        Graphics g = args.Graphics;
                        Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                        Font regularFont = new Font("Arial", 12);
                        Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                        int y = 50;

                        g.DrawString("Hospital Management System", titleFont, Brushes.Black, 50, y);
                        y += 40;
                        g.DrawString("Prescription Details", headerFont, Brushes.Black, 50, y);
                        y += 30;
                        g.DrawString($"Doctor: {doctorName ?? "(Unknown Doctor)"}", regularFont, Brushes.Black, 50, y);
                        y += 20;
                        g.DrawString($"Patient: {patientName ?? "(Unknown Patient)"}", regularFont, Brushes.Black, 50, y);
                        y += 20;
                        g.DrawString($"Date: {date.ToShortDateString()}", regularFont, Brushes.Black, 50, y);
                        y += 30;
                        g.DrawString("Medicines Prescribed:", headerFont, Brushes.Black, 50, y);
                        y += 20;
                        if (selectedMedicines == null || selectedMedicines.Count == 0)
                        {
                            g.DrawString("- (None)", regularFont, Brushes.Black, 50, y);
                            y += 20;
                        }
                        else
                        {
                            foreach (var medicine in selectedMedicines)
                            {
                                g.DrawString($"- {medicine.Name ?? "(Unknown Medicine)"}: {medicine.Dosage} {medicine.Unit}", regularFont, Brushes.Black, 50, y);
                                y += 20;
                            }
                        }
                        y += 20;
                        g.DrawString("Notes:", headerFont, Brushes.Black, 50, y);
                        y += 20;
                        g.DrawString($"{notesText ?? "(No Notes)"}", regularFont, Brushes.Black, 50, y);
                        y += 30;
                        g.DrawString("Doctor Signature: ____________________", regularFont, Brushes.Black, 50, y);
                        y += 20;
                        g.DrawString($"Prescription ID: {scheduleId}", regularFont, Brushes.Black, 50, y);
                        y += 20;
                        g.DrawString($"Generated: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", regularFont, Brushes.Black, 50, y);
                    };

                    printDocument.PrinterSettings.PrintToFile = true;
                    printDocument.PrinterSettings.PrintFileName = pdfPath;
                    printDocument.Print();
                }

                if (!File.Exists(pdfPath))
                {
                    throw new Exception("PDF file was not created successfully");
                }

                if (preview && File.Exists(pdfPath))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"The PDF was created but could not be opened automatically: {ex.Message}", 
                            "Preview Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                return pdfPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error during PDF generation: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        private bool SavePrescriptionToDatabase(string pdfPath)
        {
            try
            {
                Console.WriteLine($"SavePrescriptionToDatabase - Starting: {pdfPath}");
                
                if (doctorId <= 0 || patientId <= 0)
                {
                    MessageBox.Show("Cannot save prescription: Invalid doctor or patient ID", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                byte[] fileBytes = File.ReadAllBytes(pdfPath);
                string fileName = Path.GetFileName(pdfPath);
                string notesWithMeds = txtNotes.Text + "\nMedicines: " + string.Join("; ", selectedMedicines.ConvertAll(m => $"{m.Name} ({m.Dosage} {m.Unit})"));

                Console.WriteLine($"SavePrescriptionToDatabase - File read: {fileName}, Size: {fileBytes.Length} bytes");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO doctor_prescription 
                                    (patient_id, doctor_id, schedule_id, prescription_date, prescription_file, file_name) 
                                    VALUES (@patientId, @doctorId, @scheduleId, @prescriptionDate, @prescriptionFile, @fileName)";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientId);
                        cmd.Parameters.AddWithValue("@doctorId", doctorId);
                        cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                        cmd.Parameters.AddWithValue("@prescriptionDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@prescriptionFile", fileBytes);
                        cmd.Parameters.AddWithValue("@fileName", fileName);
                        cmd.Parameters.AddWithValue("@notes", notesWithMeds);
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"SavePrescriptionToDatabase - Rows affected: {rowsAffected}");
                        
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SavePrescriptionToDatabase - Error: {ex.Message}");
                MessageBox.Show($"Error saving prescription to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}