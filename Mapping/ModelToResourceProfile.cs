using System.Linq;
using AutoMapper;
using Notes.API.Domain.Models;
using Notes.API.Resources;
using Notes.API.Resources.Communication;

namespace Notes.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Note, NoteResource>();
            
            CreateMap<User, UserResource>()
                .ForMember(x => x.UserRole, y => y.MapFrom(s => s.UserRole.Select(z => z.Role.Name)));
            
            CreateMap<Role, RoleResource>();
               
          
            
        }
    }
}