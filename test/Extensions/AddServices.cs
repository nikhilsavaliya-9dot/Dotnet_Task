using test.IRepositories;
using test.Repositories;
using test.Services;

namespace test.Extensions
{
    public static class AddServices
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            // inject dependenacy

            services.AddScoped<TokenService>();
            services.AddHttpClient(); // Register HttpClientFactory

            // Repository
            services.AddScoped<IAuthRepository, AuthRepository>();

        }
    }
}
