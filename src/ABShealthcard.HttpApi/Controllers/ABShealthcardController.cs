using ABShealthcard.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ABShealthcard.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ABShealthcardController : AbpControllerBase
{
    protected ABShealthcardController()
    {
        LocalizationResource = typeof(ABShealthcardResource);
    }
}
