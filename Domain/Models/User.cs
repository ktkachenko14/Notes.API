using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Notes.API.Domain.Models
{
    public class User{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Не верный e-mail")]
        public string Email { get; set; }

        [Remote(action: "CheckLogin", controller: "Users", ErrorMessage ="Логин уже используется")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Не указан пароль")]
        [StringLength(maximumLength: 15, MinimumLength = 5, ErrorMessage = "Пароль должен содержать от 5 до 15 символов")]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Image { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
        
        public ICollection<UserRole> UserRole { get; set; } = new List<UserRole>();
        
        [NotMapped]
        public string Token { get; set; }
        
    }
}