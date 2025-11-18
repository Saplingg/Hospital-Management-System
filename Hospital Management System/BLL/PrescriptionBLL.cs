using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    class PrescriptionBLL
    {
        PrescriptionDAL prescriptionDAL = new PrescriptionDAL();
        public List<PrescriptionDetail> GetAllPrescriptions(string s)
        {
            return prescriptionDAL.GetAllPrescriptions(s);
        }
        public void AddPrescription(PrescriptionDetail prescriptionDetail)
        {
            prescriptionDAL.AddPrescription(prescriptionDetail);
        }
        public void UpdatePrescription(PrescriptionDetail prescriptionDetail)
        {
            prescriptionDAL.UpdatePrescription(prescriptionDetail);
        }
        public void DeletePrescription(PrescriptionDetail prescriptionDetail)
        {
            prescriptionDAL.DeletePrescription(prescriptionDetail);
        }
    }
}
