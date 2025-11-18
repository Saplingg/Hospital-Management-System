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
    /// Interaction logic for AddUpdatePrescription.xaml
    /// </summary>
    public partial class AddUpdatePrescription : Window
    {
        MedicineBLL medicineBLL = new MedicineBLL();
        PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
        public PrescriptionDetail pd { get; set; } = null;
        public AddUpdatePrescription()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Medicine.ItemsSource = null;
            Medicine.ItemsSource = medicineBLL.GetAllMedicines("");
            Medicine.DisplayMemberPath = "MedicineName";
            Medicine.SelectedValuePath = "MedicineId";
            if (pd != null)
            {
                Id.Text = pd.RecordId.ToString();
                Id.IsEnabled = false;
                Medicine.SelectedValue = pd.MedicineId.ToString();
                Medicine.IsEnabled = false;
                Quantity.Text = pd.Quantity.ToString();
                Dosage.Text = pd.Dosage.ToString();
                Subtotal.Text = (pd.Medicine.UnitPrice * pd.Quantity).ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (pd != null)
            {
                pd.MedicineId = int.Parse(Medicine.SelectedValue.ToString());
                pd.Quantity = int.Parse(Quantity.Text);
                pd.Dosage = Dosage.Text;
                pd.SubTotal = pd.Medicine.UnitPrice * pd.Quantity;
                prescriptionBLL.UpdatePrescription(pd);
            }
            else
            {
                pd = new();
                Medicine.SelectedIndex = 0;
                pd.RecordId = int.Parse(Id.Text);
                pd.MedicineId = int.Parse(Medicine.SelectedValue.ToString());
                pd.Quantity = int.Parse(Quantity.Text);
                pd.Dosage = Dosage.Text;
                pd.SubTotal = medicineBLL.GetMedicineById(int.Parse(Medicine.SelectedValue.ToString())).UnitPrice * pd.Quantity;
                prescriptionBLL.AddPrescription(pd);
            }
            MessageBox.Show("Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
