using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABShealthcard.Patients;

public class PatientHistoryItem : AuditedAggregateRoot<Guid>
{
    [Required]
    public Guid PatientId { get; set; }

    public HistoryType Type { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Details { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    protected PatientHistoryItem()
    {
    }

    public PatientHistoryItem(Guid id) : base(id)
    {
    }
}


