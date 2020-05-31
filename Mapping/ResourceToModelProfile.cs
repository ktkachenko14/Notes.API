using AutoMapper;
using Notes.API.Domain.Models;
using Notes.API.Resources;

namespace Notes.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
           CreateMap<NoteResource, Note>();
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
           // CreateMap<SaveRoleResource, Role>();
        }
    }
}