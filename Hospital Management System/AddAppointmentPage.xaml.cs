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
    /// Interaction logic for AddAppointmentPage.xaml
    /// </summary>
    public partial class AddAppointmentPage : Window
    {
        PatientBLL patientBLL = new PatientBLL();
        AppointmentBLL appointmentBLL = new AppointmentBLL();
        public AddAppointmentPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDoctorComboBox();
            FillPatientComboBox();
            FillStatus();
        }
        private void FillStatus() { 
            st.ItemsSource = null;
            st.ItemsSource = appointmentBLL.GetAllStatus();
            st.SelectedIndex = 0;
        }
        private void FillPatientComboBox()
        {
            Patient.ItemsSource = null;
            Patient.ItemsSource = patientBLL.GetAllPatients();
            Patient.DisplayMemberPath = "FullName";
            Patient.SelectedValuePath = "PatientId";
            st.SelectedIndex = 0;
        }
        private void FillDoctorComboBox()
        {
            Doctor.ItemsSource = null;
            DoctorBLL doctorBLL = new DoctorBLL();
            Doctor.ItemsSource = doctorBLL.GetAllDoctor();
            Doctor.DisplayMemberPath = "FullName";
            Doctor.SelectedValuePath = "UserId";
            st.SelectedIndex = 0;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.PatientId = (int)Patient.SelectedValue;
            appointment.DoctorId = (int)Doctor.SelectedValue;
            appointment.AppointmentDate = (DateTime)ApDate.SelectedDate;
            appointment.Status = (string)st.SelectedValue;
            appointment.Notes = Note.Text;

            appointmentBLL.AddAppointment(appointment);
            MessageBox.Show("Appointment added successfully.");
            this.Close();
        }
    }
}
