using System;
using ABShealthcard.Patients;
using Volo.Abp.Application.Dtos;

namespace ABShealthcard.Patients;

public class PatientHistoryItemDto : FullAuditedEntityDto<Guid>
{
    public Guid PatientId { get; set; }
    public HistoryType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Details { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}


