using Hospital_Management_System.BLL;
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
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Window
    {
        MedicineBLL medicineBLL = new MedicineBLL();
        public MedicinePage()
        {
            InitializeComponent();
        }

        private void Medicine_Loaded(object sender, RoutedEventArgs e)
        {
            string? s = sSearch.Text;
            dgMedicine.ItemsSource = null;
            dgMedicine.ItemsSource = medicineBLL.GetAllMedicines(s);
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            sSearch.Text = "";
            Medicine_Loaded(sender, e);
        }
    }
}
