using System.Windows;

namespace Hospital_Management_System
{
    public partial class MainWindow : Window
    {
        private string _userRole;

        public MainWindow(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;

            ApplyRolePermissions(_userRole);

            // ⭐ Hiển thị WelcomePage ngay sau login
            MainFrame.Content = new WelcomePage(_userRole);
        }

        private void ApplyRolePermissions(string role)
        {
            switch (role)
            {
                case "Receptionist":
                   
                    BtnBilling.Visibility = Visibility.Collapsed;
                    BtnUsers.Visibility = Visibility.Collapsed;
                    break;

                case "Doctor":
                    BtnPatients.Visibility = Visibility.Collapsed;
                    BtnBilling.Visibility = Visibility.Collapsed;
                    
                    break;

                case "Accountant":
                    BtnPatients.Visibility = Visibility.Collapsed;
                    
                    BtnAppointments.Visibility = Visibility.Collapsed;
                    BtnUsers.Visibility = Visibility.Collapsed;
                    break;

                case "Admin":
                    BtnAppointments.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void BtnPatients_Click(object sender, RoutedEventArgs e)
            { 
         MainFrame.Content = new PatientPage();
            }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {   MainFrame.Content = new UserPage();
        }
        private void BtnDoctors_Click(object sender, RoutedEventArgs e)
            => MainFrame.Content = new DoctorPage();

        private void BtnAppointments_Click(object sender, RoutedEventArgs e)
        => MainFrame.Content = new AppointmentPage();


        private void BtnBilling_Click(object sender, RoutedEventArgs e)
            => MainFrame.Content = new BillingPage();

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new LoginPage().Show();
            this.Close();
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void BtnMedicines_Click(object sender, RoutedEventArgs e)
        {            
                MainFrame.Content = new MedicinePage();           
        }
    }
}
