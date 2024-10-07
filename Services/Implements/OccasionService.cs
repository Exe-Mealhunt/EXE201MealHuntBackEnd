using AutoMapper;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.BusinessModels;
using MealHunt_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealHunt_Services.Implements
{
    public class OccasionService : IOccasionService
    {
        private readonly IOccasionRepository _occasionRepository;
        private readonly IMapper _mapper;

        public OccasionService(IOccasionRepository occasionRepository, IMapper mapper)
        {
            _occasionRepository = occasionRepository;
            _mapper = mapper;
        }

        public async Task<List<OccasionModel>> GetAllOccasions()
        {
            try
            {
                var occasions = await _occasionRepository.GetAll();
                var response = _mapper.Map<List<OccasionModel>>(occasions);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
