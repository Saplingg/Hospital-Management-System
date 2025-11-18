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
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        private readonly PatientBLL patientBLL;
        public AddPatient()
        {
            InitializeComponent();
            patientBLL = new PatientBLL();
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
            this.Close();


        }
    }
}
