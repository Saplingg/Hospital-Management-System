using Hospital_Management_System.BLLL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        public Appointment ap { get; set; }
        AppointmentBLL appointmentBLL = new();
        public UpdateAppointment()
        {
            InitializeComponent();
        }

        private void AppointmentDetails_Loaded(object sender, RoutedEventArgs e)
        {
            Id.Text = ap.AppointmentId.ToString();
            PatientId.Text = ap.PatientId.ToString();
            Name.Text = ap.Patient.FullName;
            Gender.Text = ap.Patient.Gender;
            Dob.Text = ap.Patient.Dob.ToString();
            Phone.Text = ap.Patient.Phone;
            Address.Text = ap.Patient.Address;
            ApDate.Text = ap.AppointmentDate.ToString();
            Note.Text = ap.Notes;

            FillStatusCB();
            Status.SelectedItem = ap.Status;
        }
        private void FillStatusCB()
        {
            Status.ItemsSource = null;
            Status.ItemsSource = appointmentBLL.GetAllStatus();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ap.Status = Status.Text;
            ap.Notes = Note.Text;
            appointmentBLL.UpdateAppointment(ap);
            MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
