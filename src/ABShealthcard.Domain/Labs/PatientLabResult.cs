using System;
using Volo.Abp.Domain.Entities;

namespace ABShealthcard.Labs;

public class PatientLabResult : Entity<Guid>
{
    public Guid PatientLabReportId { get; set; }
    public Guid LabTestId { get; set; }

    public decimal? ValueNumeric { get; set; }
    public string ValueText { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;
    public string ResultStatus { get; set; } = string.Empty;
    public bool IsAbnormal { get; set; }

    public decimal? NormalMin { get; set; }
    public decimal? NormalMax { get; set; }

    public DateTime ResultDate { get; set; }
}
