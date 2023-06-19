using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebAPI.Filters;
using WebAPI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                            options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddControllersWithViews(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
                    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddRazorPages();


            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            return services;
        }

        public static string AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var corsPolicy = "CorsPolicy";
            var allowedOrigins = configuration.GetValue<string>("AllowedOrigins");
            if (!string.IsNullOrEmpty(allowedOrigins))
            {
                var origins = allowedOrigins.Split(";");
                services.AddCors(options =>
                {
                    options.AddPolicy(name: corsPolicy,
                                      builder =>
                                      {
                                          builder.WithOrigins(origins);
                                          builder.AllowAnyMethod();
                                          builder.AllowAnyHeader();
                                      });
                });
            }
            return corsPolicy;
        }
    }
}