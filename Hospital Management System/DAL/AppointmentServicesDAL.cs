using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class AppointmentServicesDAL
    {
        HospitalManagementDbContext dbContext;
        public List<AppointmentService> GetAllAppointmentServicesByAppointmentId(int appointmentId)
        {
            dbContext = new HospitalManagementDbContext();
            List<AppointmentService> appointmentServices = dbContext.AppointmentServices.Include(asv => asv.Service)
                .Where(asv => asv.AppointmentId == appointmentId)
                .ToList();
            return appointmentServices;
        }
        public int GetSubtotalByAppointmentId(int appointmentId)
        {
            dbContext = new HospitalManagementDbContext();
            int subtotal = dbContext.AppointmentServices
                .Where(asv => asv.AppointmentId == appointmentId)
                .Sum(asv => (int?)asv.Service.Price) ?? 0;
            return subtotal;
        }
    }
}
