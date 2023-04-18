using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoApi.Services.SubtaskService;
using ToDoApi.Services.SubtaskService.Request;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubtaskController : ControllerBase
    {
        private readonly ISubtaskService _service;

        public SubtaskController(ISubtaskService service)
        {
            _service = service;
        }
        private int GetOwnerId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubtaskCreateRequestModel model)
        {
            int ownerId = GetOwnerId();
            var id = await _service.Create(ownerId, model);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int toDoId)
        {
            int ownerId = GetOwnerId();
            var result = await _service.GetAll(ownerId, toDoId);
            return Ok(result);
        }
    }
}
