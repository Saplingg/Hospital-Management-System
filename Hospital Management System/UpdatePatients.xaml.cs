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
    /// Interaction logic for UpdatePatients.xaml
    /// </summary>
    public partial class UpdatePatients : Window
    {
        private Patient currentPatient;
        private readonly PatientBLL patientBLL;
        public UpdatePatients(Patient p)
        {
            InitializeComponent();
            patientBLL = new PatientBLL();
            currentPatient = p;   // nhận object từ PatientPage
            LoadData();
        }

        private void LoadData()
        {
            // Full Name
            txtFullName.Text = currentPatient.FullName;

            // Gender
            if (currentPatient.Gender == "Male")
                rbMale.IsChecked = true;
            else
                rbFemale.IsChecked = true;

            // Date of Birth
            dpDOB.SelectedDate = currentPatient.Dob;

            // Phone
            txtPhone.Text = currentPatient.Phone;

            // Address
            txtAddress.Text = currentPatient.Address;

            // Insurance Number
            txtInsurance.Text = currentPatient.InsuranceNumber;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // ===== GET VALUES =====
            string fullName = txtFullName.Text.Trim();
            string gender = rbMale.IsChecked == true ? "Male" :
                            rbFemale.IsChecked == true ? "Female" : null;
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string insurance = txtInsurance.Text.Trim();
            var dob = dpDOB.SelectedDate;

            // ====== VALIDATION ======

            // Full Name
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("⚠ Full Name is required!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Gender
            if (gender == null)
            {
                MessageBox.Show("⚠ Please select gender!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // DOB
            if (dob == null)
            {
                MessageBox.Show("⚠ Date of Birth is required!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // DOB not in the future
            if (dob > DateTime.Now)
            {
                MessageBox.Show("⚠ Date of Birth cannot be in the future!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Phone must be digits
            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("⚠ Phone number must contain digits only!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Optional: insurance check (chỉ chữ/số)
            if (!string.IsNullOrEmpty(insurance) && !insurance.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("⚠ Insurance number must not contain special characters!", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // ====== APPLY NEW VALUES ======
            currentPatient.FullName = fullName;
            currentPatient.Gender = gender;
            currentPatient.Phone = phone;
            currentPatient.Address = address;
            currentPatient.InsuranceNumber = insurance;
            currentPatient.Dob = dob.Value;

            // ====== UPDATE DB ======
            try
            {
                patientBLL.UpdatePatient(currentPatient);
                MessageBox.Show("✔ Patient updated successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error updating patient: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
