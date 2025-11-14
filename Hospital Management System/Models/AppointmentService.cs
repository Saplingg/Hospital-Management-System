using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Models;

public partial class AppointmentService
{
    public int AppointmentId { get; set; }

    public int ServiceId { get; set; }

    public int? Quantity { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
