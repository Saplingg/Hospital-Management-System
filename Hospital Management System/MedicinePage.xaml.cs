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
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        private MedicineBLL medicineBLL;
        public MedicinePage()
        {   
            InitializeComponent();
            medicineBLL = new MedicineBLL();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            var listMedicines = medicineBLL.GetAllMedicines();
            dgMedicines.ItemsSource = listMedicines;


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddMedicine().ShowDialog();
            LoadMedicines();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedMedicine = dgMedicines.SelectedItem as Medicine;

            if (selectedMedicine == null)
            {
                MessageBox.Show("⚠ Please select a medicine to edit.");
                return;
            }

            new UpdateMedicine(selectedMedicine).ShowDialog();
            LoadMedicines();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedMedicine = dgMedicines.SelectedItem as Medicine;

            if (selectedMedicine == null)
            {
                MessageBox.Show("⚠ Please select a medicine to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete: {selectedMedicine.MedicineName}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm == MessageBoxResult.Yes)
            {
                medicineBLL.DeleteMedicine(selectedMedicine);
                MessageBox.Show("✔ Medicine deleted.");
                LoadMedicines();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string text = txtSearch.Text.ToLower();

            var list = medicineBLL.GetAllMedicines()
                                  .Where(m => m.MedicineName.ToLower().Contains(text))
                                  .ToList();

            dgMedicines.ItemsSource = list;
        }
    }
}
