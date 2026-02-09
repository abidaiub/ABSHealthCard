using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace ABShealthcard.Patients;

public class PatientHealthSummary : Entity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public Guid PatientId { get; set; }

    public string ChronicConditionsJson { get; set; } = string.Empty;
    public string ActiveProblemsJson { get; set; } = string.Empty;
    public string AllergiesJson { get; set; } = string.Empty;

    public string CurrentMedicationsJson { get; set; } = string.Empty;
    public string KeyFindingsJson { get; set; } = string.Empty;
    public string RiskFlagsJson { get; set; } = string.Empty;

    public DateTime LastUpdatedAt { get; set; }
    public string GeneratedBy { get; set; } = string.Empty;
}
