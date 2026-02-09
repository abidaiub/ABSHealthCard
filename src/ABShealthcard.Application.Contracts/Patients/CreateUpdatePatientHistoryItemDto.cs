using System;
using System.ComponentModel.DataAnnotations;
using ABShealthcard.Patients;

namespace ABShealthcard.Patients;

public class CreateUpdatePatientHistoryItemDto
{
    public HistoryType Type { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Details { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}


