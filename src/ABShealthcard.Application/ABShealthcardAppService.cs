using System;
using System.Collections.Generic;
using System.Text;
using ABShealthcard.Localization;
using Volo.Abp.Application.Services;

namespace ABShealthcard;

/* Inherit your application services from this class.
 */
public abstract class ABShealthcardAppService : ApplicationService
{
    protected ABShealthcardAppService()
    {
        LocalizationResource = typeof(ABShealthcardResource);
    }
}
