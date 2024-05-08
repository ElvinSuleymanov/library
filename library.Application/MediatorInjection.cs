using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace library.Application;

public static class MediatorInjection
{
    public static IServiceCollection AddMediator(this IServiceCollection services) {
        services.AddMediatR(conf => {
            conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}
