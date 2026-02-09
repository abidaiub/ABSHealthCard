using Volo.Abp.Modularity;

namespace ABShealthcard;

[DependsOn(
    typeof(ABShealthcardDomainModule),
    typeof(ABShealthcardTestBaseModule)
)]
public class ABShealthcardDomainTestModule : AbpModule
{

}
