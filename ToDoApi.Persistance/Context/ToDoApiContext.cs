using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Subtasks;
using ToDoApi.Domain.ToDos;
using ToDoApi.Domain.Users;

namespace ToDoApi.Persistance.Context;

public class ToDoApiContext : DbContext
{
    public ToDoApiContext(DbContextOptions<ToDoApiContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
    public DbSet<Subtask> Subtasks { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ToDoApiContext).Assembly);
    }

}
