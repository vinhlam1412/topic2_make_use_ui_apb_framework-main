using Volo.Abp.Modularity;

namespace Demo.UI;

[DependsOn(
    typeof(UIApplicationModule),
    typeof(UIDomainTestModule)
    )]
public class UIApplicationTestModule : AbpModule
{

}
