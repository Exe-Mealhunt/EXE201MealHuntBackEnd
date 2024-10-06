using AutoMapper;
using MealHunt_Repositories;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            try
            {
                var user = await _userRepository.GetUserByEmail(request.Email);
                if(user == null)
                {
                    throw new Exception("Your email is not exist in the system!");
                }
                var userModel = _mapper.Map<UserModel>(user);
                if (!userModel.Password.Equals(request.Password))
                {
                    throw new Exception("Your password is invalid!");
                }
                var response = _mapper.Map<LoginResponse>(userModel);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));
            try
            {
                // Check if email is existed
                var existedUser = await _userRepository.GetUserByEmail(request.Email);
                if (existedUser != null)
                {
                    throw new Exception($"{request.Email} is already existed!");
                }

                // Save new user
                var user = _mapper.Map<User>(request);
                await _userRepository.AddUser(user);

                // Map to response
                var response = _mapper.Map<RegisterResponse>(user);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
