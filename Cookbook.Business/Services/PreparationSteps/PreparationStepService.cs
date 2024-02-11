using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Cookbook.Web.Models.PreparationSteps.BindingModels;
using Cookbook.Web.Models.PreparationSteps.ViewModels;
using Cookbook.Web.Models.Recipes.ViewModels;
using Cookbook.Web.Models.Mapping;
using Cookbook.Web.Models.Ingredients.ViewModels;
using Data.DataAccess.Repositories.Implementation;
using Cookbook.Web.Models.Measurements.BindingModels;
using Cookbook.Web.Models.Measurements.ViewModels;
using System.Diagnostics.Metrics;

namespace Cookbook.Business.Services.PreparationSteps
{
    public class PreparationStepService : IPreparationStepService
    {
        private readonly IPreparationStepRepository _preparationStepRepository;

        private readonly IRecipeRepository _recipeRepository;

        private readonly IPreparationStepsListRepository _preparationStepsListRepository;

        public PreparationStepService(
            IPreparationStepRepository preparationStepRepository,
            IRecipeRepository recipeRepository,
            IPreparationStepsListRepository preparationStepsListRepository
        )
        {
            _preparationStepRepository = preparationStepRepository;
            _recipeRepository = recipeRepository;
            _preparationStepsListRepository = preparationStepsListRepository;
        }

        public IEnumerable<AllPreparationStepsViewModel> GetAllPreparationSteps()
        {
            List<AllPreparationStepsViewModel> allPreparationSteps = _preparationStepRepository
                 .GetAllAsNoTracking()
                    .OrderBy(ps => ps.Number)
                        .Select(ps => new AllPreparationStepsViewModel
                        {
                            Id = ps.Id,
                            Number = ps.Number,
                            Description= ps.Description,
                        })
                        .ToList();

            return allPreparationSteps;
        }

        public CreatePreparationStepsBindingModel GetPreparationStepCreatingDetails()
        {
            var preparationStep = new PreparationStep();

            var preparationStepCreationDetails = new CreatePreparationStepsBindingModel
            {
                Number = preparationStep.Number,
                Description = preparationStep.Description,
                AssignedPreparationStepsList = PopulateAssignedPreparationStepsListData(preparationStep)
            };

            return preparationStepCreationDetails;
        }

        public PreparationStepDetailsViewModel GetPreparationStepDetails(string preparationStepId)
        {
            var singlePreparationStep = _preparationStepRepository
                    .GetAllByCondition(ps => ps.Id == preparationStepId)
                         .FirstOrDefault();

            if (singlePreparationStep is null)
            {
                return null;
            }

            var singlePreparationStepDetails = new PreparationStepDetailsViewModel
            {
                Id = singlePreparationStep.Id,
                Number = singlePreparationStep.Number,
                Description = singlePreparationStep.Description,
                CreatedOn = singlePreparationStep.CreatedOn,
                CreatedBy = singlePreparationStep.CreatedBy,
                ModifiedOn = singlePreparationStep.ModifiedOn,
                ModifiedBy = singlePreparationStep.ModifiedBy
            };

            return singlePreparationStepDetails;
        }

        public bool CreatePreparationStep(CreatePreparationStepsBindingModel createPreparationStepBindingModel, string[] selectedPreparationStepsList, string currentUserName)
        {
            PreparationStep preparationStepToCreate = new PreparationStep
            {
                Number = createPreparationStepBindingModel.Number,
                Description = createPreparationStepBindingModel.Description
            };

            var allPreparationSteps = _preparationStepRepository.GetAllAsNoTracking();

            if (_preparationStepRepository.Exists(allPreparationSteps, preparationStepToCreate))
            {
                return false;
            }

            if (selectedPreparationStepsList != null)
            {
                foreach (var preparationStepsListId in selectedPreparationStepsList)
                {
                    var preparationStepsListToAdd = new PreparationStepsList
                    {
                        RecipeId = preparationStepsListId,
                        PreparationStepId = preparationStepToCreate.Id
                    };

                    preparationStepToCreate.PreparationStepsList.Add(preparationStepsListToAdd);
                }
            }

            preparationStepToCreate.CreatedBy = currentUserName;

            _preparationStepRepository.Add(preparationStepToCreate);

            return true;
        }

        public EditPreparationStepsBindingModel GetPreparationStepEditingDetails(string preparationStepId)
        {
            var preparationStepToEdit = _preparationStepRepository
                    .GetAllByCondition(ps => ps.Id == preparationStepId)
                        .Include(ps => ps.PreparationStepsList)
                            .ThenInclude(ri => ri.Recipe)
                                .FirstOrDefault();

            if (preparationStepToEdit is null)
            {
                return null;
            }

            var preparationStepToEditDetails = new EditPreparationStepsBindingModel
            {
                Id = preparationStepToEdit.Id,
                Number = preparationStepToEdit.Number,
                Description = preparationStepToEdit.Description,
                AssignedPreparationStepsList = PopulateAssignedPreparationStepsListData(preparationStepToEdit)
            };

            return preparationStepToEditDetails;
        }

