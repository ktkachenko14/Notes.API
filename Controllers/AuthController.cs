using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services;
using Notes.API.Domain.Services.Communication;
using Notes.API.Extensions;
using Notes.API.Resources;
using Notes.API.Resources.Communication;

namespace Notes.API.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService userService;
        private readonly IMapper mapper;
        public AuthController(IAuthenticationService userService,
                              IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            var authenticatedUser = await userService.AuthenticateAsync(user.Login, user.Password);         
            var userResource = mapper.Map<User, UserResource>(authenticatedUser.User);
            var result = authenticatedUser.GetResponseResult(userResource);      
            return Ok(result);
        }
    }
}