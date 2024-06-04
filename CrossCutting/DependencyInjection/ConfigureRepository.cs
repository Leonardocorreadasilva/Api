using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollecion)
        {

            serviceCollecion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            var connectionString = "Server=localhost; Port=3306;Database=dbAPI;Uid=root;Pwd=root";

            serviceCollecion.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)) );
        }
    }
}
