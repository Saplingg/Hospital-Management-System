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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {   
        private readonly UserBLL userBLL;
        public UserPage()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            try
            {
                LoadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());   // ⭐ hiện lỗi thật
            }
            
        }

        private void LoadUser()
        {
            var listUsers = userBLL.GetAllUsers();
            dgUsers.ItemsSource = listUsers;


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser add = new AddUser();
            add.ShowDialog();
            LoadUser(); // refresh lại grid
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            // Lấy user đang chọn trong DataGrid
            User selectedUser = dgUsers.SelectedItem as User;

            if (selectedUser == null)
            {
                MessageBox.Show("⚠ Please select a user to edit.",
                                "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mở form UpdateUser và truyền user vào
            UpdateUser updateForm = new UpdateUser(selectedUser);
            updateForm.ShowDialog();

            // Sau khi update, load lại danh sách
            LoadUser();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else 
            {
                var user = dgUsers.SelectedItem as User;
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the user '{user.Username}'?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    userBLL.DeleteUser(user);
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadUser(); // refresh lại grid
                }
            }

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            String searchTerm = txtSearch.Text.ToLower();
            var filteredUsers = userBLL.GetAllUsers()
                .Where(u => u.Username.ToLower().Contains(searchTerm) )
                            
                .ToList();
            dgUsers.ItemsSource = filteredUsers;
        }
    }
}
