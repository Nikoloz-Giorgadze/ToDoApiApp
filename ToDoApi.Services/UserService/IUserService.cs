using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Services.UserService.Request;
using ToDoApi.Domain.Users;

namespace ToDoApi.Services.UserService;

public interface IUserService
{
    Task<int> Register(UserRegisterModel user);
    Task<User> Login(UserLoginModel user);
}
