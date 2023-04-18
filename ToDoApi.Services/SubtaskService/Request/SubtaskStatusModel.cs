using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;

namespace ToDoApi.Services.SubtaskService.Request;

public class SubtaskStatusModel
{
    public StatusEnum Status { get; set; }
}
