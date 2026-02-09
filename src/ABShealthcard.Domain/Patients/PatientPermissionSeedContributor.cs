using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace ABShealthcard.Patients;

public class PatientPermissionSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IPermissionManager _permissionManager;
    private readonly IIdentityRoleRepository _roleRepository;

    public PatientPermissionSeedContributor(
        IPermissionManager permissionManager,
        IIdentityRoleRepository roleRepository)
    {
        _permissionManager = permissionManager;
        _roleRepository = roleRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var patientRole = await _roleRepository.FindByNormalizedNameAsync("PATIENT");
        if (patientRole != null)
        {
            // Grant all Patient permissions to Patient role
            await _permissionManager.SetForRoleAsync(
                patientRole.Name,
                "ABShealthcard.Patient.Profile.View",
                true
            );
            await _permissionManager.SetForRoleAsync(
                patientRole.Name,
                "ABShealthcard.Patient.Profile.Edit",
                true
            );
            await _permissionManager.SetForRoleAsync(
                patientRole.Name,
                "ABShealthcard.Patient.History.Manage",
                true
            );
            await _permissionManager.SetForRoleAsync(
                patientRole.Name,
                "ABShealthcard.Patient.Medications.Manage",
                true
            );
        }
    }
}

