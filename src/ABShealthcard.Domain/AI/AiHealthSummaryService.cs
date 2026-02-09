using System.Text.Json;
using System.Threading.Tasks;
using ABShealthcard.Patients;
using Microsoft.Extensions.Options;
using Volo.Abp.Domain.Services;

namespace ABShealthcard.AI;

public class AiHealthSummaryService : DomainService
{
    private readonly AiHealthSummaryOptions _options;
    private readonly IAiTextCompletionClient _client;

    public AiHealthSummaryService(
        IOptions<AiHealthSummaryOptions> options,
        IAiTextCompletionClient client)
    {
        _options = options.Value;
        _client = client;
    }

    public string? GenerateNarrative(PatientHealthSummary? summary)
    {
        if (!_options.EnableAiHealthSummary || summary == null)
        {
            return null;
        }

        // IMPORTANT:
        // This is where an LLM call will happen later.
        // For now, return a placeholder-safe narrative.

        var payload = JsonSerializer.Serialize(new
        {
            summary.PatientId,
            summary.RiskFlagsJson,
            summary.KeyFindingsJson
        });

        return $"Patient health summary updated on {summary.LastUpdatedAt:d}. " +
               $"There are identified health risks that require medical attention. " +
               $"(Payload: {payload})";
    }

    public async Task<string?> GenerateNarrativeAsync(string prompt, int maxTokens)
    {
        if (!_options.EnableAiHealthSummary)
        {
            return null;
        }

        try
        {
            return await _client.CompleteAsync(prompt, maxTokens);
        }
        catch
        {
            return null;
        }
    }

    // Future:
    // - OpenAI / Azure OpenAI integration
    // - Prompt templates (Bangla / English)
    // - Token usage tracking
    // - Audit logging
    // - AI output caching
}
