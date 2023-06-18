using Demo.UI.OrderDetails;
using Demo.UI.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Demo.UI.Orders
{
    public class OrderAppService : 
        CrudAppService<
            Order,
            OrderDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateOrderDto> , IOrderAppService
    {
        private readonly IRepository<OrderDetail> _orderdetailsRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        public OrderAppService(IRepository<Order, Guid> repository,
             IRepository<OrderDetail> orderdetailsRepository,
             IRepository<Product, Guid> productRepository)
        : base(repository)
        {
            _orderdetailsRepository = orderdetailsRepository;
            _productRepository = productRepository;
        }

        public override async Task<OrderDto> CreateAsync (CreateUpdateOrderDto input)
        {
            var orderId = Guid.NewGuid();
            var order = new Order(orderId)
            {
                OrderNumber = input.OrderNumber,
                OrderDate = DateTime.Now,
                InvoiceNote = input.InvoiceNote,
                InvoiceNumber = input.InvoiceNumber,
                DeliveryStaff = input.DeliveryStaff,
                DeliveryUnit = input.DeliveryUnit,
                DistributorCode = input.DistributorCode,
                DistributorName = input.DistributorName,
                Remark = input.Remark,
                CustomerID = input.CustomerID,
                CustomerName = input.CustomerName,
                CustomerAddress = input.CustomerAddress,
                Quanity = input.Quanity,
                Total = input.Total,
                RewardAmount = input.RewardAmount,
                Tax = input.Tax,
                Discount = input.Discount,
                TotalAmount = input.TotalAmount,
                TotalItem = input.TotalItem,
                OrderStatus = input.OrderStatus,
                OrderType = input.OrderType,
                Handle = input.Handle,
                PaymentMethod = input.PaymentMethod
            };
            var items = new List<OrderDetail>();
            foreach (var item in input.orderDetails)
            {
                var product = await _productRepository.GetAsync(item.ProductID);
                items.Add(new OrderDetail()
                {
                    OrderID = orderId,
                    ProductID = item.ProductID,
                    Price = item.Price,
                    Quantity = item.Quantity,
                });
            }
            await _orderdetailsRepository.InsertManyAsync(items);
            var result = await Repository.InsertAsync(order);                          
            return ObjectMapper.Map<Order, OrderDto>(result);
        }

       
        public async Task<List<ProductDto>> GetListAllProductAsync(Guid id)
        {
            var orderDetails = await _orderdetailsRepository.GetListAsync(x=> x.OrderID == id);

           List<ProductDto> productsDto = new List<ProductDto>();
           
            foreach (var item in orderDetails)
            {
                Product product = await _productRepository.GetAsync(x => x.Id == item.ProductID);

                var productDto = ObjectMapper.Map<Product, ProductDto>(product);

                productsDto.Add(productDto);
            }

            return productsDto;


        }
    }
}
