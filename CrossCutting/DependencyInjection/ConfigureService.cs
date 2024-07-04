using Api.Domain.Interface.Service.Address;
using Api.Domain.Interface.Service.Product;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Service;
using Api.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesService(IServiceCollection serviceCollecion)
        {
            serviceCollecion.AddScoped<IUserService, UserService>();
            serviceCollecion.AddScoped<IAddressService, AddressService>();
            serviceCollecion.AddScoped<IProductService, ProductService>();
            serviceCollecion.AddScoped<IProductCategory, ProductCategoryService>();
            serviceCollecion.AddScoped<IReviewService, ReviewService>();
            serviceCollecion.AddScoped<IItemsService, ItemsService>();
        }
    }
}
