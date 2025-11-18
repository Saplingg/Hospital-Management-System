using Hospital_Management_System.BLL;
using Hospital_Management_System.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_Management_System
{
 
        public partial class AddUser : Window
        {
            private UserBLL userBLL = new UserBLL();

            public AddUser()
            {
                InitializeComponent();

              
            }

           

            private void BtnAdd_Click(object sender, RoutedEventArgs e)
            {
            // ===== 1. Lấy dữ liệu từ UI =====
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = (cbRole.SelectedItem as ComboBoxItem)?.Content.ToString();
            string gender = rbMale.IsChecked == true ? "Male" :
                            rbFemale.IsChecked == true ? "Female" : null;
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string specialization = txtSpec.Text.Trim();
            bool isActive = chkActive.IsChecked == true;
            // ===== 2. Validate =====

            // Check empty fields
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role) ||
                string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("⚠️ Please fill in all required fields!", "Validation",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Phone must be number
            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("⚠️ Phone number must contain digits only!", "Validation",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Doctor requires specialization
            if (role == "Doctor" && string.IsNullOrWhiteSpace(specialization))
            {
                MessageBox.Show("⚠️ Doctor must have a specialization!", "Validation",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var newUser = new User
            {
                FullName = fullName,
                Username = username,
                Password = password,
                Role = role,
                Gender = gender,
                Phone = phone,
                Email = email,
                Specialization = role == "Doctor" ? specialization : null,
                 Active = isActive
            };
            // ===== 3. Thêm user =====`
            try
            {
                userBLL.AddUser(newUser);
                MessageBox.Show("✅ User added successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"❌ Error adding user: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
    }

    
