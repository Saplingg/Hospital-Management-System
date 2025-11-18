using Hospital_Management_System.BLL;
using Hospital_Management_System.BLLL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
    /// Interaction logic for MedicalRecordPage.xaml
    /// </summary>
    public partial class MedicalRecordPage : Window
    {
        MedicalRecordBLL medicalRecordBLL = new MedicalRecordBLL();
        AppointmentBLL appointmentBLL = new();
        public MedicalRecordPage()
        {
            InitializeComponent();
        }

        private void FilterSetup(object sender, RoutedEventArgs e)
        {
            string? s = sSearch.Text.Trim();
            string? d = ftDate.Text.Trim();
            dgMR.ItemsSource = null;
            dgMR.ItemsSource = medicalRecordBLL.GetAllMedicalRecords(s, d);
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            sSearch.Text = "";
            FilterSetup(sender, e);
        }

        private void AddMedicalRecord(object sender, RoutedEventArgs e)
        {
            int count = appointmentBLL.GetAllAvaiableAppointments().Count;
            if (count == 0)
            {
                MessageBox.Show("There is no available appointment to add medical record", "No Available Appointment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            AddUpdateMedicalRecordPage amr = new AddUpdateMedicalRecordPage();
            amr.MedicalRecord = null;
            amr.Closed += (s, args) =>
            {
                FilterSetup(sender, e);
                this.Show();
            };
            amr.Show();
        }

        private void UpdateMedicalRecord(object sender, RoutedEventArgs e)
        {
            MedicalRecord? md = dgMR.SelectedItem as MedicalRecord;
            if (md == null)
            {
                MessageBox.Show("Please select a Medical Record to update info", "Select a Medical Record", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {

                AddUpdateMedicalRecordPage amr = new AddUpdateMedicalRecordPage();
                amr.MedicalRecord = md;
                amr.Closed += (s, args) =>
                {
                    FilterSetup(sender, e);
                    this.Show();
                };
                amr.Show();
            }
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ftDate.Text = "";
            FilterSetup(sender, e);
        }
    }
}
