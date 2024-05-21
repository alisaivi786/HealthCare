namespace Common.JWT.Extensions.DependencyInjection.Middleware;

public static class AuthRegistrarExtension
{
    #region AuthService
    #region Summary
    /// <summary>
    /// AuthService
    /// Developer: ALI RAZA MUSHTAQ
    /// aliraza_mushtaq@outlook.com
    /// </summary>
    /// <param name="services"></param> 
    #endregion
    public static void AuthService(this IServiceCollection services)
    {
        #region ...
        services.AddHttpContextAccessor();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
        services.AddSingleton<IIdentityUser, IdentityUser>();
        services.AddSingleton<IClaimsAccessor, ClaimsAccessor>();

        #endregion
    }
    #endregion
}