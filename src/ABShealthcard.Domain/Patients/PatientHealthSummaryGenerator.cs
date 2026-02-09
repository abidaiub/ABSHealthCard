using System;
using System.Collections.Generic;
using System.Linq;
using ABShealthcard.Labs;
using Volo.Abp.Domain.Services;

namespace ABShealthcard.Patients;

public class PatientHealthSummaryGenerator : DomainService
{
    public PatientHealthSummary Generate(
        Guid patientId,
        List<PatientLabResult> labResults,
        PatientHealthSummary? existingSummary = null)
    {
        var summary = existingSummary ?? new PatientHealthSummary
        {
            PatientId = patientId,
            GeneratedBy = "System"
        };

        var keyFindings = new List<object>();
        var risks = new List<object>();

        foreach (var resultGroup in labResults
                     .Where(x => x.IsAbnormal)
                     .OrderByDescending(x => x.ResultDate)
                     .GroupBy(x => x.LabTestId))
        {
            var latest = resultGroup.First();

            keyFindings.Add(new
            {
                TestId = latest.LabTestId,
                Status = latest.ResultStatus,
                Value = latest.ValueNumeric ?? 0,
                Date = latest.ResultDate
            });

            risks.Add(new
            {
                Risk = "Abnormal lab trend detected",
                Level = string.Equals(latest.ResultStatus, "Critical", StringComparison.OrdinalIgnoreCase)
                    ? "High"
                    : "Medium",
                Reason = $"Latest result is {latest.ResultStatus}"
            });
        }

        summary.KeyFindingsJson = System.Text.Json.JsonSerializer.Serialize(keyFindings);
        summary.RiskFlagsJson = System.Text.Json.JsonSerializer.Serialize(risks);
        summary.LastUpdatedAt = DateTime.UtcNow;

        // Future:
        // - AI-based narrative generation
        // - Trend analysis (rising/falling)
        // - Bangla explanation mapping
        // - Doctor override & lock

        return summary;
    }
}
