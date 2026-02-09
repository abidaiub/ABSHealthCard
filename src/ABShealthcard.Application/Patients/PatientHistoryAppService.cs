using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABShealthcard.Patients;
using ABShealthcard.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ABShealthcard.Patients;

[Authorize(ABShealthcardPermissions.Patient.HistoryManage)]
public class PatientHistoryAppService : ABShealthcardAppService, IPatientHistoryAppService
{
    private readonly IRepository<PatientHistoryItem, Guid> _historyRepository;
    private readonly ICurrentUser _currentUser;

    public PatientHistoryAppService(
        IRepository<PatientHistoryItem, Guid> historyRepository,
        ICurrentUser currentUser)
    {
        _historyRepository = historyRepository;
        _currentUser = currentUser;
    }

    public async Task<PatientHistoryItemDto> GetAsync(Guid id)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var item = await _historyRepository.GetAsync(id);
        
        if (item.PatientId != _currentUser.Id.Value)
        {
            throw new UnauthorizedAccessException("You can only access your own history items.");
        }

        return ObjectMapper.Map<PatientHistoryItem, PatientHistoryItemDto>(item);
    }

    public async Task<PagedResultDto<PatientHistoryItemDto>> GetListAsync(PatientHistoryItemFilterDto input)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var queryable = await _historyRepository.GetQueryableAsync();
        queryable = queryable.Where(x => x.PatientId == _currentUser.Id.Value);

        if (input.Type.HasValue)
        {
            queryable = queryable.Where(x => x.Type == input.Type.Value);
        }

        var totalCount = queryable.Count();
        var items = queryable
            .OrderByDescending(x => x.CreationTime)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToList();

        return new PagedResultDto<PatientHistoryItemDto>(
            totalCount,
            ObjectMapper.Map<List<PatientHistoryItem>, List<PatientHistoryItemDto>>(items)
        );
    }

    public async Task<PatientHistoryItemDto> CreateAsync(CreateUpdatePatientHistoryItemDto input)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var item = new PatientHistoryItem(GuidGenerator.Create())
        {
            PatientId = _currentUser.Id.Value
        };

        ObjectMapper.Map(input, item);
        await _historyRepository.InsertAsync(item);

        return ObjectMapper.Map<PatientHistoryItem, PatientHistoryItemDto>(item);
    }

    public async Task<PatientHistoryItemDto> UpdateAsync(Guid id, CreateUpdatePatientHistoryItemDto input)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var item = await _historyRepository.GetAsync(id);
        
        if (item.PatientId != _currentUser.Id.Value)
        {
            throw new UnauthorizedAccessException("You can only update your own history items.");
        }

        ObjectMapper.Map(input, item);
        await _historyRepository.UpdateAsync(item);

        return ObjectMapper.Map<PatientHistoryItem, PatientHistoryItemDto>(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (_currentUser.Id == null)
        {
            throw new UnauthorizedAccessException();
        }

        var item = await _historyRepository.GetAsync(id);
        
        if (item.PatientId != _currentUser.Id.Value)
        {
            throw new UnauthorizedAccessException("You can only delete your own history items.");
        }

        await _historyRepository.DeleteAsync(id);
    }
}

