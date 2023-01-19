using System.ComponentModel.DataAnnotations;

namespace SleekFlowTodo.Services.Dtos
{
    public class CreateUserRequest 
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

