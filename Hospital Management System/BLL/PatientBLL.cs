using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    class PatientBLL
    {
        PatientDAL patientDAL = new PatientDAL();
        public List<Patient> GetAllPatients()
        {
            return patientDAL.GetAllPatients();
        }
    }
}
