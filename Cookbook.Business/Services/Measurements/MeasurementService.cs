using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Cookbook.Web.Models.Measurements.BindingModels;
using Cookbook.Web.Models.Measurements.ViewModels;
using Cookbook.Web.Models.Recipes.ViewModels;
using Cookbook.Web.Models.Mapping;
using Cookbook.Web.Models.Ingredients.ViewModels;
using Data.DataAccess.Repositories.Implementation;
using Cookbook.Web.Models.Ingredients.BindingModels;

namespace Cookbook.Business.Services.Measurements
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;

        private readonly IRecipeRepository _recipeRepository;

        private readonly IRecipeIngredientsRepository _recipeIngredientsRepository;

        public MeasurementService(
            IMeasurementRepository measurementRepository,
            IRecipeRepository recipeRepository,
            IRecipeIngredientsRepository recipeIngredientsRepository
        )
        {
            _measurementRepository = measurementRepository;
            _recipeRepository = recipeRepository;
            _recipeIngredientsRepository = recipeIngredientsRepository;
        }

        public IEnumerable<AllMeasurementsViewModel> GetAllMeasurements()
        {
            List<AllMeasurementsViewModel> allMeasurements = _measurementRepository
                 .GetAllAsNoTracking()
                    .OrderBy(m => m.Unit)
                        .ThenByDescending(m => m.Quantity)
                             .Select(m => new AllMeasurementsViewModel
                             {
                                 Id = m.Id,
                                 Quantity = m.Quantity,
                                 Unit = m.Unit,
                             })
                             .ToList();

            return allMeasurements;
        }

        public CreateMeasurementBindingModel GetMeasurementCreatingDetails()
        {
            var measurement = new Measurement();

            var measurementCreationDetails = new CreateMeasurementBindingModel
            {
                Quantity = measurement.Quantity,
                Unit = measurement.Unit,
                AssignedRecipeIngredients = PopulateAssignedRecipeIngredientsData(measurement)
            };

            return measurementCreationDetails;
        }

        public MeasurementDetailsViewModel GetMeasurementDetails(string measurementId)
        {
            var singleMeasurement = _measurementRepository
                    .GetAllByCondition(m => m.Id == measurementId)
                         .FirstOrDefault();

            if (singleMeasurement is null)
            {
                return null;
            }

            var singleMeasurementDetails = new MeasurementDetailsViewModel
            {
                Id = singleMeasurement.Id,
                Quantity = singleMeasurement.Quantity,
                Unit = singleMeasurement.Unit,
                CreatedOn = singleMeasurement.CreatedOn,
                CreatedBy = singleMeasurement.CreatedBy,
                ModifiedOn = singleMeasurement.ModifiedOn,
                ModifiedBy = singleMeasurement.ModifiedBy
            };

            return singleMeasurementDetails;
        }

        public bool CreateMeasurement(CreateMeasurementBindingModel createMeasurementBindingModel, string[] selectedRecipeIngredients, string currentUserName)
        {
            Measurement measurementToCreate = new Measurement
            {
                Quantity = (int)createMeasurementBindingModel.Quantity,
                Unit = createMeasurementBindingModel.Unit
            };

            var allMeasurements = _measurementRepository.GetAllAsNoTracking();

            if (_measurementRepository.Exists(allMeasurements, measurementToCreate))
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
                        MeasurementId = measurementToCreate.Id
                    };

                    measurementToCreate.RecipeIngredients.Add(recipeIngredientToAdd);
                }
            }

            measurementToCreate.CreatedBy = currentUserName;

            _measurementRepository.Add(measurementToCreate);

            return true;
        }

        public EditMeasurementBindingModel GetMeasurementEditingDetails(string measurementId)
        {
            var measurementToEdit = _measurementRepository
                    .GetAllByCondition(m => m.Id == measurementId)
                        .Include(m => m.RecipeIngredients)
                            .ThenInclude(ri => ri.Recipe)
                                .FirstOrDefault();

            if (measurementToEdit is null)
            {
                return null;
            }

            var measurementToEditDetails = new EditMeasurementBindingModel
            {
                Id = measurementToEdit.Id,
                Quantity = measurementToEdit.Quantity,
                Unit = measurementToEdit.Unit,
                AssignedRecipeIngredients = PopulateAssignedRecipeIngredientsData(measurementToEdit)
            };

            return measurementToEditDetails;
        }

        public bool EditMeasurement(EditMeasurementBindingModel editMeasurementBindingModel, string[] selectedRecipeIngredients, string currentUserName)
        {
            var measurementToUpdate = _measurementRepository
                        .GetAllByCondition(m => m.Id == editMeasurementBindingModel.Id)
                            .Include(m => m.RecipeIngredients)
                                .ThenInclude(ri => ri.Recipe)
                                    .FirstOrDefault();

            measurementToUpdate.Quantity = editMeasurementBindingModel.Quantity;
            measurementToUpdate.Unit = editMeasurementBindingModel.Unit;

            var filteredMeasurements = _measurementRepository
                .GetAllAsNoTracking()
                    .Where(m => !m.Id.Equals(measurementToUpdate.Id))
                        .AsQueryable();

            if (_measurementRepository.Exists(filteredMeasurements, measurementToUpdate))
            {
                return false;
            }

            measurementToUpdate.ModifiedBy = currentUserName;

            _measurementRepository.Update(measurementToUpdate);

            UpdateRecipeIngredientsByMeasurement(selectedRecipeIngredients, measurementToUpdate);

            return true;
        }

        public DeleteMeasurementViewModel GetMeasurementDeletionDetails(string measurementId)
        {
            var measurementToDelete = FindMeasurement(measurementId);

            if (measurementToDelete is null)
            {
                return null;
            }

            var measurementToDeleteDetails = new DeleteMeasurementViewModel
            {
                Quantity = measurementToDelete.Quantity,
                Unit = measurementToDelete.Unit
            };

            return measurementToDeleteDetails;
        }

        public void DeleteMeasurement(Measurement measurement)
        {
            var recipeIngredientsByMeasurement = _recipeIngredientsRepository
                    .GetAllByCondition(ri => ri.MeasurementId == measurement.Id)
                        .ToArray();

            if (recipeIngredientsByMeasurement.Any())
            {
                _recipeIngredientsRepository.DeleteRange(recipeIngredientsByMeasurement);
            }

            _measurementRepository.Delete(measurement);
        }

        public Measurement FindMeasurement(string measurementId)
        {
            return _measurementRepository.GetById(measurementId);
        }

        private List<AssignedRecipeIngredientsDataViewModel> PopulateAssignedRecipeIngredientsData(
           Measurement measurement
        )
        {
            var allRecipes = _recipeRepository
               .GetAllAsNoTracking()
                   .ToList();

            var RecipesOfAMeasurement = new HashSet<string>(measurement.RecipeIngredients
                .Select(ri => ri.Recipe.Id));

            var assignedRecipeIngredientsDataViewModel =
                    new List<AssignedRecipeIngredientsDataViewModel>();

            foreach (var recipe in allRecipes)
            {
                assignedRecipeIngredientsDataViewModel.Add(new AssignedRecipeIngredientsDataViewModel
                {
                    RecipeIngredientId = measurement.Id,
                    Quantity = measurement.Quantity,
                    Unit = measurement.Unit,
                    IsAssigned = RecipesOfAMeasurement.Contains(measurement.Id)
                });
            }

            return assignedRecipeIngredientsDataViewModel;
        }

        private void UpdateRecipeIngredientsByMeasurement(string[] selectedRecipeIngredients, Measurement measurement)
        {
            if (selectedRecipeIngredients == null)
            {
                measurement.RecipeIngredients = new List<RecipeIngredients>();
                return;
            }

            var selectedRecipeIngredientsIds = new HashSet<string>(selectedRecipeIngredients);

            var RecipesOfAMeasurement = new HashSet<string>(measurement.RecipeIngredients
               .Select(ri => ri.Recipe.Id));

            var allRecipes = _recipeRepository
                .GetAllAsNoTracking();

            foreach (var recipe in allRecipes)
            {
                if (selectedRecipeIngredientsIds.Contains(recipe.Id))
                {
                    if (!RecipesOfAMeasurement.Contains(recipe.Id))
                    {
                        measurement.RecipeIngredients.Add(new RecipeIngredients
                        {
                            RecipeId = recipe.Id,
                            MeasurementId = measurement.Id
                        });
                    }
                }
                else
                {
                    if (RecipesOfAMeasurement.Contains(recipe.Id))
                    {
                        RecipeIngredients recipeIngredientsToRemove =
                            measurement.RecipeIngredients
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
