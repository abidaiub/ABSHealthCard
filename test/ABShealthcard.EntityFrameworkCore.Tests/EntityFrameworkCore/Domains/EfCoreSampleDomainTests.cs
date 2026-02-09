using ABShealthcard.Samples;
using Xunit;

namespace ABShealthcard.EntityFrameworkCore.Domains;

[Collection(ABShealthcardTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ABShealthcardEntityFrameworkCoreTestModule>
{

}
