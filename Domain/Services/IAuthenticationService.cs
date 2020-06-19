using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<UserResponse> AuthenticateAsync(string login, string password);
         
    }
}