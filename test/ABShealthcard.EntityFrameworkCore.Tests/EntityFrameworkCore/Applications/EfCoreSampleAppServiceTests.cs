using ABShealthcard.Samples;
using Xunit;

namespace ABShealthcard.EntityFrameworkCore.Applications;

[Collection(ABShealthcardTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ABShealthcardEntityFrameworkCoreTestModule>
{

}
