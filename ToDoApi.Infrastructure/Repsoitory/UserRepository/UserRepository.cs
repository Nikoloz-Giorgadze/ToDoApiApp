using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Users;
using ToDoApi.Persistance.Context;

namespace ToDoApi.Infrastructure.Repsoitory.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly ToDoApiContext _context;

    public UserRepository(ToDoApiContext context)
    {
        _context = context;
    }

    public async Task<int> Create(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }
    public async Task<bool> Exist(string username)
    {
        return await _context.Users.AnyAsync(x => x.Username == username);
    }

    public async Task<User> Get(string username, string password)
    {
        var entity = await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);
        if (entity is null) throw new Exception("Username or password doesn't exist");
        return entity;
    }
}
