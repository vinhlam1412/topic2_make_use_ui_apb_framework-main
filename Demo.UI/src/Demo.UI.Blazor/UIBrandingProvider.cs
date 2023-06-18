using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Demo.UI.Blazor;

[Dependency(ReplaceServices = true)]
public class UIBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UI";
}
