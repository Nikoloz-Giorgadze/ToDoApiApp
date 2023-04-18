using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;

namespace ToDoApi.Services.ToDoService.Request;

public class ToDoStatusModel
{
    public StatusEnum Status { get; set; }
}
