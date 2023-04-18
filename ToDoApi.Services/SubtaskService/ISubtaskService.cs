using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Services.SubtaskService.Request;

namespace ToDoApi.Services.SubtaskService;

public interface ISubtaskService
{
    Task<int> Create(int ownerId, SubtaskCreateRequestModel model);
    Task<List<SubtaskResponseModel>> GetAll(int ownerId, int toDoId);
    Task<SubtaskResponseModel> Get(int ownerId, int id);
    Task<SubtaskResponseModel> Update(int ownerId, int id, SubtaskUpdateModel model);
    Task<SubtaskResponseModel> UpdateStatus(int ownerId, int id, SubtaskStatusModel model);
    Task<SubtaskResponseModel> Delete(int ownerId, int id);
}
