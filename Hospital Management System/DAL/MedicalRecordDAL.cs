using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class MedicalRecordDAL
    {
        HospitalManagementDbContext dbContext;
        public List<MedicalRecord> GetAllMedicalRecords(string s, string d)
        {
            dbContext = new HospitalManagementDbContext();
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
            medicalRecords = dbContext.MedicalRecords.Include(m => m.Appointment).ToList();
            if (!string.IsNullOrEmpty(s))
            {
                medicalRecords = medicalRecords
                    .Where(m => m.Diagnosis.Contains(s.Trim(),StringComparison.OrdinalIgnoreCase) || m.DoctorNote.Contains(s.Trim(),StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            if (!string.IsNullOrEmpty(d))
            {
                medicalRecords = medicalRecords
                    .Where(m => m.CreatedDate.ToString().Contains(d.Trim(),StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            return medicalRecords;
        }
        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            dbContext = new HospitalManagementDbContext();
            dbContext.MedicalRecords.Add(medicalRecord);
            dbContext.SaveChanges();
        }
        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            dbContext = new HospitalManagementDbContext();
            dbContext.MedicalRecords.Update(medicalRecord);
            dbContext.SaveChanges();
        }
    }
}
