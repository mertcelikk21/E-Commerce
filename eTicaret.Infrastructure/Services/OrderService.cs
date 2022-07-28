using eTicaret.Core.DbModels;
using eTicaret.Core.DbModels.OrderAggregate;
using eTicaret.Core.Interfaces;
using eTicaret.Core.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicaret.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepo;
        public OrderService(IBasketRepository basketRepo, IUnitOfWork unitOfWork)
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
        }
        public async  Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            var subTotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subTotal);
            _unitOfWork.Repository<Order>().Add(order);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null; //complete bize int değer dönecek>> eğer 0 dönerse başarısız 1 dönerse başarılı işlem olacak

            //delete basket, sipariş sepette kalmayacak, yani eğer yukarıdaki işlem başarılı ise basketi sileceğiz ve ürünler sepette kalmayacak.
            await _basketRepo.DeleteBasketAsync(basketId);
            
            return order;
        }

        public async  Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
        }

        public async  Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}
