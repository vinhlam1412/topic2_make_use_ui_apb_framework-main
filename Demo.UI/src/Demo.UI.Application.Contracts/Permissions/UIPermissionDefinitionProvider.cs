using Demo.UI.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Demo.UI.Permissions;

public class UIPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UIPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(UIPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UIResource>(name);
    }
}
