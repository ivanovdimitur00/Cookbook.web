using Data.DataModels.Entities;
using Cookbook.Web.Models.Ingredients.BindingModels;
using Cookbook.Web.Models.Ingredients.ViewModels;
using System.IO;

namespace Cookbook.Business.Services.Ingredients
{
    public interface IIngredientService
    {
        IEnumerable<AllIngredientsViewModel> GetAllIngredients();

        CreateIngredientBindingModel GetIngredientCreatingDetails();

        IngredientDetailsViewModel GetIngredientDetails(string ingredientId);

        bool CreateIngredient(CreateIngredientBindingModel createIngredientBindingModel, string[] selectedRecipeIngredients, string currentUserName);

        EditIngredientBindingModel GetIngredientEditingDetails(string ingredientId);

        bool EditIngredient(EditIngredientBindingModel editIngredientBindingModel, string[] selectedRecipeIngredients, string currentUserName);

        DeleteIngredientViewModel GetIngredientDeletionDetails(string ingredientId);

        void DeleteIngredient(Ingredient ingredient);

        Ingredient FindIngredient(string ingredientId);
    }
}
