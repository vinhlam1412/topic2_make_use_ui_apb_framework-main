using System;
using System.Collections.Generic;
using System.Text;
using Demo.UI.Localization;
using Volo.Abp.Application.Services;

namespace Demo.UI;

/* Inherit your application services from this class.
 */
public abstract class UIAppService : ApplicationService
{
    protected UIAppService()
    {
        LocalizationResource = typeof(UIResource);
    }
}
