using Volo.Abp.Settings;

namespace Demo.UI.Settings;

public class UISettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(UISettings.MySetting1));
    }
}
