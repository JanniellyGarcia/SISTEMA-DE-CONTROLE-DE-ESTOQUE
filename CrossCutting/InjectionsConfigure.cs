using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Service;
using System;

namespace CrossCutting
{
    public static class InjectionsConfigure
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //baseEntity
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //User
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            //Product
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IProductService), typeof(ProductService));

            //Company
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(ICompanyService), typeof(CompanyService));

            //Input
            services.AddScoped(typeof(IInputRepository), typeof(InputRepository));
            services.AddScoped(typeof(IInputService), typeof(InputService));

            //Output
            services.AddScoped(typeof(IOutputRepository), typeof(OutputRepository));
            services.AddScoped(typeof(IOutputService), typeof(OutputService));

            //Inventory
            services.AddScoped(typeof(IInventoryRepository), typeof(InventoryRepository));
            services.AddScoped(typeof(IInventoryService), typeof(InventoryService));

        }
    }
}
