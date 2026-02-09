using System;
using Volo.Abp.Domain.Entities;

namespace ABShealthcard.AI;

public class DoctorAiFeedback : Entity<Guid>
{
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public bool IsHelpful { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
