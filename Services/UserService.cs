using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.API.Domain.Models;
using Notes.API.Domain.Repositories;
using Notes.API.Domain.Services;
using Notes.API.Domain.Services.Communication;

namespace Notes.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await userRepository.FindByIdAsync(id);
            if (existingUser == null)
                return new UserResponse("User not found");

            try
            {
                userRepository.Remove(existingUser);
                await unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Error when deleting user: {ex.Message}");
            }

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try 
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Error occured when saving user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser  = await userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Password = user.Password;

            try
            {
                userRepository.Update(existingUser);
                await unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"User update error: {ex.Message}");
            }
        }
    }
}