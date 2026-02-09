using ABShealthcard.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ABShealthcard.Permissions;

public class ABShealthcardPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ABShealthcardPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ABShealthcardPermissions.MyPermission1, L("Permission:MyPermission1"));

        var patientGroup = context.AddGroup(ABShealthcardPermissions.Patient.Default, L("Permission:Patient"));
        patientGroup.AddPermission(ABShealthcardPermissions.Patient.ProfileView, L("Permission:Patient.Profile.View"));
        patientGroup.AddPermission(ABShealthcardPermissions.Patient.ProfileEdit, L("Permission:Patient.Profile.Edit"));
        patientGroup.AddPermission(ABShealthcardPermissions.Patient.HistoryManage, L("Permission:Patient.History.Manage"));
        patientGroup.AddPermission(ABShealthcardPermissions.Patient.MedicationsManage, L("Permission:Patient.Medications.Manage"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ABShealthcardResource>(name);
    }
}
