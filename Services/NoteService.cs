using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services;
using Notes.API.Domain.Repositories;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;
        private readonly IUnitOfWork unitOfWork;
        public NoteService(INoteRepository noteRepository, IUnitOfWork unitOfWork)
        {
            this.noteRepository = noteRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<NoteResponse> DeleteAsync(int id)
        {
            var existingNote = await noteRepository.FindByIdAsync(id);
            if (existingNote == null)
                return new NoteResponse("Product not found");

            try
            {
                noteRepository.Remove(existingNote);
                await unitOfWork.CompleteAsync();

                return new NoteResponse(existingNote);
            }
            catch (Exception ex)
            {
                return new NoteResponse($"Error when deleting note: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Note>> ListAsync()
        {
             return await noteRepository.ListAsync();
        }

        public async Task<NoteResponse> SaveAsync(Note note)
        {
            try 
            {
                await noteRepository.AddAsync(note);
                await unitOfWork.CompleteAsync();

                return new NoteResponse(note);
            }
            catch (Exception ex)
            {
                return new NoteResponse($"Error occured when saving note: {ex.Message}");
            }
        }

        public async Task<NoteResponse> UpdateAsync(int id, Note note)
        {
            var existingNote  = await noteRepository.FindByIdAsync(id);

            if (existingNote == null)
                return new NoteResponse("Product not found");

            existingNote.Title = note.Title;

            try
            {
                noteRepository.Update(existingNote);
                await unitOfWork.CompleteAsync();
                return new NoteResponse(existingNote);
            }
            catch (Exception ex)
            {
                return new NoteResponse($"Product update error: {ex.Message}");
            }
        }
    }
}