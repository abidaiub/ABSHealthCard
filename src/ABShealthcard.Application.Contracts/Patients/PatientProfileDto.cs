using System;
using ABShealthcard.Patients;
using Volo.Abp.Application.Dtos;

namespace ABShealthcard.Patients;

public class PatientProfileDto : FullAuditedEntityDto<Guid>
{
    public string FullNameEn { get; set; } = string.Empty;
    public string? FullNameBn { get; set; }
    public string? FatherNameEn { get; set; }
    public string? FatherNameBn { get; set; }
    public string? MotherNameEn { get; set; }
    public string? MotherNameBn { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public BloodGroup? BloodGroup { get; set; }
    public decimal? HeightCm { get; set; }
    public decimal? WeightKg { get; set; }
    public string? NidNo { get; set; }
    public string? BirthCertificateNo { get; set; }
    public string EmergencyContactName { get; set; } = string.Empty;
    public string EmergencyContactPhone { get; set; } = string.Empty;
    public string? AddressEn { get; set; }
    public string? AddressBn { get; set; }
}


