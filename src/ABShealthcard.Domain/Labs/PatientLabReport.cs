using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace ABShealthcard.Labs;

public class PatientLabReport : Entity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public Guid PatientId { get; set; }

    public string LabName { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public string ReportType { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
}
