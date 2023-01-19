using Microsoft.AspNetCore.Identity;
using SleekFlowTodo.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SleekFlowTodo.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public enStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        [ForeignKey("User")]
        [MaxLength(450)]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
