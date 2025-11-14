using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? InsuranceNumber { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
