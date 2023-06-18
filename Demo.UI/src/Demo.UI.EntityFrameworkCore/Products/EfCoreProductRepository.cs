using Demo.UI.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Demo.UI.Products
{
    public class EfCoreProductRepository : EfCoreRepository<UIDbContext, Product, Guid>, IProductRepository
    {
        public EfCoreProductRepository(IDbContextProvider<UIDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Product> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            Product product = await dbSet.FirstOrDefaultAsync(product => product.ProductID.Contains(name));
            return product;
        }
    }
}
