using Hospital_Management_System.BLL;
using Hospital_Management_System.BLLL;
using Hospital_Management_System.Models;
using Microsoft.Identity.Client;
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
    /// Interaction logic for AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Window
    {
        AppointmentBLL appointmentBLL = new();
        PatientBLL patientBLL = new();
        public AppointmentPage()
        {
            InitializeComponent();
        }

        private void Appointment_Loaded(object sender, RoutedEventArgs e)
        {
            FillAppointmentData();
            FillStatusCB();
        }

        private void FillAppointmentData()
        {
            sSearch.Text = sSearch.Text.Trim();
            string? p = ftPhone.Text.Trim();
            string? st = ftStatus.Text.Trim();
            string? dt = ftDate.Text.Trim();
            string? s = sSearch.Text.Trim();
            dgAppointment.ItemsSource = null;
            dgAppointment.ItemsSource = appointmentBLL.GetAllAppointment(s, p, st, dt);
        }
        private void FillStatusCB()
        {
            ftStatus.ItemsSource = null;
            ftStatus.ItemsSource = appointmentBLL.GetAllStatus();
        }
        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            sSearch.Text = "";
            string? p = ftPhone.Text.Trim();
            string? st = ftStatus.Text.Trim();
            string? dt = ftDate.Text.Trim();
            dgAppointment.ItemsSource = null;
            dgAppointment.ItemsSource = appointmentBLL.GetAllAppointment("", p, st, dt);
        }

        private void FilterSetup(object sender, RoutedEventArgs e)
        {
            FillAppointmentData();
        }
        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            sSearch.Text = sSearch.Text.Trim();
            ftPhone.Text = "";
            ftStatus.Text = "";
            ftDate.Text = "";
            FillStatusCB();
            FillAppointmentData();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Appointment? ap = dgAppointment.SelectedItem as Appointment;
            if (ap == null)
            {
                MessageBox.Show("Please select a appointment to update info", "Select a appointment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                UpdateAppointment uaa = new();
                uaa.ap = ap;
                uaa.Closed += (s, args) =>
                {
                    FillAppointmentData();
                    this.Show();
                };
                uaa.Show();
            }
        }

        private void Appointment_Service_View(object sender, RoutedEventArgs e)
        {
            Appointment? ap = dgAppointment.SelectedItem as Appointment;
            if (ap == null)
            {
                MessageBox.Show("Please select a appointment to view it's services", "Select a appointment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                AppoinmentServiceForm asf = new();
                asf.ap = ap;
                asf.Closed += (s, args) =>
                {
                    this.Show();
                };
                asf.Show();
            }
        }

        private void Appointment_Service_Add(object sender, RoutedEventArgs e)
        {
            AddAppointmentPage aap = new();
            aap.Closed += (s, args) =>
            {
                FillAppointmentData();
                this.Show();
            };
            aap.Show();
        }
    }
}
