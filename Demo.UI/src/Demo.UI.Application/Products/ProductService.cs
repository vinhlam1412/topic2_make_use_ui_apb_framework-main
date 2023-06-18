using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Demo.UI.Products
{
    public class ProductService : CrudAppService<
        Product, 
        ProductDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateProductDto>, 
    IProductService 
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IRepository<Product, Guid> repository, IProductRepository productRepository) : base(repository)
        {
            _productRepository= productRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetListProductAsync(GetListProductDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Product.ProductName);
            }

            var products = await _productRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _productRepository.CountAsync()
                : await _productRepository.CountAsync(
                    product => product.ProductName.Contains(input.Filter));

            return new PagedResultDto<ProductDto>(
                totalCount,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );
        }

        public async Task<ProductDto> GetProductByName(string name)
        {
            var products = await _productRepository.FindByNameAsync(name);
            ProductDto productDto = ObjectMapper.Map<Product, ProductDto>(products);
            return productDto;
            //return new Task<ProductDto>(ObjectMapper.Map<Product,ProductDto>(products));
        }





        public override async Task<ProductDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Product> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join Products and authors
            var query = from Product in queryable
                        where Product.Id == id
                        select new { Product };

            //Execute the query and get the Product with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Product), id);
            }

            var ProductDto = ObjectMapper.Map<Product, ProductDto>(queryResult.Product);
            return ProductDto;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Product> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join Products and authors
            var query = from Product in queryable
                        select new { Product };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of ProductDto objects
            var ProductDtos = queryResult.Select(x =>
            {
                var ProductDto = ObjectMapper.Map<Product, ProductDto>(x.Product);
                return ProductDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ProductDto>(
                totalCount,
                ProductDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"Product.{nameof(Product.ProductName)}";
            }

            return $"Product.{sorting}";
        }


    }
}
