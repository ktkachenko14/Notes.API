using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Notes.API.Domain.Models
{
    public class User{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
       
        public ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();

        
    }
}