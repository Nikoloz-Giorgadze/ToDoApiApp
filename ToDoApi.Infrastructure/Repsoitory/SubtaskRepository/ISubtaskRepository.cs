using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Subtasks;

namespace ToDoApi.Infrastructure.Repsoitory.SubtaskRepository;

public interface ISubtaskRepository
{
    Task<int> Create(Subtask subtask);
    Task<List<Subtask>> GetAll(int ownerId, int toDoId);
    Task<Subtask> Get(int ownerId, int id);
    Subtask Update(Subtask subtask);
    Task SaveChanges();
}
