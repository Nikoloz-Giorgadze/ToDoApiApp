using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;
using ToDoApi.Domain.Subtasks;
using ToDoApi.Domain.Users;

namespace ToDoApi.Domain.ToDos;

public class ToDo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime TargetCompilationDate { get; set; }
    public List<Subtask> Subtasks { get; set; }
    public int OwnerId { get; set; }
    public User Owner { get; set; }
}
