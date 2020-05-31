using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Domain.Services
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> ListAsync();
        Task<NoteResponse> DeleteAsync(int id);
        Task<NoteResponse> SaveAsync(Note note);
        Task<NoteResponse> UpdateAsync(int id, Note note);
    }
}