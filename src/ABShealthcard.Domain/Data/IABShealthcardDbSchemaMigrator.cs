using System.Threading.Tasks;

namespace ABShealthcard.Data;

public interface IABShealthcardDbSchemaMigrator
{
    Task MigrateAsync();
}
