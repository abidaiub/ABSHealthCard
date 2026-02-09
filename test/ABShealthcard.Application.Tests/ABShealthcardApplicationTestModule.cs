using Volo.Abp.Modularity;

namespace ABShealthcard;

[DependsOn(
    typeof(ABShealthcardApplicationModule),
    typeof(ABShealthcardDomainTestModule)
)]
public class ABShealthcardApplicationTestModule : AbpModule
{

}
