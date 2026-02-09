using System;
using Volo.Abp.Domain.Entities;

namespace ABShealthcard.Labs;

public class LabTest : Entity<Guid>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsNumeric { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
