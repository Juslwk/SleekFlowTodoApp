using SleekFlowTodo.Entities;
using SleekFlowTodo.Services.Dtos;

namespace SleekFlowTodo.Services
{
    public interface ITodoService
    {
        Task CreateAsync(Todo newTodo);
        Task DeleteAsync(Todo todo);
        Task<List<Todo>> GetAllAsync(string userId);
        Task<Todo> GetAsync(int id, string userId);
        Task UpdateAsync(int id, Todo item);
    }
}