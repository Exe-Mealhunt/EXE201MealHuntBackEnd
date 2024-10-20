using AutoMapper;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
		_mapper = mapper;
    }

	public async Task AddUser(UserRequest userRequest)
	{
		try
		{
			User user = new()
			{
				FullName = userRequest.FullName,
				Email = userRequest.Email,
				Password = userRequest.Password,
				CreatedAt = DateTime.UtcNow,
				Role = "USER",
			};

			await _userRepository.AddUser(user);
		}
		catch (Exception ex) 
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task DeleteUser(int id)
	{
		try
		{
			await _userRepository.DeleteUser(id);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<UserModel> GetByEmail(string email)
	{
		try
		{
			var user = await _userRepository.GetUserByEmail(email);
			return _mapper.Map<UserModel>(user);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<UserModel> GetById(int id)
	{
		try
		{
			var user = await _userRepository.FindUserById(id);
			return _mapper.Map<UserModel>(user);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
