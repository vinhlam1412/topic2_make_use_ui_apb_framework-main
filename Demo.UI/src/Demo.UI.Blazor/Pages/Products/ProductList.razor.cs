using Blazorise;
using Demo.UI.OrderDetails;
using Demo.UI.Orders;
using Demo.UI.Products;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Blazorise.DataGrid;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace Demo.UI.Blazor.Pages.Products
{
    public partial class ProductList
    {

        private IReadOnlyList<ProductDto> productList { get; set; }
        private ProductDto selectedProduct;
        private List<ProductDto> selectedProducts;

        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; }
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetLisProductAsync();
            await base.OnInitializedAsync();
 
        }

        public async Task GetLisProductAsync()
        {
            var listProduct = await ProductService.GetListProductAsync(
                 new GetListProductDto
                 {
                     MaxResultCount = PageSize,
                     SkipCount = CurrentPage * PageSize,
                     Sorting = CurrentSorting
                 });
            productList = listProduct.Items;
            TotalCount = (int)listProduct.TotalCount;
        }
        private void GoToEditPage(ProductDto product)
        {
            NavigationManager.NavigateTo($"/product/edit/{product.Id}");
        }
        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<ProductDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page - 1;

            await GetLisProductAsync();

            await InvokeAsync(StateHasChanged);
        }

        public async Task DeleteProductSelected()
        {
            foreach( var item in selectedProducts)
            {
                await ProductService.DeleteAsync(item.Id);
            }
            await GetLisProductAsync();
            selectedProducts = new List<ProductDto>();
        }

    }
}
