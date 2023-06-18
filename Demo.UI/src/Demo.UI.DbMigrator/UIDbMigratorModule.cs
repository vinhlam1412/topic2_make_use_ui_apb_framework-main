using Demo.UI.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Demo.UI.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UIEntityFrameworkCoreModule),
    typeof(UIApplicationContractsModule)
    )]
public class UIDbMigratorModule : AbpModule
{

}
