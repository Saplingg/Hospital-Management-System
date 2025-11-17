using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class ServiceDAL
    {
        HospitalManagementDbContext dbContext;
        public List<Service> GetAllServices() { 
            dbContext = new();
            List<Service> services = dbContext.Services.ToList();
            return services;
        }
    }
}
