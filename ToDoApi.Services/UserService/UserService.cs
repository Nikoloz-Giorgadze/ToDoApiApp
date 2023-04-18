using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Users;
using ToDoApi.Infrastructure.Repsoitory.UserRepository;
using ToDoApi.Services.UserService.Request;

namespace ToDoApi.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> Register(UserRegisterModel user)
    {
        if (user is null) throw new ArgumentException("Wrong user");
        if (await _repo.Exist(user.Username)) throw new Exception("This username already in use");
        if (user.Password != user.ConfirmPassword) throw new Exception("Incorrect password");

        var userToAdd = user.Adapt<User>();
        userToAdd.Password = CreatePasswordHash(user.Password);
        return await _repo.Create(userToAdd);
    }

    public async Task<User> Login(UserLoginModel user)
    {
        string passwordHash = CreatePasswordHash(user.Password);
        var entity = await _repo.Get(user.Username, passwordHash);
        if (entity is null) throw new Exception("Username or password incorrect");
        return entity;
    }
    private string CreatePasswordHash(string password)
    {
        using (SHA512 hmac = SHA512.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = hmac.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (var ch in hashBytes)
            {
                sb.Append(ch.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
