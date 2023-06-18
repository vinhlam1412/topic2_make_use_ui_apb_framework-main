using Blazorise;
using Demo.UI.OrderDetails;
using Demo.UI.Orders;
using Demo.UI.Products;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Demo.UI.Blazor.Pages.Products
{
    public partial class ProductList
    {

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
 
        }
        private void GoToEditPage(ProductDto product)
        {
            NavigationManager.NavigateTo($"/product/edit/{product.Id}");
        }
 
    }
}
