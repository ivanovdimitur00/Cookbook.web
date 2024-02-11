using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using System.Linq.Expressions;

namespace Data.DataAccess.Repositories.Implementation
{
    public  class IngredientRepository
        : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            
        }

        public override bool Exists(IQueryable<Ingredient> ingredientEntities, Ingredient ingredientEntityToFind)
        {
            Expression<Func<Ingredient, bool>> existingIngredientPredicate = cm =>
                cm.Name.Trim().ToLower() ==
                    ingredientEntityToFind.Name.Trim().ToLower();

            bool ingredientExists = ingredientEntities.Any(existingIngredientPredicate);

            return ingredientExists;
        }
    }
}
