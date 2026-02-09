using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABShealthcard.Patients;

public class PatientProfile : AuditedAggregateRoot<Guid>
{
    [Required]
    [StringLength(200)]
    public string FullNameEn { get; set; } = string.Empty;

    [StringLength(200)]
    public string? FullNameBn { get; set; }

    [StringLength(200)]
    public string? FatherNameEn { get; set; }

    [StringLength(200)]
    public string? FatherNameBn { get; set; }

    [StringLength(200)]
    public string? MotherNameEn { get; set; }

    [StringLength(200)]
    public string? MotherNameBn { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public BloodGroup? BloodGroup { get; set; }

    public decimal? HeightCm { get; set; }

    public decimal? WeightKg { get; set; }

    [StringLength(50)]
    public string? NidNo { get; set; }

    [StringLength(50)]
    public string? BirthCertificateNo { get; set; }

    [Required]
    [StringLength(200)]
    public string EmergencyContactName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string EmergencyContactPhone { get; set; } = string.Empty;

    [StringLength(500)]
    public string? AddressEn { get; set; }

    [StringLength(500)]
    public string? AddressBn { get; set; }

    protected PatientProfile()
    {
    }

    public PatientProfile(Guid id) : base(id)
    {
    }
}


