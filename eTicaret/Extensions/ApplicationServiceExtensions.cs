using eTicaret.Core.Interfaces;
using eTicaret.Infrastructure.Data;
using eTicaret.Infrastructure.Implements;
using eTicaret.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eTicaret.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
