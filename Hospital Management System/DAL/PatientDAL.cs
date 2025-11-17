using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class PatientDAL
    {
        HospitalManagementDbContext dbContext = new HospitalManagementDbContext();
        public List<Patient> GetAllPatients()
        {
            return dbContext.Patients.ToList();
        }
    }
}
