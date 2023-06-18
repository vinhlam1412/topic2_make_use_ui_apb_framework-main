using Demo.UI.Orders;
using Demo.UI.Products;
using Polly.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Demo.UI
{
    public class OrderDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<Product,Guid> _productRepository;

        public OrderDataSeedContributor(IRepository<Order, Guid> orderRepository, IRepository<Product, Guid> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository= productRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _orderRepository.GetCountAsync() <= 0)
            {
                await _orderRepository.InsertAsync(
                    new Order
                    {
                         OrderNumber = "SO00000271",
                         OrderDate = new DateTime(2023,02,27),
                         InvoiceNumber = "",
                        InvoiceNote = "",
                        DeliveryStaff = "",
                        DeliveryUnit = "",
                        DistributorCode = "DNDN01",
                        DistributorName= "Marketing Da Nang",
                        Remark = "",
                        CustomerID= "DNG000002",
                        CustomerName = "Vinh",
                        CustomerAddress= "HCM",
                        Quanity = 10,
                        Total= 1,
                        RewardAmount = 1,
                        Tax= 2,
                        Discount= 0,
                        TotalItem= 2,
                        TotalAmount= 200000,
                         OrderType = OrderType.InvoiceOrder,
                         //OrderHandle = OrderHandle.None,
                         OrderStatus = OrderStatus.Hold,
                         PaymentMethod = PaymentMethod.Cash
                    },
                    autoSave: true
                  );

                await _orderRepository.InsertAsync(
                    new Order
                    {
                        OrderNumber = "SO00000272",
                        OrderDate = new DateTime(2023, 02, 27),
                        InvoiceNumber = "",
                        InvoiceNote = "",
                        DeliveryStaff = "",
                        DeliveryUnit = "",
                        DistributorCode = "DNDN01",
                        DistributorName = "Marketing Da Nang",
                        Remark = "",
                        CustomerID = "DNG000003",
                        CustomerName = "Khai",
                        CustomerAddress = "HCM",
                        Quanity = 10,
                        Total = 1,
                        RewardAmount = 1,
                        Tax = 2,
                        Discount = 0,
                        TotalItem = 2,
                        TotalAmount = 200000,
                        OrderType = OrderType.VanSales,
                        //OrderHandle = OrderHandle.None,
                        OrderStatus = OrderStatus.Hold,
                        PaymentMethod = PaymentMethod.Cash
                    },
                    autoSave: true
                  );

            }

            if(await _productRepository.GetCountAsync() <= 0)
            {
                await _productRepository.InsertAsync(
                    new Product
                    {
                        ProductID = "APSCH-STA",
                        ProductName = "Snack Que Nhân Phô Mai 7g",
                        Unit = "THUNG",
                        SiteCode = "DNDN01P",
                        Quanity= 1,
                        QRCode = "",
                        SalesPrice = 16000,
                        ExtenedCost = 16000,
                        
                    },
                    autoSave: true
                    );
                await _productRepository.InsertAsync(
                   new Product
                   {
                       ProductID = "CTHT-SSLA",
                       ProductName = "Nước giải khát Mirinda 450ml",
                       Unit = "KET",
                       SiteCode = "DNDN02P",
                       Quanity = 2,
                       QRCode = "",
                       SalesPrice = 8000,
                       ExtenedCost = 7750,

                   },
                   autoSave: true
                   );
                await _productRepository.InsertAsync(
                   new Product
                   {
                       ProductID = "SKHG-BTT",
                       ProductName = "Trà xanh 0 độ 500ml",
                       Unit = "THUNG",
                       SiteCode = "DNDN02P",
                       Quanity = 3,
                       QRCode = "",
                       SalesPrice = 9000,
                       ExtenedCost = 9000,

                   },
                   autoSave: true
                   );
            }
        }
    }
}
