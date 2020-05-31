using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Domain.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> ListAsync();
        Task<RoleResponse> DeleteAsync(int id);
        Task<RoleResponse> SaveAsync(Role role);
        Task<RoleResponse> UpdateAsync(int id, Role role);
    }
}