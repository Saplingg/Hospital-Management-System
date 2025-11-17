using Hospital_Management_System.DAL;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.BLL
{
    internal class AppointmentServiceBLL
    {
        AppointmentServicesDAL appointmentServicesDAL = new AppointmentServicesDAL();
        public List<AppointmentService> GetAllAppointmentServicesByAppointmentId(int appointmentId)
        {
            return appointmentServicesDAL.GetAllAppointmentServicesByAppointmentId(appointmentId);
        }
        public int GetSubtotalByAppointmentId(int appointmentId)
        {
            return appointmentServicesDAL.GetSubtotalByAppointmentId(appointmentId);
        }
    }
}
