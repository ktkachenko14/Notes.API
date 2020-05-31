using System;

namespace Notes.API.Domain.Models
{
    public enum Priority{
        Low, Medium, High
    }
  
    public class Note{
        public int Id { get; set;}
        public string Title {get; set;}
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DateNote {get; set;}
        public User User { get; set; }
        public int? UserId { get; set; }

    }
}