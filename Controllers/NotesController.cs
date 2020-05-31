using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Notes.API.Persistence.Context;
using Notes.API.Resources.Communication;
using AutoMapper;
using Notes.API.Resources;
using Notes.API.Extensions;


namespace Notes.API.Controllers
{
    [Route("/api/[controller]")]
    public class NotesController : Controller
    {
       private readonly INoteService noteService;
       private readonly IMapper mapper;
       public NotesController(INoteService noteService, IMapper mapper)
       {
           this.noteService = noteService;
           this.mapper = mapper;
       }

        [HttpGet]
        public async Task<ResponseResult> GetAllAsync()
       {
            var notes = await noteService.ListAsync();
            var resources = mapper.Map<IEnumerable<Note>, IEnumerable<NoteResource>>(notes);
            var result = new ResponseResult
            {
                Data = resources,
                Message = "",
                Success = true
            };
            return result;
       }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            var noteResponse = await noteService.DeleteAsync(id);
            var noteResource = mapper.Map<Note, NoteResource>(noteResponse.Task);
            var result = noteResponse.GetResponseResult(noteResource);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveNoteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var note = mapper.Map<SaveNoteResource, Note>(resource);
            var noteResponse = await noteService.UpdateAsync(id, note);
            var noteResource = mapper.Map<Note, NoteResource>(noteResponse.Task);
            var result = noteResponse.GetResponseResult(noteResource);
            return Ok(result);
        }
    }
}