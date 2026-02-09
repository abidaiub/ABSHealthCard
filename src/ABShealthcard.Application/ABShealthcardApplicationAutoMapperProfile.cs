using ABShealthcard.Patients;
using AutoMapper;

namespace ABShealthcard;

public class ABShealthcardApplicationAutoMapperProfile : Profile
{
    public ABShealthcardApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        
        CreateMap<PatientProfile, PatientProfileDto>();
        CreateMap<CreateUpdatePatientProfileDto, PatientProfile>();
        
        CreateMap<PatientHistoryItem, PatientHistoryItemDto>();
        CreateMap<CreateUpdatePatientHistoryItemDto, PatientHistoryItem>();
        
        CreateMap<PatientMedication, PatientMedicationDto>();
        CreateMap<CreateUpdatePatientMedicationDto, PatientMedication>();
    }
}
