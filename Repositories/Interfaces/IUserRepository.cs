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

        Task<User?> GetUserByUsername(string username);

        Task<User?> GetUserByEmail(string email);
    }
}
