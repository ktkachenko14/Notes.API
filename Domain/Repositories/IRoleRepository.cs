using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;

namespace Notes.API.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> ListAsync();
        Task AddAsync(Role role);
        Task<Role> FindByIdAsync(int id);
        void Update(Role role);

        void Remove(Role role);
    }
}