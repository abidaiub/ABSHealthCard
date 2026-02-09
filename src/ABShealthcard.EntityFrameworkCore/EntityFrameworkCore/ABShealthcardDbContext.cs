using ABShealthcard.Labs;
using ABShealthcard.Patients;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ABShealthcard.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ABShealthcardDbContext :
    AbpDbContext<ABShealthcardDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<PatientProfile> PatientProfiles { get; set; }
    public DbSet<PatientHistoryItem> PatientHistoryItems { get; set; }
    public DbSet<PatientMedication> PatientMedications { get; set; }
    public DbSet<PatientHealthSummary> PatientHealthSummaries { get; set; }
    public DbSet<LabTest> LabTests { get; set; }
    public DbSet<LabTestParameter> LabTestParameters { get; set; }
    public DbSet<PatientLabReport> PatientLabReports { get; set; }
    public DbSet<PatientLabResult> PatientLabResults { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public ABShealthcardDbContext(DbContextOptions<ABShealthcardDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<PatientProfile>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "PatientProfiles", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.Id);
        });

        builder.Entity<PatientHistoryItem>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "PatientHistoryItems", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.PatientId);
            b.HasIndex(x => x.Type);
            b.HasIndex(x => x.StartDate);
            b.HasIndex(x => x.EndDate);
        });

        builder.Entity<PatientMedication>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "PatientMedications", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.PatientId);
            b.HasIndex(x => x.StartDate);
            b.HasIndex(x => x.EndDate);
        });

        builder.Entity<PatientHealthSummary>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "PatientHealthSummaries", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.PatientId);
            b.HasIndex(x => x.LastUpdatedAt);
        });

        builder.Entity<LabTest>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "LabTests", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.Code);
        });

        builder.Entity<LabTestParameter>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "LabTestParameters", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.LabTestId);
        });

        builder.Entity<PatientLabReport>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "PatientLabReports", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.PatientId);
            b.HasIndex(x => x.ReportDate);
        });

        builder.Entity<PatientLabResult>(b =>
        {
            b.ToTable(ABShealthcardConsts.DbTablePrefix + "PatientLabResults", ABShealthcardConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(x => x.PatientLabReportId);
            b.HasIndex(x => x.LabTestId);
            b.HasIndex(x => x.ResultDate);
        });
    }
}
