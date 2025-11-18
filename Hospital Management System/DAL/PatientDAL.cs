using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    public class PatientDAL
    {
        HospitalManagementDbContext dbContext = new HospitalManagementDbContext();
        public List<Patient> GetAllPatients()
        {
            return dbContext.Patients.ToList();
        }
        private readonly HospitalManagementDbContext _context;
        public PatientDAL()
        {
            _context = new HospitalManagementDbContext();
        }
        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
        public void RemovePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
        public bool UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            return _context.SaveChanges() > 0;

        }
    }
}
