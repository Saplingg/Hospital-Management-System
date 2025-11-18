using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    public class MedicineDAL
    {
        private readonly HospitalManagementDbContext _context;
        public MedicineDAL()
        {
            _context = new HospitalManagementDbContext();
        }
        public List<Medicine> GetAllMedicines()
        {
            return _context.Medicines.ToList();
        }
        public void AddMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
        }
        public void DeleteMedicine(Medicine medicine)
        {
            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
        }
        public void UpdateMedicine(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
        }
    }
}
