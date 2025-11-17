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
    class AppointmentBLL
    {
        AppointmentDAL appointmentDAL = new AppointmentDAL();
        public List<Appointment> GetAllAppointment(string s, string doc, string status, string date)
        {
            return appointmentDAL.GetAllAppointment(s, doc, status, date);
        }
        public List<string> GetAllStatus()
        {
            return appointmentDAL.GetAllStatus();
        }
        public void UpdateAppointment(Appointment appointment)
        {
            appointmentDAL.UpdateAppointment(appointment);
        }
        public List<Appointment> GetAllAvaiableAppointments()
        {
            return appointmentDAL.GetAllAvaiableAppointments();
        }
        public List<Appointment> GetAllAppointments()
        {
            return appointmentDAL.GetAllAppointments();
        }
    }
}
