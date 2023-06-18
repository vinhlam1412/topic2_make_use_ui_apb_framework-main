using Blazorise;
using Demo.UI.Orders;
using Demo.UI.Products;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.AspNetCore.Components.WebAssembly.LeptonXLiteTheme;
using Volo.Abp.ObjectMapping;
using Demo.UI.Products;
using System.Linq;
using Demo.UI.OrderDetails;

namespace Demo.UI.Blazor.Pages.Orders
{
    public partial class NewOrderNumber
    {
        private IReadOnlyList<ProductDto> ProductList { get; set; }
        protected CreateUpdateOrderDto NewEntity = new();
        protected Validations CreateValationRef;
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
        private ProductDto _productFindID;
        protected override async Task OnInitializedAsync()
        {
            productDtoList = new List<ProductDto>();

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
                if(CreateValationRef != null)
                {
                    validate = await CreateValationRef.ValidateAll();
                }
                var productItem = new List<OrderDetailDto>();
                foreach (var item in productDtoList)
                {
                    var idProduct = item.ProductID;
                    var productFindID = await FindProductID(idProduct);
                    productItem.Add(new OrderDetailDto()
                    {
                        ProductID = productFindID.Id,
                        Quantity = item.Quanity,
                        Price = item.SalesPrice
                    });
                }
                if (validate)
                {              
                    var order = await OrderAppService.CreateAsync(new CreateUpdateOrderDto()
                    {
                        OrderNumber = NewEntity.OrderNumber,
                        OrderDate = DateTime.Now,
                        InvoiceNote = NewEntity.InvoiceNote,
                        InvoiceNumber = NewEntity.InvoiceNumber,
                        DeliveryStaff = NewEntity.DeliveryStaff,
                        DeliveryUnit = NewEntity.DeliveryUnit,
                        DistributorCode = NewEntity.DistributorCode,
                        DistributorName = NewEntity.DistributorName,
                        Remark = NewEntity.Remark,
                        CustomerID = NewEntity.CustomerID,
                        CustomerName = NewEntity.CustomerName,
                        CustomerAddress = NewEntity.CustomerAddress,
                        Quanity = NewEntity.Quanity,
                        Total = NewEntity.Total,
                        RewardAmount = NewEntity.RewardAmount,
                        Tax = NewEntity.Tax,
                        Discount = NewEntity.Discount,
                        TotalAmount = NewEntity.TotalAmount,
                        TotalItem = NewEntity.TotalItem,
                        OrderStatus = NewEntity.OrderStatus,
                        OrderType = NewEntity.OrderType,
                        Handle = NewEntity.Handle,
                        PaymentMethod = NewEntity.PaymentMethod,
                        orderDetails = productItem,

                    });
                    NavigationManager.NavigateTo("saleorder");
                }
            }
            catch(Exception ex)
            {
                await HandleErrorAsync(ex);
            }
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
        public async Task<ProductDto> FindProductID(string value)
        {

            _productFindID = await ProductService.GetProductByName(value);

            return _productFindID;
        }

        public void GoToSalePage()
        {
            NavigationManager.NavigateTo("/saleorder");
        }

    }
}
