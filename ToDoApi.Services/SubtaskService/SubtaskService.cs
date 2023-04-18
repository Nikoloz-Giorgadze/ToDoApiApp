using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Subtasks;
using ToDoApi.Infrastructure.Repsoitory.SubtaskRepository;
using ToDoApi.Services.SubtaskService.Request;
using ToDoApi.Services.ToDoService;

namespace ToDoApi.Services.SubtaskService;

public class SubtaskService : ISubtaskService
{
    private readonly ISubtaskRepository _repo;
    private readonly IToDoservice _toDo;

    public SubtaskService(ISubtaskRepository repo, IToDoservice toDo)
    {
        _repo = repo;
        _toDo = toDo;
    }

    public async Task<int> Create(int ownerId, SubtaskCreateRequestModel model)
    {
        if (model is null) throw new ArgumentException("Wrong model");
        if (model.Title is null) throw new Exception("Wrong title");
        var subtaskId = await _toDo.Get(ownerId, model.ToDoItemId);
        if (subtaskId is null) throw new Exception("Can't find todo by that id or doesn't belongs to you");
        var subtask = model.Adapt<Subtask>();
        await _repo.Create(subtask);
        await _repo.SaveChanges();
        return subtask.Id;
    }
    public async Task<List<SubtaskResponseModel>> GetAll(int ownerId, int toDoId)
    {
        var result = await _repo.GetAll(ownerId, toDoId);
        return result.Adapt<List<SubtaskResponseModel>>();
    }
    public async Task<SubtaskResponseModel> Get(int ownerId, int id)
    {
        var result = await _repo.Get(ownerId, id);
        return result.Adapt<SubtaskResponseModel>();

    }
    public async Task<SubtaskResponseModel> Update(int ownerId, int id, SubtaskUpdateModel model)
    {
        var subtask = await _repo.Get(ownerId, id);
        if (subtask is null) throw new Exception("This subtas doesn't exists");
        subtask.Title = model.Title;
        _repo.Update(subtask);
        await _repo.SaveChanges();
        return subtask.Adapt<SubtaskResponseModel>();
    }

    public async Task<SubtaskResponseModel> UpdateStatus(int ownerId, int id, SubtaskStatusModel model)
    {
        var subtask = await _repo.Get(ownerId, id);
        if (subtask is null) throw new Exception("This subtask doesn't exists");
        subtask.Status = model.Status;
        _repo.Update(subtask);
        await _repo.SaveChanges();
        return subtask.Adapt<SubtaskResponseModel>();
    }
    public async Task<SubtaskResponseModel> Delete(int ownerId, int id)
    {
        var subtask = await _repo.Get(ownerId, id);
        if (subtask is null) throw new Exception("This subtask doesn't exists");
        subtask.Status = Domain.Enums.StatusEnum.Deleted;
        await _repo.SaveChanges();
        return subtask.Adapt<SubtaskResponseModel>();
    }
}
