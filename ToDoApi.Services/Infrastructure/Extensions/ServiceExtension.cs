using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Services.SubtaskService;
using ToDoApi.Services.ToDoService;
using ToDoApi.Services.UserService;

namespace ToDoApi.Services.Infrastructure.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService.UserService>();
        services.AddScoped<IToDoservice, ToDoService.ToDoService>();
        services.AddScoped<ISubtaskService, SubtaskService.SubtaskService>();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
