using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Repositories;
using Notes.API.Domain.Services;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserRoleService(IRoleRepository roleRepository,
                               IUserRepository userRepository,
                               IUnitOfWork unitOfWork)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<UserResponse> DeleteRoleAsync(int userId, int roleId)
        {
            try
            {
                User user = await userRepository.FindByIdAsync(userId);
                user.UserRole.Remove(user.UserRole.SingleOrDefault(x => x.RoleId == roleId));
                await unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occured with deleting role: {ex.Message}");
            }

        }

        public async Task<IEnumerable<User>> ListUsersByRoleAsync(int roleId)
        {
            var users = await userRepository.ListAsync();
            var usersInRole = users.Where(x => x.UserRole.Contains(x.UserRole.SingleOrDefault(y => y.RoleId == roleId)));
            return usersInRole;
        }

        public async Task<UserResponse> SetUserRoleAsync(int userId, int roleId)
        {
            try
            {
                User user = await userRepository.FindByIdAsync(userId);
                user.UserRole.Add(new UserRole { UserId = userId, RoleId = roleId });
                await unitOfWork.CompleteAsync();
                user = await userRepository.FindByIdAsync(userId);
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occuren when setting the role: {ex.Message}");
            }

        }


    }
}