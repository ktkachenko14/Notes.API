using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Notes.API.Domain.Models;
using Notes.API.Domain.Services;
using Notes.API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Notes.API.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Notes.API.Domain.Services.Communication;
using Notes.API.Extensions;

namespace Notes.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;
        public AuthenticationService(IOptions<AppSettings> appSettings,
                           IUserRepository userRepository)
        {
            this.appSettings = appSettings.Value;
            this.userRepository = userRepository;
        }
        public async Task<UserResponse> AuthenticateAsync(string login, string password)
        {
            User user = (await userRepository.ListAsync())
                            .SingleOrDefault(usr => usr.Login == login && usr.Password == password);

            if (user == null)
                return new UserResponse("Invalid login or password");

            try
            {         
                user.GenerateTokenString(appSettings.Secret, appSettings.TokenExpires);
                user.Password = null;
                return new UserResponse(user);

            }
            catch (Exception ex)
            {
                 return new UserResponse($"An error occured when authenticating user: {ex.Message}");
            }


        }
    }
}