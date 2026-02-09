using System;
using ABShealthcard.Patients;
using Volo.Abp.Application.Dtos;

namespace ABShealthcard.Patients;

public class PatientMedicationDto : FullAuditedEntityDto<Guid>
{
    public Guid PatientId { get; set; }
    public string MedicineName { get; set; } = string.Empty;
    public string? Dose { get; set; }
    public string? Frequency { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Notes { get; set; }
}


