using Microsoft.AspNetCore.Identity;
using SleekFlowTodo.Services.Dtos;

namespace SleekFlowTodo.Services
{
    public interface ITokenService
    {
        AuthenticationResponse CreateToken(IdentityUser user);
    }
}