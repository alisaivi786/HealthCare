using Common.JWT;
using Common.JWT.Interface;
using Common.JWT.Extensions.DependencyInjection.Middleware;
using Microsoft.Extensions.DependencyInjection;

namespace Test.API.Middleware;

public static class HealthCareServicesExtension
{
    public static void AddHealthCareServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region ....
        var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.AddSingleton<IJwtConfig>(jwtConfig);
        services.AddJWTInfrastructure(jwtConfig);
        services.AuthService();
        // Change Jwt Toke Validator based on Your Project Needs
        services.AddSingleton<IJwtTokenAuth, JwtTokenAuth>();
        // Change AuthClaims Based on Your Project Needs
        services.AddSingleton<IAuthClaim, AuthClaim>();

        #endregion
    }
}
