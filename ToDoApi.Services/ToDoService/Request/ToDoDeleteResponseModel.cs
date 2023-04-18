using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;

namespace ToDoApi.Services.ToDoService.Request;

public class ToDoDeleteResponseModel
{
    public string Title { get; set; }
    public DateTime TargetCompilationDate { get; set; }
    public StatusEnum Status { get; set; }
}
