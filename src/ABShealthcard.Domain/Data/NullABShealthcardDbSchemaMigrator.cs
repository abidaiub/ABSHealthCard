using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ABShealthcard.Data;

/* This is used if database provider does't define
 * IABShealthcardDbSchemaMigrator implementation.
 */
public class NullABShealthcardDbSchemaMigrator : IABShealthcardDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
