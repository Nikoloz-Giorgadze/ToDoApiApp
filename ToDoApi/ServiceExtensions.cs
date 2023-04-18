using ToDoApi.Infrastructure.Infrastructure.Extensions;
using ToDoApi.Services.Infrastructure.Extensions;

namespace ToDoApi;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        return services;
    }
}
