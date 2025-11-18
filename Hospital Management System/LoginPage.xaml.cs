using Hospital_Management_System.BLL;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_Management_System
{
    public partial class LoginPage : Window
    {
        private readonly UserBLL _userBLL;
        public LoginPage()
            
        {
            InitializeComponent();
            _userBLL = new UserBLL();
        }
        

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();
            string role = (cbRole.SelectedItem as ComboBoxItem)?.Content.ToString();

            var user = _userBLL.Login(username, password, role);

            if (user == null)
            {
                MessageBox.Show(" Please fill all fields or invalid login!",
                                "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (user != null)
            {
                MessageBox.Show($" Welcome {user.FullName} ({user.Role})!",
                                "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow main = new MainWindow(user.Role);
                main.Show();
                if (user.Role == "Doctor") { 
                    AppointmentPage appointmentPage = new AppointmentPage();
                    appointmentPage.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(" Invalid username, password, or role.",
                                "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
