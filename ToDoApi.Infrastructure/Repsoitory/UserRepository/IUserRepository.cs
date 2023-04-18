using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Users;

namespace ToDoApi.Infrastructure.Repsoitory.UserRepository;

public interface IUserRepository
{
    Task<int> Create(User user);
    Task<bool> Exist(string username);
    Task<User> Get(string username, string password);
}
