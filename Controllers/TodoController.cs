using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using SleekFlowTodo.Data;
using SleekFlowTodo.Entities;
using SleekFlowTodo.Services;
using SleekFlowTodo.Services.Dtos;
using System.Security.Claims;

namespace SleekFlowTodo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(
            ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<Todo>>> GetAllAsync()
        {
            var result = await _todoService.GetAllAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Todo>> GetById(int id)
        {
            var todo = await _todoService.GetAsync(id, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrUpdateTodo item)
        {
            var todo = new Todo()
            {
                Name = item.Name,
                Description = item.Description,
                Status = item.Status,
                DueDate = item.DueDate,
                CreationTime = DateTime.UtcNow,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            await _todoService.CreateAsync(todo);

            return CreatedAtRoute("GetTodo", new { id = todo.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateTodo item)
        {
            var todo = await _todoService.GetAsync(id, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = item.Name;
            todo.Description = item.Description;
            todo.Status = item.Status;
            todo.DueDate = item.DueDate;
            todo.UpdateTime = DateTime.UtcNow;
            await _todoService.UpdateAsync(id, todo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var todo = await _todoService.GetAsync(id, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (todo == null)
            {
                return NotFound();
            }

            await _todoService.DeleteAsync(todo);
            return NoContent();
        }
    }
}