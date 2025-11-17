using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Models;

public partial class Medicine
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string? Unit { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();
}
