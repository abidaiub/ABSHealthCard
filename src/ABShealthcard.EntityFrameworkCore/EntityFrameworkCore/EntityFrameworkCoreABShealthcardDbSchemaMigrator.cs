using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ABShealthcard.Data;
using Volo.Abp.DependencyInjection;

namespace ABShealthcard.EntityFrameworkCore;

public class EntityFrameworkCoreABShealthcardDbSchemaMigrator
    : IABShealthcardDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreABShealthcardDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ABShealthcardDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ABShealthcardDbContext>()
            .Database
            .MigrateAsync();
    }
}
