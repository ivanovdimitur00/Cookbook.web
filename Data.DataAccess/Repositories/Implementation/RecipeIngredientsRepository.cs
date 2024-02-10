using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public abstract class RecipeIngredientsRepository : BaseRepository<RecipeIngredients>, IRecipeIngredientsRepository
    {
        public RecipeIngredientsRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}