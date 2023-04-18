using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Enums;
using ToDoApi.Domain.ToDos;
using ToDoApi.Infrastructure.Repsoitory.ToDoRepository;
using ToDoApi.Services.ToDoService.Request;

namespace ToDoApi.Services.ToDoService;

public class ToDoService : IToDoservice
{
    private readonly IToDoRepository _repo;

    public ToDoService(IToDoRepository repo)
    {
        _repo = repo;
    }
    public async Task<int> Create(int ownerId, ToDoModel model)
    {
        if (model is null) throw new ArgumentException("Wrong model");
        if (model.Title is null) throw new Exception("Title is required!");

        var toDo = model.Adapt<ToDo>();
        toDo.OwnerId = ownerId;
        await _repo.Create(toDo);
        await _repo.SaveChanges();
        return toDo.Id;
    }
    public async Task<List<ToDoGetAllResponseModel>> GetAll(int ownerId, StatusEnum? statusFilter = null)
    {
        if (statusFilter is StatusEnum.Deleted) throw new Exception("Cannot return deleted todos");
        var result = await _repo.GetAll(ownerId, statusFilter);
        return result.Adapt<List<ToDoGetAllResponseModel>>();
    }
    public async Task<ToDoResponseModel> Get(int ownerId, int id)
    {
        var result = await _repo.Get(ownerId, id);
        return result.Adapt<ToDoResponseModel>();
    }
    public async Task<ToDoResponseModel> Update(int ownerId, int id, ToDoModel model)
    {
        var toDo = await _repo.Get(ownerId, id);
        if (toDo is null) throw new Exception("This toDo doesn't exists");

        toDo.Title = model.Title;
        toDo.TargetCompilationDate = model.TargetCompilationDate;
        _repo.Update(toDo);
        await _repo.SaveChanges();
        return toDo.Adapt<ToDoResponseModel>();
    }
    public async Task<ToDoResponseModel> UpdateStatus(int ownerId, int id, ToDoStatusModel model)
    {
        var toDo = await _repo.Get(ownerId, id);
        if (toDo is null) throw new Exception("This toDo doesn't exists");

        toDo.Status = model.Status;
        _repo.Update(toDo);
        await _repo.SaveChanges();
        return toDo.Adapt<ToDoResponseModel>();
    }
    public async Task<ToDoDeleteResponseModel> Delete(int ownerId, int id)
    {
        var toDo = await _repo.Get(ownerId, id);
        if (toDo is null) throw new Exception("This toDo doesn't exists");

        toDo.Status = StatusEnum.Deleted;
        await _repo.SaveChanges();
        return toDo.Adapt<ToDoDeleteResponseModel>();
    }
}
