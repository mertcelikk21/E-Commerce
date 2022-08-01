using eTicaret.Core.DbModels;
using System.Threading.Tasks;

namespace eTicaret.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrderPaymentIntent(string basketId);
    }
}
