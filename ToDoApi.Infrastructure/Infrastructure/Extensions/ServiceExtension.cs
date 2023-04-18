using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Infrastructure.Repsoitory.SubtaskRepository;
using ToDoApi.Infrastructure.Repsoitory.ToDoRepository;
using ToDoApi.Infrastructure.Repsoitory.UserRepository;

namespace ToDoApi.Infrastructure.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IToDoRepository, ToDoRopsitory>();
        services.AddScoped<ISubtaskRepository, SubtaskRepository>();

        return services;
    }
}
