using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Services.ToDoService.Request;

public class ToDoModel
{
    public string Title { get; set; }
    public DateTime TargetCompilationDate { get; set; }
}
