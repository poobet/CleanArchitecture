using Infrastructure.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CacheModule
    {
        public static IServiceCollection AddCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cacheOptions = configuration.GetSection("Cache");
            services.Configure<CacheOptions>(cacheOptions);

            CacheOptions? options = cacheOptions.Get<CacheOptions>();

            services.AddMemoryCache(opt =>
            {
                opt.SizeLimit = options?.InMemory?.SizeLimit;
            });

            var distributedProvider = options?.Distributed?.Provider;

            if (distributedProvider == "InMemory")
            {
                services.AddDistributedMemoryCache(opt =>
                {
                    opt.SizeLimit = options?.Distributed?.InMemory?.SizeLimit;
                });
            }
          

            return services;
        }
    }
}
