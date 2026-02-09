using ABShealthcard.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ABShealthcard.Blazor.Client;

public abstract class ABShealthcardComponentBase : AbpComponentBase
{
    protected ABShealthcardComponentBase()
    {
        LocalizationResource = typeof(ABShealthcardResource);
    }
}
