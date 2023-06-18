using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Demo.UI.Data;

/* This is used if database provider does't define
 * IUIDbSchemaMigrator implementation.
 */
public class NullUIDbSchemaMigrator : IUIDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
