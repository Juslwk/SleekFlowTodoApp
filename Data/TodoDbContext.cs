using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SleekFlowTodo.Entities;

namespace SleekFlowTodo.Data
{
    public class TodoDbContext : IdentityUserContext<IdentityUser>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }
    }
}
