﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Demo.UI.Products
{
    public interface IProductRepository: IRepository<Product, Guid>
    {
        Task<Product> FindByNameAsync(string name);
    }
}
