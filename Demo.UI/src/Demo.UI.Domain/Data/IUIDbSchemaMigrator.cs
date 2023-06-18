using System.Threading.Tasks;

namespace Demo.UI.Data;

public interface IUIDbSchemaMigrator
{
    Task MigrateAsync();
}
