using Hospital_Management_System.BLL;
using Hospital_Management_System.Models;
using System;
using System.Linq;
using System.Windows;

namespace Hospital_Management_System
{
    public partial class AddMedicine : Window
    {
        private MedicineBLL medicineBLL = new MedicineBLL();

        public AddMedicine()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string unit = txtUnit.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string stockText = txtStock.Text.Trim();

            // ===== VALIDATION =====

            // Name required
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("⚠ Medicine name is required!", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Name must not contain special characters
            if (!name.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("⚠ Medicine name must not contain special characters!", "Validation",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Unit required
            if (string.IsNullOrWhiteSpace(unit))
            {
                MessageBox.Show("⚠ Unit is required! Example: 'Tablet', 'Bottle', 'Pack'.",
                                "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Price must be decimal
            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("⚠ Unit Price must be a valid number!", "Validation",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Price must be > 0
            if (price <= 0)
            {
                MessageBox.Show("⚠ Unit Price must be greater than 0!", "Validation",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Stock must be integer
            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("⚠ Stock must be a valid integer!", "Validation",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Stock must be >= 0
            if (stock < 0)
            {
                MessageBox.Show("⚠ Stock cannot be negative!", "Validation",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // ===== CREATE MEDICINE OBJECT =====
            Medicine m = new Medicine
            {
                MedicineName = name,
                Unit = unit,
                UnitPrice = price,
                Stock = stock
            };

            // ===== SAVE =====
            medicineBLL.AddMedicine(m);

            MessageBox.Show("✔ Medicine added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
}
