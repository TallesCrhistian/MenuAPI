using Microsoft.OpenApi.Models;

namespace MenuAPI.API
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration iConfiguration)
        {
            //services.AddDbContext<AppDbContext>(x => x.UseNpgsql(iConfiguration.GetConnectionString("DefaultConnection"))
            //    .EnableSensitiveDataLogging()
            //    .LogTo(Console.WriteLine, LogLevel.Information));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection WorkUnit(this IServiceCollection services)
        {
            return services;
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Menu.Api",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                                Enter 'Bearer' [space] and then your token in the text input below. 
                                Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });
            });
        }
    }
}
