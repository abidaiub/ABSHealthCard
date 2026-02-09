using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Services;

namespace ABShealthcard.Labs;

public class LabTrendAnalyzer : DomainService
{
    public string AnalyzeTrend(IEnumerable<PatientLabResult> results)
    {
        var ordered = results
            .Where(r => r.ValueNumeric.HasValue)
            .OrderByDescending(r => r.ResultDate)
            .Take(3)
            .ToList();

        if (ordered.Count < 2)
        {
            return "InsufficientData";
        }

        var latest = ordered[0].ValueNumeric!.Value;
        var previous = ordered[1].ValueNumeric!.Value;

        if (latest > previous)
        {
            return "Rising";
        }

        if (latest < previous)
        {
            return "Falling";
        }

        return "Stable";
    }

    // Future:
    // - Time-weighted trend calculation
    // - Threshold-based sensitivity
    // - Chronic condition specific trend logic
    // - AI-assisted pattern detection
}
