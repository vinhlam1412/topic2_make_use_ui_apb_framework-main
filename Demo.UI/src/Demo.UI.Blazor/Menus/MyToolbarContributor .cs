using Demo.UI.Blazor.Component;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Demo.UI.Blazor.Menus
{
    public class MyToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(Notification)));
              
                //context.Toolbar.Items.RemoveAt(0);
            }

            return Task.CompletedTask;
        }
    }
}
