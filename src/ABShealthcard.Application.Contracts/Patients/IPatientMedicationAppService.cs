using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ABShealthcard.Patients;

public interface IPatientMedicationAppService : IApplicationService
{
    Task<PatientMedicationDto> GetAsync(Guid id);
    Task<List<PatientMedicationDto>> GetListAsync();
    Task<PatientMedicationDto> CreateAsync(CreateUpdatePatientMedicationDto input);
    Task<PatientMedicationDto> UpdateAsync(Guid id, CreateUpdatePatientMedicationDto input);
    Task DeleteAsync(Guid id);
}


