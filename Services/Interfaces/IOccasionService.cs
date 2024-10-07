using MealHunt_Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Interfaces
{
    public interface IOccasionService
    {
        Task<List<OccasionModel>> GetAllOccasions();
    }
}
