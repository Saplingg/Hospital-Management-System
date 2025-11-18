using Hospital_Management_System.BLL;
using Hospital_Management_System.Models;
using System.Windows;

namespace Hospital_Management_System
{
    public partial class UpdateMedicine : Window
    {
        private MedicineBLL medicineBLL = new MedicineBLL();
        private Medicine current;

        public UpdateMedicine(Medicine m)
        {
            InitializeComponent();
            current = m;
            LoadData();
        }

        private void LoadData()
        {
            txtName.Text = current.MedicineName;
            txtUnit.Text = current.Unit;
            txtPrice.Text = current.UnitPrice?.ToString();
            txtStock.Text = current.Stock?.ToString();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ UI
            string name = txtName.Text.Trim();
            string unit = txtUnit.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string stockText = txtStock.Text.Trim();

            // ===== VALIDATE GIỐNG ADD =====

            // Name required
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name required!");
                return;
            }

            // Price must be number
            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Unit Price must be number!");
                return;
            }

            // Stock must be number
            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("Stock must be number!");
                return;
            }

            // ===== APPLY TO CURRENT MEDICINE =====
            current.MedicineName = name;
            current.Unit = unit;
            current.UnitPrice = price;
            current.Stock = stock;

            // ===== UPDATE DB =====
            try
            {
                medicineBLL.UpdateMedicine(current);
                MessageBox.Show("✔ Medicine updated!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating medicine: " + ex.Message);
            }
        }

    }
}
