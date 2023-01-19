using System.ComponentModel.DataAnnotations;

namespace SleekFlowTodo.Services.Dtos
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
