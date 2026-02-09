using Volo.Abp.Modularity;

namespace ABShealthcard;

/* Inherit from this class for your domain layer tests. */
public abstract class ABShealthcardDomainTestBase<TStartupModule> : ABShealthcardTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
