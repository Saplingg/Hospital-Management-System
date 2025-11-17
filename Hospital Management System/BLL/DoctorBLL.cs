using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLLL
{
    class DoctorBLL
    {
        DoctorDAL doctorDAL = new DoctorDAL();
        public List<User> GetAllDoctor()
        {
            return doctorDAL.GetAllDoctor();
        }
    }
}
