using Demo.UI.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Demo.UI.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class UIController : AbpControllerBase
{
    protected UIController()
    {
        LocalizationResource = typeof(UIResource);
    }
}
