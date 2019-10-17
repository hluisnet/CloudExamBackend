using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudExam.Services
{
    public static class DependencyRegistry
    {
        public static IServiceCollection ConfigureServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IDashboardService, DashboardService>();
            return services;
        }
    }
}
