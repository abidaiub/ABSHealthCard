using Volo.Abp.Modularity;

namespace ABShealthcard;

public abstract class ABShealthcardApplicationTestBase<TStartupModule> : ABShealthcardTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