        public bool EditPreparationStep(EditPreparationStepsBindingModel editPreparationStepBindingModel, string[] selectedPreparationStepsList, string currentUserName)
        {
            var preparationStepToUpdate = _preparationStepRepository
                        .GetAllByCondition(ps => ps.Id == editPreparationStepBindingModel.Id)
                            .Include(ps => ps.PreparationStepsList)
                                .ThenInclude(psl => psl.Recipe)
                                    .FirstOrDefault();

            preparationStepToUpdate.Number = editPreparationStepBindingModel.Number;
            preparationStepToUpdate.Description = editPreparationStepBindingModel.Description;

            var filteredPreparationSteps = _preparationStepRepository
                .GetAllAsNoTracking()
                    .Where(ps => !ps.Id.Equals(preparationStepToUpdate.Id))
                        .AsQueryable();

            if (_preparationStepRepository.Exists(filteredPreparationSteps, preparationStepToUpdate))
            {
                return false;
            }

            preparationStepToUpdate.ModifiedBy = currentUserName;

            _preparationStepRepository.Update(preparationStepToUpdate);

            UpdatePreparationStepsListByPreparationStep(selectedPreparationStepsList, preparationStepToUpdate);

            return true;
        }

        public DeletePreparationStepViewModel GetPreparationStepDeletionDetails(string preparationStepId)
        {
            var preparationStepToDelete = FindPreparationStep(preparationStepId);

            if (preparationStepToDelete is null)
            {
                return null;
            }

            var preparationStepToDeleteDetails = new DeletePreparationStepViewModel
            {
                Number = preparationStepToDelete.Number,
                Description = preparationStepToDelete.Description
            };

            return preparationStepToDeleteDetails;
        }

        public void DeletePreparationStep(PreparationStep preparationStep)
        {
            var preparationStepsListByPreparationStep = _preparationStepsListRepository
                    .GetAllByCondition(psl => psl.PreparationStepId == preparationStep.Id)
                        .ToArray();

            if (preparationStepsListByPreparationStep.Any())
            {
                _preparationStepsListRepository.DeleteRange(preparationStepsListByPreparationStep);
            }

            _preparationStepRepository.Delete(preparationStep);
        }

        public PreparationStep FindPreparationStep(string preparationStepId)
        {
            return _preparationStepRepository.GetById(preparationStepId);
        }

        private List<AssignedPreparationStepsListDataViewModel> PopulateAssignedPreparationStepsListData(
           PreparationStep preparationStep
        )
        {
            var allRecipes = _recipeRepository
              .GetAllAsNoTracking()
                  .ToList();

            var RecipesOfAPreparationStep = new HashSet<string>(preparationStep.PreparationStepsList
                .Select(psl => psl.Recipe.Id));

            var assignedPreparationStepsListDataViewModel =
                    new List<AssignedPreparationStepsListDataViewModel>();

            foreach (var recipe in allRecipes)
            {
                assignedPreparationStepsListDataViewModel.Add(new AssignedPreparationStepsListDataViewModel
                {
                    PreparationStepsListId = preparationStep.Id,
                    Number = preparationStep.Number,
                    Description = preparationStep.Description,
                    IsAssigned = RecipesOfAPreparationStep.Contains(preparationStep.Id)
                });
            }

            return assignedPreparationStepsListDataViewModel;
        }

        private void UpdatePreparationStepsListByPreparationStep(string[] selectedPreparationStepsList, PreparationStep preparationStep)
        {
            if (selectedPreparationStepsList == null)
            {
                preparationStep.PreparationStepsList = new List<PreparationStepsList>();
                return;
            }

            var selectedPreparationStepsListIds = new HashSet<string>(selectedPreparationStepsList);

            var RecipesOfAPreparationStep = new HashSet<string>(preparationStep.PreparationStepsList
               .Select(ri => ri.Recipe.Id));

            var allRecipes = _recipeRepository
                .GetAllAsNoTracking();

            foreach (var recipe in allRecipes)
            {
                if (selectedPreparationStepsListIds.Contains(recipe.Id))
                {
                    if (!RecipesOfAPreparationStep.Contains(recipe.Id))
                    {
                        preparationStep.PreparationStepsList.Add(new PreparationStepsList
                        {
                            RecipeId = recipe.Id,
                            PreparationStepId = preparationStep.Id
                        });
                    }
                }
                else
                {
                    if (RecipesOfAPreparationStep.Contains(recipe.Id))
                    {
                        PreparationStepsList preparationStepsListToRemove =
                            preparationStep.PreparationStepsList
                                    .FirstOrDefault(psl =>
                                        psl.RecipeId == recipe.Id
                                    );

                        _preparationStepsListRepository.Delete(preparationStepsListToRemove);
                    }
                }
            }
        }
        
    }
    
}
