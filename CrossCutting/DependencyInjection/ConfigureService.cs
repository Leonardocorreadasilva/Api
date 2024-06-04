using Api.Domain.Interfaces.Services.User;
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
            serviceCollecion.AddTransient<IUserService, UserService>();
        }
    }
}
