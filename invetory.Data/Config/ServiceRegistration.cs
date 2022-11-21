using inventory.Data.Repository.Abstract;
using inventory.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace inventory.Data.Config
{
    public static class ServiceRegistration
    {
        public static void ConfigureDataAccessLayer(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = new ConnectionString(config["ConnectionString"]);
            services.AddSingleton(connectionString);

            services.AddTransient<IproviderRepository, ProviderRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}