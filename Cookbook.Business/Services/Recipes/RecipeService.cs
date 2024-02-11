using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Cookbook.Web.Models.Countries.ViewModels;
using Cookbook.Web.Models.Recipes.BindingModels;
using Cookbook.Web.Models.Recipes.ViewModels;
using Cookbook.Web.Models.Mapping;
using Data.DataAccess.Repositories.Implementation;
using System.Linq;
using Microsoft.VisualBasic;

namespace Cookbook.Business.Services.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        private readonly IPreparationStepRepository _preparationStepRepository;

        private readonly ITagRepository _tagRepository;

        private readonly IIngredientRepository _ingredientRepository;

        private readonly IMeasurementRepository _measurementRepository;

        private readonly IPreparationStepsListRepository _preparationStepsListRepository;

        private readonly IRecipeTagRepository _recipeTagRepository;

        private readonly IRecipeIngredientsRepository _recipeIngredientsRepository;

        private readonly IHostingEnvironment _hostingEnvironment;

        public RecipeService(
            IRecipeRepository recipeRepository,
            IPreparationStepRepository preparationStepRepository,
            ITagRepository tagRepository,
            IIngredientRepository ingredientRepository,
            IMeasurementRepository measurementRepository,
            IPreparationStepsListRepository preparationStepsListRepository,
            IRecipeTagRepository recipeTagRepository,
            IRecipeIngredientsRepository recipeIngredientsRepository,
            IHostingEnvironment hostingEnvironment
        )
        {
            _recipeRepository = recipeRepository;
            _preparationStepRepository = preparationStepRepository;
            _tagRepository = tagRepository;
            _ingredientRepository = ingredientRepository;
            _measurementRepository = measurementRepository;
            _preparationStepsListRepository = preparationStepsListRepository;
            _recipeTagRepository = recipeTagRepository;
            _recipeIngredientsRepository = recipeIngredientsRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipeRepository.GetAllAsNoTracking().ToList();
        }

        public IEnumerable<AllRecipesViewModel> GetAllRecipesWithRelatedData()
        {
            List<AllRecipesViewModel> allRecipes = _recipeRepository
                .GetAllAsNoTracking()
                    .Select(r => new AllRecipesViewModel
                    {
                        Id = r.Id,
                        Title = r.Title,
                        RelatedCountry = new CountryConciseInformationViewModel
                        {
                            Name = r.Country.Name
                        },
                    })
                    .OrderBy(arvm => arvm.Title)
                        .ThenByDescending(arvm => arvm.RelatedCountry.Name)
                            .ToList();

            return allRecipes;
        }

        public RecipeFullDetailsViewModel GetRecipeDetails(
            string recipeId
        )
        {
            var singleRecipe = _recipeRepository
                    .GetAllByCondition(r => r.Id == recipeId)
                        .Include(r => r.Country)
                        .Include(r => r.Servings)
                        .Include(r => r.RecipeIngredients)
                            .ThenInclude(i => i.Ingredient)
                        .Include(r => r.RecipeIngredients)
                            .ThenInclude(m => m.Measurement)
                        .Include(r => r.PreparationStepsList)
                            .ThenInclude(ps => ps.PreparationStep)
                        .Include(r => r.RecipeTags)
                            .ThenInclude(t => t.Tag)
                        .FirstOrDefault();

            if (singleRecipe is null)
            {
                return null;
            }

            var singleRecipeDetails = new RecipeFullDetailsViewModel
            {
                Id = singleRecipe.Id,
                Title = singleRecipe.Title,
                Description = singleRecipe.Description,
                PreparationTime = singleRecipe.PreparationTime,
                PreparationTimeUnit = singleRecipe.PreparationTimeUnit,
                Servings = singleRecipe.Servings,
                CountryName = singleRecipe.Country.Name,
                ImageName = singleRecipe.ImageName,
                CreatedOn = singleRecipe.CreatedOn,
                CreatedBy = singleRecipe.CreatedBy,
                ModifiedOn = singleRecipe.ModifiedOn,
                ModifiedBy = singleRecipe.ModifiedBy,
                RelatedRecipeIngredients = singleRecipe.RecipeIngredients
                                    .Select(ri => new Tuple<int, string, string>(
                                        ri.Measurement.Quantity,
                                        ri.Measurement.Unit,
                                        ri.Ingredient.Name)
                                    )
                                    .ToList(),
                RelatedPreparationSteps = singleRecipe.PreparationStepsList
                                    .Select(ps => new Tuple<int, string>(
                                            ps.PreparationStep.Number,
                                            ps.PreparationStep.Description
                                        ))
                                    .ToList(),
                RelatedRecipeTags = singleRecipe.RecipeTags
                                    .Select(t => t.Tag.Name)
                                    .ToList()
            };

            return singleRecipeDetails;
        }

        public CreateRecipeBindingModel GetRecipeCreatingDetails()
        {
            var recipe = new Recipe();

            var recipeRelatedEntities = PopulateAssignedEntitiesToRecipeData(
                  recipe
            );

            var recipeCreationDetails = new CreateRecipeBindingModel
            {
                Title = recipe.Title,
                CreatedOn = null,
                Description = recipe.Description,
                PreparationTime = null,
                PreparationTimeUnit = recipe.PreparationTimeUnit,
                Servings = null,
                CountryId = recipe.CountryId,
                AssignedPreparationStepsLists = recipeRelatedEntities.Item1,
                AssignedRecipeIngredients = recipeRelatedEntities.Item2,
                AssignedRecipeTags = recipeRelatedEntities.Item3
            };

            return recipeCreationDetails;
        }

        public void CreateRecipe(
            CreateRecipeBindingModel createRecipeBindingModel,
            string[] selectedRecipeTags,
            string[] selectedPreparationStepsLists,
            string[] selectedRecipeIngredients,
            string currentUserName
        )
        {
            string wwwRootPath = _hostingEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(
                createRecipeBindingModel.ImageFile.FileName
            );
            string extension = Path.GetExtension(createRecipeBindingModel.ImageFile.FileName);
            string recipeImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff")
                    + extension;
            string path = Path.Combine(wwwRootPath + "/images/recipes", fileName);

            Recipe recipeToCreate = new Recipe
            {
                Title = createRecipeBindingModel.Title,
                CreatedOn = (DateTime)createRecipeBindingModel.CreatedOn,
                Description = createRecipeBindingModel.Description,
                PreparationTime = (int)createRecipeBindingModel.PreparationTime,
                PreparationTimeUnit = createRecipeBindingModel.PreparationTimeUnit,
                Servings = (int)createRecipeBindingModel.Servings,
                CountryId = createRecipeBindingModel.CountryId,
                ImageName = recipeImageName,
                ImageFile = createRecipeBindingModel.ImageFile
            };

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                recipeToCreate.ImageFile.CopyTo(fileStream);
            }

            if (selectedRecipeTags != null)
            {
                foreach (var tagId in selectedRecipeTags)
                {
                    var recipeTagToAdd = new RecipeTag
                    {
                        RecipeId = recipeToCreate.Id,
                        TagId = tagId
                    };

                    recipeToCreate.RecipeTags
                        .Add(recipeTagToAdd);
                }
            }

            if (selectedPreparationStepsLists != null)
            {
                foreach (var preparationStepId in selectedPreparationStepsLists)
                {
                    var preparationStepsListsToAdd = new PreparationStepsList
                    {
                        RecipeId = recipeToCreate.Id,
                        PreparationStepId = preparationStepId
                    };

                    recipeToCreate.PreparationStepsList
                        .Add(preparationStepsListsToAdd);
                }
            }

            if (selectedRecipeIngredients != null)
            {
                foreach (var ingredientId in selectedRecipeIngredients)
                {
                    var recipeIngredientsToAdd = new RecipeIngredients
                    {
                        RecipeId = recipeToCreate.Id,
                        IngredientId = ingredientId
                    };

                    recipeToCreate.RecipeIngredients
                        .Add(recipeIngredientsToAdd);
                }

                foreach (var measurementId in selectedRecipeIngredients)
                {
                    var recipeIngredientsToAdd = new RecipeIngredients
                    {
                        RecipeId = recipeToCreate.Id,
                        MeasurementId = measurementId
                    };

                    recipeToCreate.RecipeIngredients
                        .Add(recipeIngredientsToAdd);
                }
            }

            recipeToCreate.CreatedBy = currentUserName;

            _recipeRepository.Add(recipeToCreate);
        }

        public EditRecipeBindingModel GetRecipeEditingDetails(
            string recipeId
        )
        {
            var recipeToEdit = FindRecipe(recipeId);

            if (recipeToEdit is null)
            {
                return null;
            }

            var recipeRelatedEntities = PopulateAssignedEntitiesToRecipeData(
                recipeToEdit
            );

            var recipeToEditDetails = new EditRecipeBindingModel
            {
                Title = recipeToEdit.Title,
                CreatedOn = recipeToEdit.CreatedOn,
                Description = recipeToEdit.Description,
                PreparationTime = recipeToEdit.PreparationTime,
                PreparationTimeUnit = recipeToEdit.PreparationTimeUnit,
                Servings = recipeToEdit.Servings,
                CountryId = recipeToEdit.CountryId,
                AssignedPreparationStepsLists = recipeRelatedEntities.Item1,
                AssignedRecipeIngredients = recipeRelatedEntities.Item2,
                AssignedRecipeTags = recipeRelatedEntities.Item3
            };

            return recipeToEditDetails;
        }

        public void EditRecipe(
            EditRecipeBindingModel editRecipeBindingModel,
            string[] selectedRecipeTags,
            string[] selectedPreparationStepsLists,
            string[] selectedRecipeIngredients,
            string currentUserName
        )
        {
            var recipeToUpdate = _recipeRepository
                 .GetAllByCondition(r => r.Id == editRecipeBindingModel.Id)
                      .Include(r => r.RecipeIngredients)
                            .ThenInclude(i => i.Ingredient)
                        .Include(r => r.RecipeIngredients)
                            .ThenInclude(m => m.Measurement)
                        .Include(r => r.PreparationStepsList)
                            .ThenInclude(ps => ps.PreparationStep)
                        .Include(r => r.RecipeTags)
                            .ThenInclude(t => t.Tag)
                        .FirstOrDefault();

            if (editRecipeBindingModel.ImageFile != null)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(
                        editRecipeBindingModel.ImageFile.FileName
                );
                string extension = Path.GetExtension(editRecipeBindingModel.ImageFile.FileName);
                string recipeImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff")
                        + extension;

                string path = Path.Combine(wwwRootPath + "/images/recipes", fileName);

                if (recipeToUpdate.ImageName != null)
                {
                    var existingImagePath = Path.Combine(
                        _hostingEnvironment.WebRootPath,
                        "images/recipes",
                            recipeToUpdate.ImageName
                    );

                    if (File.Exists(existingImagePath))
                    {
                        File.Delete(existingImagePath);
                    }
                }

                recipeToUpdate.ImageName = recipeImageName;
                recipeToUpdate.ImageFile = editRecipeBindingModel.ImageFile;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    recipeToUpdate.ImageFile.CopyTo(fileStream);
                }
            }

            recipeToUpdate.Title = editRecipeBindingModel.Title;
            recipeToUpdate.CreatedOn = (DateTime)editRecipeBindingModel.CreatedOn;
            recipeToUpdate.Description = editRecipeBindingModel.Description;
            recipeToUpdate.PreparationTime = (int)editRecipeBindingModel.PreparationTime;
            recipeToUpdate.PreparationTimeUnit = editRecipeBindingModel.PreparationTimeUnit;
            recipeToUpdate.Servings = (int)editRecipeBindingModel.Servings;
            recipeToUpdate.CountryId = editRecipeBindingModel.CountryId;
            recipeToUpdate.ModifiedBy = currentUserName;

            _recipeRepository.Update(recipeToUpdate);

            UpdateRecipeMappings(
                selectedRecipeTags,
                selectedPreparationStepsLists,
                selectedRecipeIngredients,
                recipeToUpdate
            );
        }

        public DeleteRecipesViewModel GetRecipeDeletionDetails(
            string recipeId
        )
        {
            var recipeToDelete = FindRecipe(recipeId);

            if (recipeToDelete is null)
            {
                return null;
            }

            var recipeToDeleteDetails = new DeleteRecipesViewModel
            {
                Title = recipeToDelete.Title,
                CreatedOn = recipeToDelete.CreatedOn,
                ImageName = recipeToDelete.ImageName
            };

            return recipeToDeleteDetails;
        }

        public void DeleteRecipe(Recipe recipe)
        {
            var recipeTagsByRecipe = _recipeTagRepository
                    .GetAllByCondition(rt => rt.RecipeId == recipe.Id)
                        .ToArray();

            var recipeIngredientsByRecipe = _recipeIngredientsRepository
                   .GetAllByCondition(ri => ri.RecipeId == recipe.Id)
                       .ToArray();

            var preparationStepsListsByRecipe = _preparationStepsListRepository
                   .GetAllByCondition(psl => psl.RecipeId == recipe.Id)
                       .ToArray();

            if (recipeTagsByRecipe.Any())
            {
                _recipeTagRepository.DeleteRange(recipeTagsByRecipe);
            }

            if (recipeIngredientsByRecipe.Any())
            {
                _recipeIngredientsRepository.DeleteRange(recipeIngredientsByRecipe);
            }

            if (preparationStepsListsByRecipe.Any())
            {
                _preparationStepsListRepository.DeleteRange(preparationStepsListsByRecipe);
            }

            _recipeRepository.Delete(recipe);
        }

        public Recipe FindRecipe(string recipeId)
        {
            return _recipeRepository.GetById(recipeId);
        }

        public void DeleteRecipeImage(Recipe recipe)
        {
            if (recipe.ImageName != null)
            {
                var existingImagePath = Path.Combine(
                    _hostingEnvironment.WebRootPath,
                    "images/recipes",
                        recipe.ImageName
                );

                if (File.Exists(existingImagePath))
                {
                    File.Delete(existingImagePath);
                }
            }
        }

        private Tuple<List<AssignedPreparationStepsListDataViewModel>,
            List<AssignedRecipeIngredientsDataViewModel>,
            List<AssignedRecipeTagsDataViewModel>>
        PopulateAssignedEntitiesToRecipeData(
            Recipe recipe
        )
        {
            var allRecipes = _recipeRepository
                .GetAllAsNoTracking()
                    .ToList();

            var assignedPreparationStepsListDataViewModel = new List<AssignedPreparationStepsListDataViewModel>();
            var assignedRecipeIngredientsDataViewModel = new List<AssignedRecipeIngredientsDataViewModel>();
            var assignedRecipeTagsDataViewModel = new List<AssignedRecipeTagsDataViewModel>();

            var recipeTagsOfARecipe = new HashSet<string>(
                     recipe.RecipeTags
                           .Select(rt => rt.Tag.Id));

            var allTags = _tagRepository
                    .GetAllAsNoTracking()
                        .ToList();

            foreach (var tag in allTags)
            {
                assignedRecipeTagsDataViewModel.Add(new AssignedRecipeTagsDataViewModel
                {
                    RecipeTagId = tag.Id,
                    Name = tag.Name,
                    IsAssigned = recipeTagsOfARecipe.Contains(tag.Id)
                });
            }

            var preparationStepsListsOfARecipe = new HashSet<string>(
                     recipe.PreparationStepsList
                           .Select(ps => ps.PreparationStep.Id));

            var allPreparationSteps = _preparationStepRepository
                    .GetAllAsNoTracking()
                        .ToList();

            foreach (var preparationStep in allPreparationSteps)
            {
                assignedPreparationStepsListDataViewModel.Add(new AssignedPreparationStepsListDataViewModel
                {
                    PreparationStepsListId = preparationStep.Id,
                    Number = preparationStep.Number,
                    Description = preparationStep.Description,
                    IsAssigned = preparationStepsListsOfARecipe.Contains(preparationStep.Id)
                });
            }

            var recipeIngredientsOfARecipe = new HashSet<string>(
                    recipe.RecipeIngredients
                          .Select(ri => ri.Ingredient.Id));

            var allIngredients = _ingredientRepository
                    .GetAllAsNoTracking()
                        .ToList();

            var allMeasurements = _measurementRepository
                    .GetAllAsNoTracking()
                        .ToList();

            foreach (var measurement in allMeasurements)
            {
                assignedRecipeIngredientsDataViewModel.Add(new AssignedRecipeIngredientsDataViewModel
                {
                    RecipeIngredientId = measurement.Id,
                    Quantity = measurement.Quantity,
                    Unit = measurement.Unit,
                    IsAssigned = recipeIngredientsOfARecipe.Contains(measurement.Id)
                });
            }

            return Tuple.Create(
                assignedPreparationStepsListDataViewModel,
                assignedRecipeIngredientsDataViewModel,
                assignedRecipeTagsDataViewModel
            );
        }

        private void UpdateRecipeMappings(
           string[] selectedRecipeTags,
           string[] selectedPreparationStepsLists,
           string[] selectedRecipeIngredients,
           Recipe recipe
        )
        {
            if (selectedRecipeTags == null)
            {
                recipe.RecipeTags = new List<RecipeTag>();
                return;
            }

            var selectedRecipeTagsIds = new HashSet<string>(selectedRecipeTags);

            var recipeTagsOfARecipe = new HashSet<string>(
                    recipe.RecipeTags.Select(rt => rt.Tag.Id)
                );

            var allTags = _tagRepository.GetAllAsNoTracking();

            foreach (var tag in allTags)
            {
                if (selectedRecipeTagsIds.Contains(tag.Id))
                {
                    if (!recipeTagsOfARecipe.Contains(tag.Id))
                    {
                        recipe.RecipeTags.Add(new RecipeTag
                        {
                            RecipeId = recipe.Id,
                            TagId = tag.Id
                        });
                    }
                }
                else
                {
                    if (recipeTagsOfARecipe.Contains(tag.Id))
                    {
                        RecipeTag recipeTagToRemove =
                           recipe.RecipeTags
                               .FirstOrDefault(rt =>
                                     rt.TagId == rt.Id
                                  );
                        _recipeTagRepository.Delete(recipeTagToRemove);
                    }
                }
            }

            if (selectedPreparationStepsLists == null)
            {
                recipe.PreparationStepsList = new List<PreparationStepsList>();
                return;
            }

            var selectedPreparationStepsListsIds = new HashSet<string>(selectedPreparationStepsLists);

            var preparationStepsListsOfARecipe = new HashSet<string>(
                    recipe.PreparationStepsList.Select(psl => psl.PreparationStep.Id)
                );

            var allPreparationSteps = _preparationStepRepository.GetAllAsNoTracking();

            foreach (var preparationStep in allPreparationSteps)
            {
                if (selectedPreparationStepsListsIds.Contains(preparationStep.Id))
                {
                    if (!preparationStepsListsOfARecipe.Contains(preparationStep.Id))
                    {
                        recipe.PreparationStepsList.Add(new PreparationStepsList
                        {
                            RecipeId = recipe.Id,
                            PreparationStepId = preparationStep.Id
                        });
                    }
                }
                else
                {
                    if (preparationStepsListsOfARecipe.Contains(preparationStep.Id))
                    {
                        PreparationStepsList preparationStepsListToRemove =
                           recipe.PreparationStepsList
                               .FirstOrDefault(psl =>
                                     psl.PreparationStepId == psl.Id
                                  );
                        _preparationStepsListRepository.Delete(preparationStepsListToRemove);
                    }
                }
            }

            if (selectedRecipeIngredients == null)
            {
                recipe.RecipeIngredients = new List<RecipeIngredients>();
                return;
            }

            var selectedRecipeIngredientsIds = new HashSet<string>(selectedRecipeIngredients);

            var ingredientsOfARecipe = new HashSet<string>(
                    recipe.RecipeIngredients.Select(ri => ri.Ingredient.Id)
                );

            var allIngredients = _ingredientRepository.GetAllAsNoTracking();

            foreach (var ingredient in allIngredients)
            {
                if (selectedRecipeIngredientsIds.Contains(ingredient.Id))
                {
                    if (!ingredientsOfARecipe.Contains(ingredient.Id))
                    {
                        recipe.RecipeIngredients.Add(new RecipeIngredients
                        {
                            RecipeId = recipe.Id,
                            IngredientId = ingredient.Id
                        });
                    }
                }
                else
                {
                    if (ingredientsOfARecipe.Contains(ingredient.Id))
                    {
                        RecipeIngredients recipeIngredientToRemove =
                           recipe.RecipeIngredients
                               .FirstOrDefault(ri =>
                                     ri.IngredientId == ri.IngredientId
                                  );
                        _recipeIngredientsRepository.Delete(recipeIngredientToRemove);
                    }
                }
            }

            var measurementsOfARecipe = new HashSet<string>(
                    recipe.RecipeIngredients.Select(ri => ri.Measurement.Id)
                );

            var allMeasurements = _measurementRepository.GetAllAsNoTracking();

            foreach (var measurement in allMeasurements)
            {
                if (selectedRecipeIngredientsIds.Contains(measurement.Id))
                {
                    if (!measurementsOfARecipe.Contains(measurement.Id))
                    {
                        recipe.RecipeIngredients.Add(new RecipeIngredients
                        {
                            RecipeId = recipe.Id,
                            MeasurementId = measurement.Id
                        });
                    }
                }
                else
                {
                    if (measurementsOfARecipe.Contains(measurement.Id))
                    {
                        RecipeIngredients recipeIngredientToRemove =
                           recipe.RecipeIngredients
                               .FirstOrDefault(ri =>
                                     ri.MeasurementId == ri.MeasurementId
                                  );
                        _recipeIngredientsRepository.Delete(recipeIngredientToRemove);
                    }
                }
            }
        }
    }
}