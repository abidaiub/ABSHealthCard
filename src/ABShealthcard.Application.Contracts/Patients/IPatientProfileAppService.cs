using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ABShealthcard.Patients;

public interface IPatientProfileAppService : IApplicationService
{
    Task<PatientProfileDto> GetAsync();
    Task<PatientProfileDto> UpdateAsync(CreateUpdatePatientProfileDto input);
}


