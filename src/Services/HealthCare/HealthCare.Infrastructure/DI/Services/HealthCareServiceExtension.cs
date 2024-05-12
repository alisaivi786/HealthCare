using System.Reflection;

namespace HealthCare.Infrastructure.DI.Services;
public static class HealthCareServiceExtension
{
    public static IServiceCollection AddHealthCareService(this IServiceCollection services)
    {
        AddCommunicationService(services);
        AddDBService(services);
        return services;
    }

    #region AddCommunicationService
    private static void AddCommunicationService(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IUserService, UserService>();
    }
    #endregion

    #region AddDBService
    private static void AddDBService(IServiceCollection services)
    {
        
    }
    #endregion
}
