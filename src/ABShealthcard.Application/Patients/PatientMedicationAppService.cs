using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABShealthcard.Patients;
using ABShealthcard.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ABShealthcard.Patients;

[Authorize(ABShealthcardPermissions.Patient.MedicationsManage)]
public class PatientMedicationAppService : ABShealthcardAppService, IPatientMedicationAppService
{
    private readonly IRepository<PatientMedication, Guid> _medicationRepository;
    private readonly ICurrentUser _currentUser;

    public PatientMedicationAppService(
        IRepository<PatientMedication, Guid> medicationRepository,
        ICurrentUser currentUser)
    {
        _medicationRepository = medicationRepository;
        _currentUser = currentUser;
    }

    public async Task<PatientMedicationDto> GetAsync(Guid id)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var medication = await _medicationRepository.GetAsync(id);
        
        if (medication.PatientId != _currentUser.Id.Value)
        {
            throw new UnauthorizedAccessException("You can only access your own medications.");
        }

        return ObjectMapper.Map<PatientMedication, PatientMedicationDto>(medication);
    }

    public async Task<List<PatientMedicationDto>> GetListAsync()
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var queryable = await _medicationRepository.GetQueryableAsync();
        var medications = queryable
            .Where(x => x.PatientId == _currentUser.Id.Value)
            .OrderByDescending(x => x.CreationTime)
            .ToList();

        return ObjectMapper.Map<List<PatientMedication>, List<PatientMedicationDto>>(medications);
    }

    public async Task<PatientMedicationDto> CreateAsync(CreateUpdatePatientMedicationDto input)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var medication = new PatientMedication(GuidGenerator.Create())
        {
            PatientId = _currentUser.Id.Value
        };

        ObjectMapper.Map(input, medication);
        await _medicationRepository.InsertAsync(medication);

        return ObjectMapper.Map<PatientMedication, PatientMedicationDto>(medication);
    }

    public async Task<PatientMedicationDto> UpdateAsync(Guid id, CreateUpdatePatientMedicationDto input)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var medication = await _medicationRepository.GetAsync(id);
        
        if (medication.PatientId != _currentUser.Id.Value)
        {
            throw new UnauthorizedAccessException("You can only update your own medications.");
        }

        ObjectMapper.Map(input, medication);
        await _medicationRepository.UpdateAsync(medication);

        return ObjectMapper.Map<PatientMedication, PatientMedicationDto>(medication);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var medication = await _medicationRepository.GetAsync(id);
        
        if (medication.PatientId != _currentUser.Id.Value)
        {
            throw new UnauthorizedAccessException("You can only delete your own medications.");
        }

        await _medicationRepository.DeleteAsync(id);
    }
}

