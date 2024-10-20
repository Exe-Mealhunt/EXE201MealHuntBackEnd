using MealHunt_Services.BusinessModels;
using MealHunt_Services.CustomModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetById(int id);
        Task<UserModel> GetByEmail(string email);
        Task AddUser(UserRequest user);
        Task DeleteUser(int id);
    }
}
