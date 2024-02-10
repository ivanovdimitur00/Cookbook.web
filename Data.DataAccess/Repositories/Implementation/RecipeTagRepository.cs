using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public abstract class RecipeTagRepository : BaseRepository<RecipeTag>, IRecipeTagRepository
    {
        public RecipeTagRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}