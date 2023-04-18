using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Services.ToDoService.Request;

namespace ToDoApi.Services.ToDoService;

public interface IToDoservice
{
    Task<int> Create(int ownerId, ToDoModel model);
    Task<List<ToDoGetAllResponseModel>> GetAll(int ownerId, Domain.Enums.StatusEnum? statusFilter);
    Task<ToDoResponseModel> Get(int ownerId, int id);
    Task<ToDoResponseModel> Update(int ownerId, int id, ToDoModel model);
    Task<ToDoResponseModel> UpdateStatus(int ownerId, int id, ToDoStatusModel model);
    Task<ToDoDeleteResponseModel> Delete(int ownerId, int id);
}
