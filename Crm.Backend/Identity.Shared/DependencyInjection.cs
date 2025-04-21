using Identity.Application.Interfaces;
using Identity.Shared.AuthProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddScoped<IJwtToken, JwtToken>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
