using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    public class PatientBLL
    {
        private readonly DAL.PatientDAL _patientDAL;
        public PatientBLL()
        {
            _patientDAL = new DAL.PatientDAL();
        }
        public List<Patient> GetAllPatients()
        {
            return _patientDAL.GetAllPatients();
        }
        public void AddPatient(Patient patient)
        {
            _patientDAL.AddPatient(patient);
        }
       public void DeletePatient(Patient patient)
        {
            _patientDAL.DeletePatient(patient);
           
        }
        public bool UpdatePatient(Patient patient)
        {
            return _patientDAL.UpdatePatient(patient);
        }
    }
}
