using AutoMapper;
using MealHunt_Repositories;
using MealHunt_Repositories.Interfaces;
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

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));
            try
            {
                //var user = _mapper.Map<User>(request);
                var user = new User
                {
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    Role = "User",
                    Status = 1
                };
                await _userRepository.AddUser(user);

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
