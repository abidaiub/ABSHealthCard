using System;
using Volo.Abp.Domain.Entities;

namespace ABShealthcard.Labs;

public class LabTestParameter : Entity<Guid>
{
    public Guid LabTestId { get; set; }

    public string Gender { get; set; } = string.Empty;
    public int? AgeMin { get; set; }
    public int? AgeMax { get; set; }

    public decimal? NormalMin { get; set; }
    public decimal? NormalMax { get; set; }

    public decimal? CriticalMin { get; set; }
    public decimal? CriticalMax { get; set; }
}
