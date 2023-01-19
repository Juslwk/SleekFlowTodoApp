using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SleekFlowTodo.Data;
using SleekFlowTodo.Entities;
using SleekFlowTodo.Services.Dtos;

namespace SleekFlowTodo.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;
        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync(string userId)
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task DeleteAsync(Todo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetAsync(int id, string userId)
        {
            var todo = await _context.Todos
                .Where(todo => todo.UserId == userId && todo.Id == id)
                .FirstOrDefaultAsync();
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task UpdateAsync(int id, Todo item)
        {
            var todo = await _context.Todos.FindAsync(id);

            todo.Name = item.Name;
            todo.Description = item.Description;
            todo.Status = item.Status;
            todo.DueDate = item.DueDate;
            todo.UpdateTime = DateTime.UtcNow;

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Todo newTodo)
        {
            _context.Todos.Add(newTodo);
            await _context.SaveChangesAsync();
        }
    }
}
