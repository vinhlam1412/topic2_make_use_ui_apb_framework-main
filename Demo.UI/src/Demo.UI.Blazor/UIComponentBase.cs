using Demo.UI.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Demo.UI.Blazor;

public abstract class UIComponentBase : AbpComponentBase
{
    protected UIComponentBase()
    {
        LocalizationResource = typeof(UIResource);
    }
}
