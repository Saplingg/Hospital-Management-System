using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class PrescriptionDAL
    {
        HospitalManagementDbContext dbContext = new();
        public List<PrescriptionDetail> GetAllPrescriptions(string s)
        {
            List<PrescriptionDetail> prescriptions = dbContext.PrescriptionDetails.Include(p => p.Medicine).Include(a=>a.Record).ToList();
            if(string.IsNullOrWhiteSpace(s))
            {
                return prescriptions;
            }
            return prescriptions.Where(p => p.Medicine.MedicineName.Contains(s.Trim(),StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void AddPrescription(PrescriptionDetail pd) {
            dbContext.PrescriptionDetails.Add(pd);
            dbContext.SaveChanges();
        }
        public void UpdatePrescription(PrescriptionDetail pd)
        {
            dbContext.PrescriptionDetails.Update(pd);
            dbContext.SaveChanges();
        }
        public void DeletePrescription(PrescriptionDetail pd)
        {
            dbContext.PrescriptionDetails.Remove(pd);
            dbContext.SaveChanges();
        }
    }
}
