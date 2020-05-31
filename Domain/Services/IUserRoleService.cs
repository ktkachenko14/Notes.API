using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Domain.Services
{
    public interface IUserRoleService
    {
        Task<UserResponse> DeleteRoleAsync(int userId, int roleId);
        Task<IEnumerable<User>> ListUsersByRoleAsync(int roleId);
        Task<UserResponse> SetUserRoleAsync(int userId, int roleId);
    }
}