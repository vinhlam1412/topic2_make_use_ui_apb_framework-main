using Blazorise;
using Demo.UI.Orders;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using AutoMapper.Internal.Mappers;
using Demo.UI.Products;
using System.Collections.Generic;
using Demo.UI.OrderDetails;

namespace Demo.UI.Blazor.Pages.Orders
{
    public partial class EditOrderNumber
    {

        protected CreateUpdateOrderDto EditingEntity = new();
        protected Validations EditValidationsRef;

        [Parameter]
        public string Id { get; set; }
        public Guid EditingEntityId { get; set; }

        private List<ProductDto> productDtoList;
        string? productId;
        string name;
        string? unit;
        string? Sitecode;
        int quantity;
        string? qrcode;
        double saleprice;
        double extendcost;
        private ProductDto _productDto;
        private ProductDto _productDtoList;
        private ProductDto _productFindID;
        private List<OrderDetailDto> listOrderDetailDto;
        private List<OrderDetailDto> listOrderDetailFind;

        bool FilterVisible = false;
        string columnClass = "10";
        bool remember = true;
        void ToggleFilter()
        {
            FilterVisible = !FilterVisible;
            columnClass = FilterVisible ? "10" : "12";
        }
        private string SelectedOption1 { get; set; }
        private string SelectedOption2 { get; set; }
        private string SelectedOption3 { get; set; }
        private string SelectedOption4 { get; set; }

        private string Option1 { get; set; }
        private string Option2 { get; set; }
        private string Option3 { get; set; }
        private string Option4 { get; set; }

        //Tab
        string selectedTab = "order";

        //protected override async ValueTask SetToolbarItemsAsync()
        //{
        //    Toolbar.AddButton

        //}

        private Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            return Task.CompletedTask;
        }

        public async Task<Task> FindProduct(string value)
        {
            _productDto = await ProductService.GetProductByName(value);
            name = _productDto.ProductName.ToString();
            unit = _productDto.Unit.ToString();
            Sitecode = _productDto.SiteCode;
            quantity = _productDto.Quanity;
            qrcode = _productDto.QRCode;
            saleprice = _productDto.SalesPrice;
            extendcost = _productDto.ExtenedCost;
            return Task.CompletedTask;
        }


        protected override async Task OnInitializedAsync()
        {
          


            productDtoList = new List<ProductDto>();
            
            await base.OnInitializedAsync();

            EditingEntityId = Guid.Parse(Id);

            productDtoList = await OrderAppService.GetListAllProductAsync(EditingEntityId);

            var entityDto = await OrderAppService.GetAsync(EditingEntityId);

            EditingEntity = ObjectMapper.Map<OrderDto, CreateUpdateOrderDto>(entityDto);

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
                    await OrderAppService.UpdateAsync(EditingEntityId, EditingEntity);
                    NavigationManager.NavigateTo("saleorder");
                }
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        

        private async Task DeleteEntityAsync()
        {
            await OrderAppService.DeleteAsync(EditingEntityId);
            NavigationManager.NavigateTo("saleorder");
        }
    }
}
