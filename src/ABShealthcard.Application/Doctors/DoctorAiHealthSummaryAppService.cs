using System;
using System.Threading.Tasks;
using ABShealthcard.AI;
using ABShealthcard.Doctors;
using ABShealthcard.Patients;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Timing;

namespace ABShealthcard.Doctors;

public class DoctorAiHealthSummaryAppService : ApplicationService
{
    private readonly IRepository<PatientHealthSummary, Guid> _summaryRepo;
    private readonly AiHealthSummaryPromptProvider _promptProvider;
    private readonly AiHealthSummaryService _aiService;

    public DoctorAiHealthSummaryAppService(
        IRepository<PatientHealthSummary, Guid> summaryRepo,
        AiHealthSummaryPromptProvider promptProvider,
        AiHealthSummaryService aiService)
    {
        _summaryRepo = summaryRepo;
        _promptProvider = promptProvider;
        _aiService = aiService;
    }

    public async Task<DoctorAiHealthSummaryDto?> PreviewAsync(Guid patientId, string language)
    {
        var summary = await _summaryRepo.FirstOrDefaultAsync(x => x.PatientId == patientId);
        if (summary == null)
        {
            return null;
        }

        var prompt = language == "BN"
            ? _promptProvider.BuildBanglaPrompt(summary)
            : _promptProvider.BuildEnglishPrompt(summary);

        var narrative = _aiService.GenerateNarrative(summary);

        return new DoctorAiHealthSummaryDto
        {
            PatientId = patientId,
            Language = language,
            PromptPreview = prompt,
            AiNarrativePreview = narrative ?? string.Empty,
            GeneratedAt = Clock.Now
        };
    }
}
