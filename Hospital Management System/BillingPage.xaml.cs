using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hospital_Management_System
{
    public partial class BillingPage : Page
    {
        private readonly HospitalManagementDbContext _context;
        private Appointment _selectedAppointment;
        private decimal _totalAmount;

        private const int STAFF_ID = 2;

        public BillingPage()
        {
            InitializeComponent();
            _context = new HospitalManagementDbContext();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPendingAppointments();
            CboPaymentMethod.SelectedIndex = 0;
        }

        private void LoadPendingAppointments()
        {
            // Chúng ta thêm điều kiện "&& a.Bill == null"
            // Điều này có nghĩa là "chỉ lấy các lịch hẹn đã hoàn thành
            // VÀ chưa có hóa đơn nào được tạo"
            var pendingAppointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.Status == "Completed" && a.Bill == null) // <-- SỬA Ở ĐÂY
                .ToList();

            DgPendingAppointments.ItemsSource = pendingAppointments;

            ClearBillDetails();
        }

        private void DgPendingAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgPendingAppointments.SelectedItem is Appointment selected)
            {
                _selectedAppointment = selected;
                LoadBillDetails();
                BtnProcessPayment.IsEnabled = true;
            }
            else
            {
                ClearBillDetails();
            }
        }

        private void LoadBillDetails()
        {
            if (_selectedAppointment == null) return;

            TxtBillPatientName.Text = $"Patient: {_selectedAppointment.Patient.FullName}";
            TxtBillAppointmentID.Text = $"Appointment ID: {_selectedAppointment.AppointmentId}";

            var services = _context.AppointmentServices
                .Include(s => s.Service)
                .Where(s => s.AppointmentId == _selectedAppointment.AppointmentId)
                .ToList();
            DgServices.ItemsSource = services;

            var record = _context.MedicalRecords
                .Include(r => r.PrescriptionDetails)
                .ThenInclude(pd => pd.Medicine)
                .FirstOrDefault(r => r.AppointmentId == _selectedAppointment.AppointmentId);

            if (record != null)
            {
                DgMedicines.ItemsSource = record.PrescriptionDetails.ToList();
            }
            else
            {
                DgMedicines.ItemsSource = null;
            }

            decimal servicesTotal = services.Sum(s => s.SubTotal ?? 0);
            decimal medicinesTotal = record?.PrescriptionDetails.Sum(p => p.SubTotal ?? 0) ?? 0;

            _totalAmount = servicesTotal + medicinesTotal;
            TxtTotalAmount.Text = $"TOTAL: {_totalAmount:N0}";
        }

        private void ClearBillDetails()
        {
            TxtBillPatientName.Text = "Patient: [Select from list]";
            TxtBillAppointmentID.Text = "Appointment ID: N/A";
            DgServices.ItemsSource = null;
            DgMedicines.ItemsSource = null;
            TxtTotalAmount.Text = "TOTAL: 0";
            _selectedAppointment = null;
            _totalAmount = 0;
            BtnProcessPayment.IsEnabled = false;
        }

        private void BtnProcessPayment_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAppointment == null || CboPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment and payment method.");
                return;
            }

            try
            {
                // 1. Lấy đối tượng Bệnh nhân (đã có)
                var patient = _selectedAppointment.Patient;

                // 2. TÌM ĐỐI TƯỢNG NHÂN VIÊN (Staff) TỪ DB
                // Đây là bước quan trọng bị thiếu
                var staffUser = _context.Users.Find(STAFF_ID);
                if (staffUser == null)
                {
                    MessageBox.Show($"Error: Staff user with ID {STAFF_ID} not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // 3. Tạo Hóa đơn mới
                var newBill = new Bill
                {
                    TotalAmount = _totalAmount,
                    PaymentMethod = (CboPaymentMethod.SelectedItem as ComboBoxItem).Content.ToString(),
                    PaymentDate = System.DateTime.Now,
                    Status = "Paid",

                    // 4. Gán TẤT CẢ các đối tượng, KHÔNG gán Id
                    Appointment = _selectedAppointment,
                    Patient = patient,
                    Staff = staffUser
                };

                // 5. Cập nhật trạng thái của Lịch hẹn
                _selectedAppointment.Status = "Paid";

                // 6. Thêm hóa đơn mới
                _context.Bills.Add(newBill);

                // 7. Lưu tất cả thay đổi
                _context.SaveChanges();

                MessageBox.Show("Payment successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Tải lại danh sách chờ
                LoadPendingAppointments();
            }
            catch (System.Exception ex)
            {
                // TẠO MỘT THÔNG BÁO LỖI CHI TIẾT
                string errorMessage = "Error processing payment:\n\n";
                errorMessage += $"Message: {ex.Message}\n\n";

                // Đây là phần quan trọng nhất để xem lỗi thật sự
                if (ex.InnerException != null)
                {
                    errorMessage += $"Inner Exception: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "Detailed Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}