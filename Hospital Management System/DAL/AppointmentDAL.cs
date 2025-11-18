using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.DAL
{
    class AppointmentDAL
    {
        HospitalManagementDbContext dbContext;
        public List<Appointment> GetAllAppointment(string s, string phone, string status, string date) {
            dbContext = new();
            List<Appointment> appointments = dbContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToList();
            if (!string.IsNullOrEmpty(s))
            {
                appointments = appointments.Where(a => a.Patient.FullName.Contains(s, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(phone))
            {
                appointments = appointments.Where(a => a.Patient.Phone.Contains(phone, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(status))
            {
                appointments = appointments.Where(a => a.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(date))
            {
                appointments = appointments.Where(a => a.AppointmentDate.ToString().Contains(date, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return appointments;
        }
        public List<string> GetAllStatus()
        {
            dbContext = new();
            List<string> statuses = dbContext.Appointments.Select(a => a.Status!).Distinct().ToList();
            return statuses;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            dbContext = new();
            dbContext.Appointments.Update(appointment);
            dbContext.SaveChanges();
        }
        public List<Appointment> GetAllAvaiableAppointments()
        {
            dbContext = new();
            List<Appointment> appointmentIds = dbContext.Appointments.ToList();
            List<Appointment> bookedAppointmentIds = dbContext.MedicalRecords.Select(m => m.Appointment).ToList();
            appointmentIds = appointmentIds.Except(bookedAppointmentIds).ToList();
            return appointmentIds;
        }
        public List<Appointment> GetAllAppointments()
        {
            dbContext = new();
            List<Appointment> appointments = dbContext.Appointments.Include(a => a.Patient).ToList();
            return appointments;
        }
        public void AddAppointment(Appointment appointment)
        {
            dbContext = new();
            dbContext.Appointments.Add(appointment);
            dbContext.SaveChanges();
        }
    }
}
