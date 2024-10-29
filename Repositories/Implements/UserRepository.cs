using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements;

public class UserRepository : IUserRepository
{
    private readonly MealHuntContext _context;

    public UserRepository(MealHuntContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        if(user == null)
        {
            throw new Exception("User is null!");
        }
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

	public async Task DeleteUser(int id)
	{
		if (id <= 0)
		{
			throw new Exception("Id is invalid!");
		}

        try
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("User with this ID was not found.");

			_context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
	}

    public async Task<User?> FindUserById(int id)
    {
        if (id <= 0)
        {
            throw new Exception("Id is invalid!");
        }
        try
        {
            return await _context.Users
                .Include(u => u.UserSubscriptions)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("Email is required!");
        }
        try
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public async Task<bool> IsInOtherPlans(int userId)
    {
        try
        {
            if (!await _context.UserSubscriptions.AnyAsync())
                return false;
            return await _context.UserSubscriptions
                .Where(us => us.UserId == userId)
                .AnyAsync(us => us.IsCurrent == true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);    
        }
    }
}
