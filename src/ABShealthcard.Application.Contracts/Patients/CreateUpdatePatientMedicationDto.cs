using System;
using System.ComponentModel.DataAnnotations;
using ABShealthcard.Patients;

namespace ABShealthcard.Patients;

public class CreateUpdatePatientMedicationDto
{
    [Required]
    [StringLength(200)]
    public string MedicineName { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Dose { get; set; }

    [StringLength(100)]
    public string? Frequency { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [StringLength(1000)]
    public string? Notes { get; set; }
}


