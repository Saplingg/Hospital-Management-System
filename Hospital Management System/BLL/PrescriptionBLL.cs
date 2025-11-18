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
    }
}
