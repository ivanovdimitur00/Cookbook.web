using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public  class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        public override bool Exists(IQueryable<Recipe> recipeEntities, Recipe recipeEntityToFind)
        {
            Expression<Func<Recipe, bool>> existingRecipePredicate = cm =>
                cm.Title.Trim().ToLower() ==
                    recipeEntityToFind.Title.Trim().ToLower();

            bool recipeExists = recipeEntities.Any(existingRecipePredicate);

            return recipeExists;
        }
    }
}