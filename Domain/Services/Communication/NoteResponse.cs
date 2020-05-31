using Notes.API.Domain.Models;

namespace Notes.API.Domain.Services.Communication
{
    public class NoteResponse : BaseResponse
    {
        public Note Task {get; private set;}

        public NoteResponse(bool success, string message, Note note) : base(success, message)
        {
            Task = note;
        }

        public NoteResponse(Note note) : this(true, string.Empty, note) {}
        
        
        public NoteResponse(string message) : this(false, message, null) {}
    }
}