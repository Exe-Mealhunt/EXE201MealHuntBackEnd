using AutoMapper;
using MealHunt_Repositories;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.CustomModels.ResponseModels;
using MealHunt_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            try
            {
                // Check is user is existed in the system
                var user = await _userManager.FindByNameAsync(request.Email);
                if (user == null)
                {
                    throw new Exception("Your email is not exist in the system!");
                }

                // Check password of user if it existed
                if(!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    throw new Exception("Your password is not correct!");
                }

                var response = _mapper.Map<LoginResponse>(user);

                // Generate jwt access token
                response.AccessToken = GenerateAccessTokenString(user);
                return response;   
            }
            catch
            {
                throw;
            }
        }

        public async Task<dynamic> Register(RegisterRequest request)
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
                user.UserName = request.Email;
                //await _userRepository.AddUser(user);

                // Add new user with identity
                var createdUser = await _userManager.CreateAsync(user, request.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, request.Role);

                    if (!roleResult.Succeeded)
                    {
                        return roleResult.Errors;
                    }
                }
                else
                {
                    return createdUser.Errors;
                }

                // Map to response
                var response = _mapper.Map<RegisterResponse>(user);
                return response;
            }
            catch
            {
                throw;
            }
        }

        private string GenerateAccessTokenString(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("username", user.UserName),
                new Claim("role", user.Role)
            };

            var staticKey = _configuration["JWT:SigningKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(staticKey));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCred
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
