using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;
using ToDoApi.Domain.ToDos;

namespace ToDoApi.Infrastructure.Repsoitory.ToDoRepository;

public interface IToDoRepository
{
    Task<int> Create(ToDo toDo);
    Task<List<ToDo>> GetAll(int ownerId,StatusEnum? statusFilter);
    Task<ToDo> Get(int ownerId, int id);
    ToDo Update(ToDo toDo);
    Task SaveChanges();
}
