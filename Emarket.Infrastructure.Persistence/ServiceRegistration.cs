using Emarket.Infrastructure.Persistence.Contexts;
using Emarket.Infrastructure.Persistence.Repositories;
using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Application.Interfaces.Repositoires;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Emarket.Infrastructure.Persistence
{
    //Se registran todas las inyecciones de dependencias que corresponden a los repositorios y Contexts
    public static class ServiceRegistration
    {

        //Extension Method ** Decorator
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                //Database en memoria
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                //Configuraciones del startup
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"),  
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            /*Inyeccion de dependencia al startup
                  Inteface - quien la implementa*/
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IAnuncioRepository, AnuncioRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IUserRepository, UserRepository>();

            #endregion


        }

    }
}
