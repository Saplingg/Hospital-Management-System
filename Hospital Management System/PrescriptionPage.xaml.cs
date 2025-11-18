using Hospital_Management_System.BLL;
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddUpdatePrescription aup = new();
            aup.pd = null;
            aup.Closed += (s, args) =>
            {
                Prescription_Loaded(sender, e);
                this.Show();
            };
            aup.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionDetail? pd = dgPre.SelectedItem as PrescriptionDetail;
            if (pd == null)
            {
                MessageBox.Show("Please select a Pre to update info", "Select", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {

                AddUpdatePrescription aup = new();
                aup.pd = pd;
                aup.Closed += (s, args) =>
                {
                    Prescription_Loaded(sender, e);
                    this.Show();
                };
                aup.Show();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionDetail? pd = dgPre.SelectedItem as PrescriptionDetail;
            if (pd == null)
            {
                MessageBox.Show("Please select a Pre to Delete", "Select", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (MessageBox.Show("Do you really want to delete?", "Confirmation delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                prescriptionBLL.DeletePrescription(pd);
                Prescription_Loaded(sender, e);
            }
            else
                return;
        }
    }
}
