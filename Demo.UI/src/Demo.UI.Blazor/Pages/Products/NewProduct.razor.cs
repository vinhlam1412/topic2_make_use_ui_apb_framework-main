using Blazorise;
using Demo.UI.Products;
using System.Threading.Tasks;
using System;

namespace Demo.UI.Blazor.Pages.Products
{
    public partial class NewProduct
    {
        protected CreateUpdateProductDto NewEntity = new();
        protected Validations CreateValationRef;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (CreateValationRef != null)
            {
                await CreateValationRef.ClearAll();
            }
        }

        protected virtual async Task CreateEntityAsync()
        {
            try
            {
                var validate = true;
                if (CreateValationRef != null)
                {
                    validate = await CreateValationRef.ValidateAll();
                }
                if (validate)
                {
                    await ProductService.CreateAsync(NewEntity);

                    NavigationManager.NavigateTo("products");
                }
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }
     
        private void GoToProduct()
        {
            NavigationManager.NavigateTo("products");
        }
    }
}
