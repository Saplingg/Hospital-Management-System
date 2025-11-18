using Hospital_Management_System.BLL;
using Hospital_Management_System.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_Management_System
{
    public partial class UpdateUser : Window
    {
        private UserBLL userBLL = new UserBLL();
        private User currentUser;

        public UpdateUser(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            // Load dữ liệu lên form
            txtFullName.Text = currentUser.FullName;
            txtUsername.Text = currentUser.Username; // nếu muốn khóa lại: IsEnabled = false trong XAML
            txtPassword.Text = currentUser.Password;

            // Select Role
            cbRole.SelectedItem = cbRole.Items
                .Cast<ComboBoxItem>()
                .First(i => i.Content.ToString() == currentUser.Role);

            // Gender
            if (currentUser.Gender == "Male") rbMale.IsChecked = true;
            else rbFemale.IsChecked = true;

            txtPhone.Text = currentUser.Phone;
            txtEmail.Text = currentUser.Email;
            txtSpec.Text = currentUser.Specialization;
            chkActive.IsChecked = currentUser.Active;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = (cbRole.SelectedItem as ComboBoxItem)?.Content.ToString();
            string gender = rbMale.IsChecked == true ? "Male" : "Female";
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string specialization = txtSpec.Text.Trim();
            bool isActive = chkActive.IsChecked == true;

            // ========== VALIDATION ==========
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("⚠ Full Name, Username, and Password are required!");
                return;
            }

            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("⚠ Phone must be digits only!");
                return;
            }

            if (role == "Doctor" && string.IsNullOrWhiteSpace(specialization))
            {
                MessageBox.Show("⚠ Doctor must have specialization!");
                return;
            }

            // ========== ÁP DỤNG GIÁ TRỊ UPDATE ==========
            currentUser.FullName = fullName;
            currentUser.Username = username;           // ==> bạn cho phép sửa username
            currentUser.Password = password;
            currentUser.Role = role;
            currentUser.Gender = gender;
            currentUser.Phone = phone;
            currentUser.Email = email;
            currentUser.Specialization = role == "Doctor" ? specialization : null;
            currentUser.Active = isActive;

            try
            {
                userBLL.UpdateUser(currentUser);
                MessageBox.Show("✔ User updated successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("❌ Error updating user: " + ex.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
