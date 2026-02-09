using System;
using System.Threading.Tasks;

namespace ABShealthcard.Doctors;

public interface IDoctorAiFeedbackAppService
{
    Task SubmitAsync(Guid patientId, bool isHelpful, string comment);
}
