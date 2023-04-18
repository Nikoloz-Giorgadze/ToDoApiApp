using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;
using ToDoApi.Domain.ToDos;
using ToDoApi.Persistance.Context;

namespace ToDoApi.Infrastructure.Repsoitory.ToDoRepository;

public class ToDoRopsitory : IToDoRepository
{
    private readonly ToDoApiContext _context;

    public ToDoRopsitory(ToDoApiContext context)
    {
        _context = context;
    }

    public async Task<int> Create(ToDo toDo)
    {
        await _context.AddAsync(toDo);
        return toDo.Id;
    }
    public async Task<List<ToDo>> GetAll(int ownerId, StatusEnum? statusFilter)
    {
        if (statusFilter is null)
            return await _context.ToDos.Where(x => x.OwnerId == ownerId).ToListAsync();
        return await _context.ToDos.Where(x => x.OwnerId == ownerId && x.Status == statusFilter).ToListAsync();
    }
    public async Task<ToDo> Get(int ownerId, int id)
    {
        var entity = await _context.ToDos
            .Include(x => x.Subtasks)
            .FirstOrDefaultAsync(x => x.OwnerId == ownerId && x.Id == id);
        if (entity is null) throw new Exception("This todo doesn't exist");
        return entity;
    }
    public ToDo Update(ToDo toDo)
    {
        _context.ToDos.Update(toDo);
        return toDo;
    }
    public async Task<ToDo> GetStatus(int ownerId, int id)
    {
        var entity = await _context.ToDos.Where(x => x.OwnerId == ownerId && x.Id == id).Include(x => x.Subtasks).SingleOrDefaultAsync();
        if (entity is null) throw new Exception("This todo doesn't exist");
        return entity;
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
