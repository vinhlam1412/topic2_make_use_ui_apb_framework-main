using Demo.UI.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Demo.UI;

[DependsOn(
    typeof(UIEntityFrameworkCoreTestModule)
    )]
public class UIDomainTestModule : AbpModule
{

}
