using System;

namespace ABShealthcard.Doctors;

public class DoctorAiHealthSummaryDto
{
    public Guid PatientId { get; set; }
    public string Language { get; set; } = string.Empty; // "EN" or "BN"
    public string PromptPreview { get; set; } = string.Empty;
    public string AiNarrativePreview { get; set; } = string.Empty;
    public DateTime GeneratedAt { get; set; }
}
