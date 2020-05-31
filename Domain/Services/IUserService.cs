using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> DeleteAsync(int id);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        
    }
}