using Xunit;

namespace ABShealthcard.EntityFrameworkCore;

[CollectionDefinition(ABShealthcardTestConsts.CollectionDefinitionName)]
public class ABShealthcardEntityFrameworkCoreCollection : ICollectionFixture<ABShealthcardEntityFrameworkCoreFixture>
{

}
