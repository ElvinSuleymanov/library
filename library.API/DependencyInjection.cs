using System.Reflection;
using library.Infrastructure;

namespace library.API;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)  {
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddDbContext<ApplicationDbContext>();
        return services;
    }
}
