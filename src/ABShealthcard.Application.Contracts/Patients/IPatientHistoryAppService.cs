using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ABShealthcard.Patients;

public interface IPatientHistoryAppService : IApplicationService
{
    Task<PatientHistoryItemDto> GetAsync(Guid id);
    Task<PagedResultDto<PatientHistoryItemDto>> GetListAsync(PatientHistoryItemFilterDto input);
    Task<PatientHistoryItemDto> CreateAsync(CreateUpdatePatientHistoryItemDto input);
    Task<PatientHistoryItemDto> UpdateAsync(Guid id, CreateUpdatePatientHistoryItemDto input);
    Task DeleteAsync(Guid id);
}

