using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Cookbook.Web.Models.Ingredients.BindingModels;
using Cookbook.Web.Models.Ingredients.ViewModels;
using Cookbook.Web.Models.Recipes.ViewModels;
using Cookbook.Web.Models.Mapping;
using Data.DataAccess.Repositories.Implementation;
using System.IO;


namespace Cookbook.Business.Services.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        private readonly IRecipeRepository _recipeRepository;

        private readonly IRecipeIngredientsRepository _recipeIngredientsRepository;

        public IngredientService(
            IIngredientRepository ingredientRepository,
            IRecipeRepository recipeRepository,
            IRecipeIngredientsRepository recipeIngredientsRepository
        )
        {
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
            _recipeIngredientsRepository = recipeIngredientsRepository;
        }

        public IEnumerable<AllIngredientsViewModel> GetAllIngredients()
        {
            List<AllIngredientsViewModel> allIngredients = _ingredientRepository
                 .GetAllAsNoTracking()
                    .OrderBy(i => i.Name)
                        .Select(i => new AllIngredientsViewModel
                        {
                            Id = i.Id,
                            Name = i.Name,
                            IsAllergen = i.IsAllergen
                        })
                        .ToList();

            return allIngredients;
        }

        public CreateIngredientBindingModel GetIngredientCreatingDetails()
        {
            var ingredient = new Ingredient();

            var ingredientCreationDetails = new CreateIngredientBindingModel
            {
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen,
                AssignedRecipeIngredients = PopulateAssignedRecipeIngredientsData(ingredient)
            };

            return ingredientCreationDetails;
        }

        public IngredientDetailsViewModel GetIngredientDetails(string ingredientId)
        {
            var singleIngredient = _ingredientRepository
                    .GetAllByCondition(i => i.Id == ingredientId)
                         .FirstOrDefault();

            if (singleIngredient is null)
            {
                return null;
            }

            var singleIngredientDetails = new IngredientDetailsViewModel
            {
                Id = singleIngredient.Id,
                Name = singleIngredient.Name,
                IsAllergen = singleIngredient.IsAllergen,
                CreatedOn = singleIngredient.CreatedOn,
                CreatedBy = singleIngredient.CreatedBy,
                ModifiedOn = singleIngredient.ModifiedOn,
                ModifiedBy = singleIngredient.ModifiedBy
            };

            return singleIngredientDetails;
        }

        public bool CreateIngredient(CreateIngredientBindingModel createIngredientBindingModel, string[] selectedRecipeIngredients, string currentUserName)
        {
            Ingredient ingredientToCreate = new Ingredient
            {
                Name = createIngredientBindingModel.Name,
                IsAllergen = createIngredientBindingModel.IsAllergen
            };

            var allIngredients = _ingredientRepository.GetAllAsNoTracking();

            if (_ingredientRepository.Exists(allIngredients, ingredientToCreate))
            {
                return false;
            }

            if (selectedRecipeIngredients != null)
            {
                foreach (var recipeIngredientsId in selectedRecipeIngredients)
                {
                    var recipeIngredientToAdd = new RecipeIngredients
                    {
                        RecipeId = recipeIngredientsId,
                        IngredientId = ingredientToCreate.Id
                    };

                    ingredientToCreate.RecipeIngredients.Add(recipeIngredientToAdd);
                }
            }

            ingredientToCreate.CreatedBy = currentUserName;

            _ingredientRepository.Add(ingredientToCreate);

            return true;
        }

        public EditIngredientBindingModel GetIngredientEditingDetails(string ingredientId)
        {
            var ingredientToEdit = _ingredientRepository
                    .GetAllByCondition(i => i.Id == ingredientId)
                        .Include(i => i.RecipeIngredients)
                            .ThenInclude(ri => ri.Recipe)
                                .FirstOrDefault();

            if (ingredientToEdit is null)
            {
                return null;
            }

            var ingredientToEditDetails = new EditIngredientBindingModel
            {
                Id = ingredientToEdit.Id,
                Name = ingredientToEdit.Name,
                IsAllergen = ingredientToEdit.IsAllergen,
                AssignedRecipeIngredients = PopulateAssignedRecipeIngredientsData(ingredientToEdit)
            };

            return ingredientToEditDetails;
        }

        public bool EditIngredient(EditIngredientBindingModel editIngredientBindingModel, string[] selectedRecipeIngredients, string currentUserName)
        {
                var ingredientToUpdate = _ingredientRepository
                        .GetAllByCondition(i => i.Id == editIngredientBindingModel.Id)
                            .Include(i => i.RecipeIngredients)
                                .ThenInclude(ri => ri.Recipe)
                                    .FirstOrDefault();

                ingredientToUpdate.Name = editIngredientBindingModel.Name;
                ingredientToUpdate.IsAllergen = editIngredientBindingModel.IsAllergen;

                var filteredIngredients = _ingredientRepository
                    .GetAllAsNoTracking()
                        .Where(i => !i.Id.Equals(ingredientToUpdate.Id))
                            .AsQueryable();

                if (_ingredientRepository.Exists(filteredIngredients, ingredientToUpdate))
                {
                    return false;
                }

                ingredientToUpdate.ModifiedBy = currentUserName;

                _ingredientRepository.Update(ingredientToUpdate);

            UpdateRecipeIngredientsByIngredient(selectedRecipeIngredients, ingredientToUpdate);

                return true;
            }

        public DeleteIngredientViewModel GetIngredientDeletionDetails(string ingredientId)
        {
            var ingredientToDelete = FindIngredient(ingredientId);

            if (ingredientToDelete is null)
            {
                return null;
            }

            var ingredientToDeleteDetails = new DeleteIngredientViewModel
            {
                Name = ingredientToDelete.Name,
                IsAllergen = ingredientToDelete.IsAllergen
            };

            return ingredientToDeleteDetails;
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            var recipeIngredientsByIngredient = _recipeIngredientsRepository
                    .GetAllByCondition(ri => ri.IngredientId == ingredient.Id)
                        .ToArray();

            if (recipeIngredientsByIngredient.Any())
            {
                _recipeIngredientsRepository.DeleteRange(recipeIngredientsByIngredient);
            }

            _ingredientRepository.Delete(ingredient);
        }

        public Ingredient FindIngredient(string ingredientId)
        {
            return _ingredientRepository.GetById(ingredientId);
        }

        private List<AssignedRecipeIngredientsDataViewModel> PopulateAssignedRecipeIngredientsData(
           Ingredient ingredient
        )
        {
            var allRecipes = _recipeRepository
                .GetAllAsNoTracking()
                    .ToList();

            var RecipesOfAnIngredient = new HashSet<string>(ingredient.RecipeIngredients
                .Select(ri => ri.Recipe.Id));

            var assignedRecipeIngredientsDataViewModel =
                    new List<AssignedRecipeIngredientsDataViewModel>();

            foreach (var recipe in allRecipes)
            {
                assignedRecipeIngredientsDataViewModel.Add(new AssignedRecipeIngredientsDataViewModel
                {
                    RecipeIngredientId = ingredient.Id,
                    Name = ingredient.Name,
                    IsAllergen = ingredient.IsAllergen,
                    IsAssigned = RecipesOfAnIngredient.Contains(ingredient.Id)
                });
            }

            return assignedRecipeIngredientsDataViewModel;
        }

        private void UpdateRecipeIngredientsByIngredient(string[] selectedRecipeIngredients, Ingredient ingredient)
        {
            if (selectedRecipeIngredients == null)
            {
                ingredient.RecipeIngredients= new List<RecipeIngredients>();
                return;
            }

            var selectedRecipeIngredientsIds = new HashSet<string>(selectedRecipeIngredients);

            var RecipesOfAnIngredient = new HashSet<string>(ingredient.RecipeIngredients
                 .Select(ri => ri.Recipe.Id));

            var allRecipes = _recipeRepository
                .GetAllAsNoTracking();

            foreach (var recipe in allRecipes)
            {
                if (selectedRecipeIngredientsIds.Contains(recipe.Id))
                {
                    if (!RecipesOfAnIngredient.Contains(recipe.Id))
                    {
                        ingredient.RecipeIngredients.Add(new RecipeIngredients
                        {
                            RecipeId = recipe.Id,
                            IngredientId = ingredient.Id
                        });
                    }
                }
                else
                {
                    if (RecipesOfAnIngredient.Contains(recipe.Id))
                    {
                        RecipeIngredients recipeIngredientsToRemove =
                            ingredient.RecipeIngredients
                                    .FirstOrDefault(ri =>
                                        ri.RecipeId == recipe.Id
                                    );

                        _recipeIngredientsRepository.Delete(recipeIngredientsToRemove);
                    }
                }
            }
        }
    }
}
