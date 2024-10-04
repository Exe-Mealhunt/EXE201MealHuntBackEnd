using MealHunt_Repositories.Data;
using MealHunt_Repositories.Interfaces;
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

    
}
