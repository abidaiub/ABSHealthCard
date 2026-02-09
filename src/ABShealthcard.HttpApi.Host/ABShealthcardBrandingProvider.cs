using Microsoft.Extensions.Localization;
using ABShealthcard.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ABShealthcard;

[Dependency(ReplaceServices = true)]
public class ABShealthcardBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ABShealthcardResource> _localizer;

    public ABShealthcardBrandingProvider(IStringLocalizer<ABShealthcardResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
