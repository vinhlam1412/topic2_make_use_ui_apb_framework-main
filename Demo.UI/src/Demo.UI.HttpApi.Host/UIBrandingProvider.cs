using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Demo.UI;

[Dependency(ReplaceServices = true)]
public class UIBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UI";
}
