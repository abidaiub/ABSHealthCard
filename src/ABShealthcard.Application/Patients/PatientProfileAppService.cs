using System;
using System.Linq;
using System.Threading.Tasks;
using ABShealthcard.Patients;
using ABShealthcard.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace ABShealthcard.Patients;

[Authorize(ABShealthcardPermissions.Patient.ProfileView)]
public class PatientProfileAppService : ABShealthcardAppService, IPatientProfileAppService
{
    private readonly IRepository<PatientProfile, Guid> _patientProfileRepository;
    private readonly ICurrentUser _currentUser;

    public PatientProfileAppService(
        IRepository<PatientProfile, Guid> patientProfileRepository,
        ICurrentUser currentUser)
    {
        _patientProfileRepository = patientProfileRepository;
        _currentUser = currentUser;
    }

    public async Task<PatientProfileDto> GetAsync()
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var profile = await _patientProfileRepository.FindAsync(_currentUser.Id.Value);
        
        if (profile == null)
        {
            // Create empty profile if not exists
            profile = new PatientProfile(_currentUser.Id.Value);
            await _patientProfileRepository.InsertAsync(profile);
        }

        return ObjectMapper.Map<PatientProfile, PatientProfileDto>(profile);
    }

    [Authorize(ABShealthcardPermissions.Patient.ProfileEdit)]
    public async Task<PatientProfileDto> UpdateAsync(CreateUpdatePatientProfileDto input)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var profile = await _patientProfileRepository.FindAsync(_currentUser.Id.Value);
        
        if (profile == null)
        {
            profile = new PatientProfile(_currentUser.Id.Value);
            ObjectMapper.Map(input, profile);
            await _patientProfileRepository.InsertAsync(profile);
        }
        else
        {
            ObjectMapper.Map(input, profile);
            await _patientProfileRepository.UpdateAsync(profile);
        }

        return ObjectMapper.Map<PatientProfile, PatientProfileDto>(profile);
    }
}

