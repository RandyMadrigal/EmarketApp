using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace EmarketApp.Core.Application
{
    public static class ServiceRegistration
    {

        //Extension Method ** Decorator
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            /*Inyeccion de dependencia al startup
                  Inteface - quien la implementa*/
            #region Services

            services.AddTransient<IAnuncioService, AnuncioService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
           
            #endregion


        }
    }
}
