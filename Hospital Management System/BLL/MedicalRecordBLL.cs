using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    class MedicalRecordBLL
    {
        MedicalRecordDAL medicalRecordDAL = new MedicalRecordDAL();
        public List<MedicalRecord> GetAllMedicalRecords(string s, string d)
        {
            return medicalRecordDAL.GetAllMedicalRecords(s,d);
        }
        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecordDAL.AddMedicalRecord(medicalRecord);
        }
        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecordDAL.UpdateMedicalRecord(medicalRecord);
        }
    }
}
