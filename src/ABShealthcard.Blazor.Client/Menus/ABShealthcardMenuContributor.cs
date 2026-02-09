using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ABShealthcard.Localization;
using ABShealthcard.MultiTenancy;
using ABShealthcard.Permissions;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace ABShealthcard.Blazor.Client.Menus;

public class ABShealthcardMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public ABShealthcardMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ABShealthcardResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ABShealthcardMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home"
            )
        );

        var administration = context.Menu.GetAdministration();

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        // Patient menu
        var patientMenu = new ApplicationMenuItem(
            ABShealthcardMenus.Patient,
            l["Menu:Patient"],
            icon: "fas fa-user-injured"
        );

        patientMenu.AddItem(new ApplicationMenuItem(
            ABShealthcardMenus.PatientDashboard,
            l["Menu:Patient:Dashboard"],
            "/patient/dashboard",
            icon: "fas fa-home"
        ).RequirePermissions(ABShealthcardPermissions.Patient.ProfileView));

        patientMenu.AddItem(new ApplicationMenuItem(
            ABShealthcardMenus.PatientProfile,
            l["Menu:Patient:Profile"],
            "/patient/profile",
            icon: "fas fa-user"
        ).RequirePermissions(ABShealthcardPermissions.Patient.ProfileView));

        patientMenu.AddItem(new ApplicationMenuItem(
            ABShealthcardMenus.PatientHistory,
            l["Menu:Patient:History"],
            "/patient/history",
            icon: "fas fa-history"
        ).RequirePermissions(ABShealthcardPermissions.Patient.HistoryManage));

        patientMenu.AddItem(new ApplicationMenuItem(
            ABShealthcardMenus.PatientMedications,
            l["Menu:Patient:Medications"],
            "/patient/medications",
            icon: "fas fa-pills"
        ).RequirePermissions(ABShealthcardPermissions.Patient.MedicationsManage));

        context.Menu.AddItem(patientMenu);

        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();

        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";

        context.Menu.AddItem(new ApplicationMenuItem(
            "Account.Manage",
            accountStringLocalizer["MyAccount"],
            $"{authServerUrl.EnsureEndsWith('/')}Account/Manage",
            icon: "fa fa-cog",
            order: 1000,
            target: "_blank").RequireAuthenticated());

        return Task.CompletedTask;
    }
}
