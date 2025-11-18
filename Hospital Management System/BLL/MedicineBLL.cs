using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    public class MedicineBLL
    {
        private readonly MedicineDAL _medicineDAL;
        public MedicineBLL()
        {
            _medicineDAL = new MedicineDAL();
        }
        public List<Medicine> GetAllMedicines()
        {
            return _medicineDAL.GetAllMedicines();
        }
        public void AddMedicine(Medicine medicine)
        {
            _medicineDAL.AddMedicine(medicine);
        }
        public void DeleteMedicine(Medicine medicine)
        {
            _medicineDAL.DeleteMedicine(medicine);
        }
        public void UpdateMedicine(Medicine medicine)
        {
            _medicineDAL.UpdateMedicine(medicine);
        }

    }
}
