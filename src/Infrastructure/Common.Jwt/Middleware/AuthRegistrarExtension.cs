namespace Common.Jwt.Middleware;

public static class AuthRegistrarExtension
{
    #region AuthService
    #region Summary
    /// <summary>
    /// AuthService
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 13-May-2024
    /// alisaivi786@gmail.com
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