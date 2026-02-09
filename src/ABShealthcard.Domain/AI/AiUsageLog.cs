using System;
using Volo.Abp.Domain.Entities;

namespace ABShealthcard.AI;

public class AiUsageLog : Entity<Guid>
{
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public int TokenEstimate { get; set; }
    public bool UsedFallback { get; set; }
    public DateTime CreatedAt { get; set; }
}
