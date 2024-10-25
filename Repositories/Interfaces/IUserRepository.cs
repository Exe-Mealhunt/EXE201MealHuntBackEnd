using MealHunt_Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        
        Task<User?> FindUserById(int id);

        Task<User?> GetUserByEmail(string email);

        Task DeleteUser(int id);

        Task<bool> IsInOtherPlans(int userId);
    }
}
