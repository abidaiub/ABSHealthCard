using System;
using System.Threading.Tasks;
using ABShealthcard.AI;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ABShealthcard.Doctors;

public class DoctorAiFeedbackAppService : ApplicationService
{
    private readonly IRepository<DoctorAiFeedback, Guid> _repo;

    public DoctorAiFeedbackAppService(IRepository<DoctorAiFeedback, Guid> repo)
    {
        _repo = repo;
    }

    public async Task SubmitAsync(Guid patientId, bool isHelpful, string? comment)
    {
        var feedback = new DoctorAiFeedback
        {
            DoctorId = CurrentUser.Id ?? Guid.Empty,
            PatientId = patientId,
            IsHelpful = isHelpful,
            Comment = comment ?? string.Empty,
            CreatedAt = Clock.Now
        };

        await _repo.InsertAsync(feedback);
    }
}
