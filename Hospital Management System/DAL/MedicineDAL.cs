using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class MedicineDAL
    {
        HospitalManagementDbContext dbContext;


        public List<Medicine> GetAllMedicines(string s)
        {
            dbContext = new HospitalManagementDbContext();
            List<Medicine> medicines = dbContext.Medicines.ToList();
            if (!string.IsNullOrEmpty(s))
            {
                return medicines.Where(m => m.MedicineName.Contains(s.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return medicines;
        }
        public Medicine GetMedicineById(int id) {
            dbContext = new HospitalManagementDbContext();
            return dbContext.Medicines.Find(id);
        }
    }
}
