namespace Notes.API.Resources
{
    public class NoteResource : IResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string DateNote {get; set;}
        public UserResource User { get; set; }
    }
}