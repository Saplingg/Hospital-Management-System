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
            var patietns = patientBLL.GetAllPatients();
            dgPatients.ItemsSource = patietns;



        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // ========== 1. Full Name ==========
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtFullName.Focus();
                return;
            }

            // ========== 2. Gender ==========
            if (!(rbMale.IsChecked == true || rbFemale.IsChecked == true))
            {
                MessageBox.Show("Please select gender!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // ========== 3. Date of Birth ==========
            if (dpDOB.SelectedDate == null)
            {
                MessageBox.Show("Please select Date of Birth!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dpDOB.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // ========== 4. Phone ==========
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPhone.Focus();
                return;
            }

            if (!txtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain only digits!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPhone.Focus();
                return;
            }

            if (txtPhone.Text.Length < 9 || txtPhone.Text.Length > 12)
            {
                MessageBox.Show("Phone number must be 9–12 digits!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPhone.Focus();
                return;
            }

            // ========== 5. Address ==========
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtAddress.Focus();
                return;
            }

            // ========== 6. Insurance No (Optional) ==========
            // Cho phép để trống nhưng nếu nhập -> check format
            if (!string.IsNullOrWhiteSpace(txtInsurance.Text))
            {
                if (txtInsurance.Text.Length < 6)
                {
                    MessageBox.Show("Insurance number must be at least 6 characters!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // ===========================
            // Nếu qua hết validate → Add
            // ===========================

            Patient p = new Patient
            {
                FullName = txtFullName.Text.Trim(),
                Gender = rbMale.IsChecked == true ? "Male" : "Female",
                Dob = dpDOB.SelectedDate ?? DateTime.Now,
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                InsuranceNumber = txtInsurance.Text.Trim()
            };

            patientBLL.AddPatient(p);

            MessageBox.Show("Patient added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            LoadPatient();
            ClearForm();
        }

        private void ClearForm()
        {
            txtAddress.Clear();
            txtFullName.Clear();
            txtInsurance.Clear();
            txtPhone.Clear();
            dpDOB.SelectedDate = null;
            rbMale.IsChecked = false;
            rbFemale.IsChecked = false;

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dgPatients.SelectedItems != null)
            {   var patients = dgPatients.SelectedItem as Patient;

                txtAddress.Text = patients.Address;
                txtFullName.Text = patients.FullName;
                txtInsurance.Text = patients.InsuranceNumber;
                txtPhone.Text = patients.Phone;
                dpDOB.SelectedDate = patients.Dob;
                rbMale.IsChecked = patients.Gender=="Male";
                rbFemale.IsChecked = patients.Gender =="Female";

            }
            else
            {
                MessageBox.Show("Please select a patient to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dgPatients.SelectedItems != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected patient?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var selectedPatient = dgPatients.SelectedItem as Patient;
                    patientBLL.RemovePatient(selectedPatient);
                    MessageBox.Show("Patient deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadPatient();
                }
               
            }
            else             {
                MessageBox.Show("Please select a patient to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void DgPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
