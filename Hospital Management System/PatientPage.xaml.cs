using Hospital_Management_System.BLL;
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
    /// Interaction logic for PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        private readonly PatientBLL patientBLL;
        public PatientPage()
        {
            InitializeComponent();
            patientBLL = new PatientBLL();
            LoadPatient();
        }

        private void LoadPatient()
        {
            var patients = patientBLL.GetAllPatients();
            dgPatients.ItemsSource = patients;



        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
         AddPatient addForm = new AddPatient();
        addForm.ShowDialog();
            LoadPatient(); // load lại sau khi thêm
        }

 

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            var selectedPatient = dgPatients.SelectedItem as Patient;
            if (selectedPatient != null)
            {
                UpdatePatients updateForm = new UpdatePatients(selectedPatient);
                updateForm.ShowDialog();
                LoadPatient(); // load lại sau khi sửa
            }
            else
            {
                MessageBox.Show("⚠ Please select a patient to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
           Patient selectedPatient = dgPatients.SelectedItem as Patient;
            if (selectedPatient == null)
            {
                MessageBox.Show("⚠ Please select a patient to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var result = MessageBox.Show($" Are you sure you want to delete patient: {selectedPatient.FullName} ?",
                                         "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                patientBLL.DeletePatient(selectedPatient);
                MessageBox.Show(" Patient deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadPatient(); // refresh lại danh sách
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var list = patientBLL.GetAllPatients();

            var filtered = list.Where(p =>
                   p.FullName.ToLower().Contains(keyword) ||
                   p.Phone.Contains(keyword) ||
                   p.Address.ToLower().Contains(keyword) ||
                   p.InsuranceNumber.ToLower().Contains(keyword)
            ).ToList();

            dgPatients.ItemsSource = filtered;

        }

       



        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = txtSearch.Text.ToLower().Trim();
            var list = patientBLL.GetAllPatients();

            var filtered = list.Where(p =>
                   p.FullName.ToLower().Contains(keyword) ||
                   p.Phone.Contains(keyword) ||
                   p.Address.ToLower().Contains(keyword) ||
                   p.InsuranceNumber.ToLower().Contains(keyword)
            ).ToList();

            dgPatients.ItemsSource = filtered;
        }
    }
}
