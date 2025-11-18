using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class DoctorDAL
    {
        HospitalManagementDbContext dbContext;
        public List<User> GetAllDoctor()
        {
            dbContext = new();
            List<User> doctors = dbContext.Users.Where(r=>r.Role == "Doctor").ToList();
            return doctors;
        }
    }
}
