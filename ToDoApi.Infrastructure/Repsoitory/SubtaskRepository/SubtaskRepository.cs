using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Subtasks;
using ToDoApi.Persistance.Context;

namespace ToDoApi.Infrastructure.Repsoitory.SubtaskRepository;

public class SubtaskRepository : ISubtaskRepository
{
    private readonly ToDoApiContext _context;

    public SubtaskRepository(ToDoApiContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Subtask subtask)
    {
        await _context.AddAsync(subtask);
        return subtask.Id;
    }

    public async Task<List<Subtask>> GetAll(int ownerId, int toDoId)
    {
        return await _context.Subtasks.Where(x => x.ParentToDo.OwnerId == ownerId && x.ToDoItemId == toDoId).ToListAsync();
    }
    public async Task<Subtask?> Get(int ownerId, int id)
    {
        return await _context.Subtasks.SingleOrDefaultAsync(x => x.ParentToDo.OwnerId == ownerId && x.Id == id);
    }
    public Subtask Update(Subtask subtask)
    {
        _context.Subtasks.Update(subtask);
        return subtask;
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

}
