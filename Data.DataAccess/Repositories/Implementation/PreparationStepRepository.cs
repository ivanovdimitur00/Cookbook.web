using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public abstract class PreparationStepRepository : BaseRepository<PreparationStep>, IPreparationStepRepository
    {
        public PreparationStepRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}