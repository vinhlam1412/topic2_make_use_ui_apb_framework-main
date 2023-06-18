using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using Blazorise;
using Demo.UI.Orders;
using AutoMapper.Internal.Mappers;
using Demo.UI.Products;

namespace Demo.UI.Blazor.Pages.Products
{
    public partial class EditProduct
    {
        protected CreateUpdateProductDto EditingEntity = new();
        protected Validations EditValidationsRef;

        [Parameter]
        public string Id { get; set; }
        public Guid EditingEntityId { get; set; }


        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();

            EditingEntityId = Guid.Parse(Id);

            var entityDto = await ProductService.GetAsync(EditingEntityId);

            EditingEntity = ObjectMapper.Map<ProductDto, CreateUpdateProductDto>(entityDto);

            if (EditValidationsRef != null)
            {
                await EditValidationsRef.ClearAll();
            }
        }

        protected virtual async Task EditEntityAsync()
        {
            try
            {
                var validate = true;
                if (EditValidationsRef != null)
                {
                    validate = await EditValidationsRef.ValidateAll();
                }
                if (validate)
                {
                    await ProductService.UpdateAsync(EditingEntityId, EditingEntity);
                    NavigationManager.NavigateTo("products");
                }
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }



        private async Task DeleteEntityAsync()
        {
            await ProductService.DeleteAsync(EditingEntityId);
            NavigationManager.NavigateTo("products");
        }
        private void GoToProduct()
        {
            NavigationManager.NavigateTo("products");
        }

       
    }
}
