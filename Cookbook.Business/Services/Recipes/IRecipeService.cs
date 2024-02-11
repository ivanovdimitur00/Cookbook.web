using Data.DataModels.Entities;
using Cookbook.Web.Models.Recipes.BindingModels;
using Cookbook.Web.Models.Recipes.ViewModels;

namespace Cookbook.Business.Services.Recipes
{
    public interface IRecipeService
    {
        List<Recipe> GetAllRecipes();

        IEnumerable<AllRecipesViewModel> GetAllRecipesWithRelatedData();

        RecipeFullDetailsViewModel GetRecipeDetails(string recipeId);

        CreateRecipeBindingModel GetRecipeCreatingDetails();

        void CreateRecipe(
            CreateRecipeBindingModel createRecipeBindingModel,
            string[] selectedRecipeTags, string[] selectedPreparationStepsLists,
            string[] selectedRecipeIngredients, string currentUserName);

        EditRecipeBindingModel GetRecipeEditingDetails(string recipeId);

        void EditRecipe(
            EditRecipeBindingModel editRecipeBindingModel,
            string[] selectedRecipeTags, string[] selectedPreparationStepsLists,
            string[] selectedRecipeIngredients, string currentUserName);

        DeleteRecipesViewModel GetRecipeDeletionDetails(string recipeId);

        void DeleteRecipe(Recipe recipe);

        Recipe FindRecipe(string recipeId);

        void DeleteRecipeImage(Recipe recipe);
    }
}
