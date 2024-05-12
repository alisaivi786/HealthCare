namespace HealthCare.Infrastructure.DI.Services;

public static class GlobalContext
{
    private static IServiceProvider _serviceProvider;
    public static void Initialize(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static T GetService<T>()
    {
        if (_serviceProvider == null)
        {
            throw new InvalidOperationException("Service provider has not been initialized.");
        }

        return _serviceProvider.GetService<T>();
    }
}
