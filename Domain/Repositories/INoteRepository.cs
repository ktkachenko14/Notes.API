using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;

namespace Notes.API.Domain.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> ListAsync();
        void Remove(Note note);
        Task<Note> FindByIdAsync(int id);
        Task AddAsync(Note note);
        void Update(Note note);

    }
}