using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;
using ToDoApi.Services.SubtaskService.Request;

namespace ToDoApi.Services.ToDoService.Request;

public class ToDoResponseModel
{
    public string Title { get; set; }
    public DateTime TargetCompilationDate { get; set; }
    public StatusEnum Status { get; set; }
    public List<SubtaskResponseModel> Subtasks { get; set; }
}
