using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    class MedicineBLL
    {
        MedicineDAL medicineDAL = new();
        public List<Medicine> GetAllMedicines(string s)
        {
            return medicineDAL.GetAllMedicines(s);
        }
        public Medicine GetMedicineById(int id)
        {
            return medicineDAL.GetMedicineById(id);
        }
    }
}
