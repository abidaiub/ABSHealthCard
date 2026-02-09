using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABShealthcard.Patients;

public class PatientMedication : AuditedAggregateRoot<Guid>
{
    [Required]
    public Guid PatientId { get; set; }

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

    protected PatientMedication()
    {
    }

    public PatientMedication(Guid id) : base(id)
    {
    }
}


