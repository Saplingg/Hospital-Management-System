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
    /// Interaction logic for SideBarDoctor.xaml
    /// </summary>
    public partial class SideBarDoctor : UserControl
    {
        public SideBarDoctor()
        {
            InitializeComponent();
        }
        private void Appointment_Page_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            AppointmentPage ap = new();
            ap.Show();
            parent.Close();
        }

        private void Medicines_Page_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            MedicinePage1 mp = new();
            mp.Show();
            parent.Close();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            LoginPage lp = new();
            lp.Show();
            parent.Close();
        }

        private void MedicalRecords_Page_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            MedicalRecordPage mrp = new();
            mrp.Show();
            parent.Close();
        }

        private void Prescription_Page_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            PrescriptionPage pp = new();
            pp.Show();
            parent.Close();
        }
    }
}
