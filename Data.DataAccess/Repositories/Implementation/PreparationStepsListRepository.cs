using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public  class PreparationStepsListRepository : BaseRepository<PreparationStepsList>, IPreparationStepsListRepository
    {
        public PreparationStepsListRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}