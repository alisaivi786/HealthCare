namespace Common.Jwt.Middleware;

public static class JWTAuthenticationExtension
{
    #region AddJWTInfrastructure
    #region AddJWTInfrastructure Summary
    /// <summary>
    /// AddJWTInfrastructure
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 13-May-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="services"></param>
    /// <param name="appSettings"></param> 
    #endregion
    public static void AddJWTInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region ....

        var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();

        services.AddSingleton<IJwtConfig>(jwtConfig);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig?.Issuer,
                    ValidAudience = jwtConfig?.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey))
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        // Custom validation logic can be added here if needed
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        // Handle authentication failure
                        return Task.CompletedTask;
                    }
                };
            });
        #endregion
    }
    #endregion
}
