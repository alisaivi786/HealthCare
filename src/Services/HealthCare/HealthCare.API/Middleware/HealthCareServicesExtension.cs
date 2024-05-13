namespace HealthCare.API.Middleware;

public static class HealthCareServicesExtension
{
    public static void AddHealthCareServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region ....

        services.AddJWTInfrastructure(configuration);
        services.AuthService();
        services.AddHealthCareInfrastructure(configuration);

        #endregion
    }
}
