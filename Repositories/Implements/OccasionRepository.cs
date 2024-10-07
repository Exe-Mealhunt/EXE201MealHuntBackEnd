using MealHunt_Repositories.Data;
using MealHunt_Repositories.Entities;
using MealHunt_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Repositories.Implements
{
    public class OccasionRepository : IOccasionRepository
    {
        private readonly MealHuntContext _context;

        public OccasionRepository(MealHuntContext context)
        {
            _context = context;
        }

        public async Task<List<Occasion>> GetAll()
        {
            var occasions = new List<Occasion>();
            try
            {
                occasions = await _context.Occasions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return occasions;
        }
    }
}
