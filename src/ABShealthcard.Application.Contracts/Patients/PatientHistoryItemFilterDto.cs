using ABShealthcard.Patients;
using Volo.Abp.Application.Dtos;

namespace ABShealthcard.Patients;

public class PatientHistoryItemFilterDto : PagedAndSortedResultRequestDto
{
    public HistoryType? Type { get; set; }
}


