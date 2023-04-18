using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;
using ToDoApi.Domain.ToDos;

namespace ToDoApi.Domain.Subtasks;

public class Subtask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime TargetCompilationDate { get; set; }
    public StatusEnum Status { get; set; }
    public int ToDoItemId { get; set; }
    public ToDo ParentToDo { get; set; }
}
