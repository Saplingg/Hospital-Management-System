using Hospital_Management_System.BLL;
using Hospital_Management_System.BLLL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for AddUpdateMedicalRecordPage.xaml
    /// </summary>
    public partial class AddUpdateMedicalRecordPage : Window
    {
        public MedicalRecord MedicalRecord { get; set; }
        AppointmentBLL appointmentBLL = new AppointmentBLL();
        MedicalRecordBLL medicalRecordBLL = new MedicalRecordBLL();
        public AddUpdateMedicalRecordPage()
        {
            InitializeComponent();
        }

        private void MedicalRecord_Loaded(object sender, RoutedEventArgs e)
        {
            if (MedicalRecord != null)
            {
                Id.Text = MedicalRecord.RecordId.ToString();
                AppointmentId.ItemsSource = null;
                AppointmentId.ItemsSource = appointmentBLL.GetAllAppointments();
                AppointmentId.DisplayMemberPath = "AppointmentId";
                AppointmentId.SelectedValuePath = "AppointmentId";
                AppointmentId.Text=MedicalRecord.AppointmentId.ToString();
                foreach (var item in appointmentBLL.GetAllAppointments())
                {
                    if (item.AppointmentId == MedicalRecord.AppointmentId)
                    {
                        PatientName.Text = item.Patient.FullName;
                        ApDate.Text = item.AppointmentDate.ToString("g");
                    }
                }
                Diagnosis.Text = MedicalRecord.Diagnosis;
                DoctorNote.Text = MedicalRecord.DoctorNote;
                AppointmentId.IsEnabled = false;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (MedicalRecord == null)
            {
                MedicalRecord = new MedicalRecord();
                AppointmentId.ItemsSource = null;
                AppointmentId.ItemsSource = appointmentBLL.GetAllAvaiableAppointments();
                AppointmentId.DisplayMemberPath = "AppointmentId";
                AppointmentId.SelectedValuePath = "AppointmentId";
                AppointmentId.IsReadOnly = false;
                foreach (var item in AppointmentId.Items)
                {
                    if (item.ToString() == AppointmentId.SelectedItem.ToString())
                    {
                        PatientName.Text = (item as Appointment).Patient.FullName;
                        ApDate.Text = (item as Appointment).AppointmentDate.ToString("g");
                    }
                }
                MedicalRecord.Diagnosis = Diagnosis.Text;
                MedicalRecord.DoctorNote = DoctorNote.Text;
                MedicalRecord.AppointmentId = int.Parse(AppointmentId.Text.Trim());
                medicalRecordBLL.AddMedicalRecord(MedicalRecord);
            }
            else
            {
                MedicalRecord.Diagnosis = Diagnosis.Text;
                MedicalRecord.DoctorNote = DoctorNote.Text;
                medicalRecordBLL.UpdateMedicalRecord(MedicalRecord);
            }
            MessageBox.Show("Updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
