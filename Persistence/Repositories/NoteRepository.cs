using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.API.Domain.Models;
using Notes.API.Domain.Repositories;
using Notes.API.Persistence.Context;

namespace Notes.API.Persistence.Repositories
{
    public class NoteRepository : BaseRepository, INoteRepository
    {
        public NoteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Note note)
        {
            await context.Notes.AddAsync(note);
        }

        public async Task<Note> FindByIdAsync(int id)
        {
            return await context.Notes.FindAsync(id);
        }

        public async Task<IEnumerable<Note>> ListAsync()
        {
            return await context.Notes.ToListAsync();
        }

        public void Remove(Note note)
        {
            context.Notes.Remove(note);
        }

        public void Update(Note note)
        {
            context.Notes.Update(note);
        }
    }
}