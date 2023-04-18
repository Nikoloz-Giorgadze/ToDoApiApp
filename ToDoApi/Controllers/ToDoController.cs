using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoApi.Domain.Enums;
using ToDoApi.Services.ToDoService;
using ToDoApi.Services.ToDoService.Request;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoservice _service;

        public ToDoController(IToDoservice service)
        {
            _service = service;
        }
        private int GetOwnerId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ToDoModel model)
        {
            int ownerId = GetOwnerId();
            int id = await _service.Create(ownerId, model);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(StatusEnum? statusfilter = null)
        {
            int ownerId = GetOwnerId();
            var result = await _service.GetAll(ownerId, statusfilter);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            int ownerId = GetOwnerId();
            var result = await _service.Get(ownerId, id);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, ToDoModel model)
        {
            int ownerId = GetOwnerId();
            var result = await _service.Update(ownerId, id, model);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpPut("Status{id}")]
        public async Task<IActionResult> UpdateStatus(int id, ToDoStatusModel model)
        {
            int ownerId = GetOwnerId();
            var result = await _service.UpdateStatus(ownerId, id, model);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            int ownerId = GetOwnerId();
            var result = await _service.Delete(ownerId, id);
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}
