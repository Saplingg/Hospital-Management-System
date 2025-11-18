using Hospital_Management_System.BLL;
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
    /// Interaction logic for PrescriptionPage.xaml
    /// </summary>
    public partial class PrescriptionPage : Window
    {
        PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
        public PrescriptionPage()
        {
            InitializeComponent();
        }

        private void Prescription_Loaded(object sender, RoutedEventArgs e)
        {
            string? s = sSearch.Text.Trim();
            dgPre.ItemsSource = null;
            dgPre.ItemsSource = prescriptionBLL.GetAllPrescriptions(s);
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            sSearch.Text = "";
            dgPre.ItemsSource = prescriptionBLL.GetAllPrescriptions("");
        }
    }
}
