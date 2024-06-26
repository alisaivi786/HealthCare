﻿using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.API.Middleware;

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
        services.AddHealthCareInfrastructure(configuration);

        #endregion
    }
}
