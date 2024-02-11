using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Cookbook.Web.Models.Tags.BindingModels;
using Cookbook.Web.Models.Tags.ViewModels;
using Cookbook.Web.Models.Recipes.ViewModels;
using Cookbook.Web.Models.Mapping;
using Data.DataAccess.Repositories.Implementation;
using Cookbook.Web.Models.Ingredients.ViewModels;
using Cookbook.Web.Models.Measurements.BindingModels;
using Cookbook.Web.Models.PreparationSteps.ViewModels;
using Cookbook.Web.Models.Ingredients.BindingModels;
using System.Diagnostics.Metrics;

namespace Cookbook.Business.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        private readonly IRecipeRepository _recipeRepository;

        private readonly IRecipeTagRepository _recipeTagRepository;

        public TagService(
            ITagRepository tagRepository,
            IRecipeRepository recipeRepository,
            IRecipeTagRepository recipeTagRepository
        )
        {
            _tagRepository = tagRepository;
            _recipeRepository = recipeRepository;
            _recipeTagRepository = recipeTagRepository;
        }

        public IEnumerable<AllTagsViewModel> GetAllTags()
        {
            List<AllTagsViewModel> allTags = _tagRepository
                 .GetAllAsNoTracking()
                    .OrderBy(t => t.Name)
                        .Select(t => new AllTagsViewModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                        })
                        .ToList();

            return allTags;

        }

        public CreateTagBindingModel GetTagCreatingDetails()
        {
            var tag = new Tag();

            var tagCreationDetails = new CreateTagBindingModel
            {
                Name = tag.Name,
                AssignedRecipeTags = PopulateAssignedRecipeTagsData(tag)
            };

            return tagCreationDetails;
        }

        public TagDetailsViewModel GetTagDetails(string tagId)
        {
            var singleTag = _tagRepository
                    .GetAllByCondition(t => t.Id == tagId)
                         .FirstOrDefault();

            if (singleTag is null)
            {
                return null;
            }

            var singleTagDetails = new TagDetailsViewModel
            {
                Id = singleTag.Id,
                Name = singleTag.Name,
                CreatedOn = singleTag.CreatedOn,
                CreatedBy = singleTag.CreatedBy,
                ModifiedOn = singleTag.ModifiedOn,
                ModifiedBy = singleTag.ModifiedBy
            };

            return singleTagDetails;
        }

        public bool CreateTag(CreateTagBindingModel createTagBindingModel, string[] selectedRecipeTags, string currentUserName)
        {
            Tag tagToCreate = new Tag
            {
                Name = createTagBindingModel.Name,
            };

            var allTags = _tagRepository.GetAllAsNoTracking();

            if (_tagRepository.Exists(allTags, tagToCreate))
            {
                return false;
            }

            if (selectedRecipeTags != null)
            {
                foreach (var recipeTagsId in selectedRecipeTags)
                {
                    var recipeTagToAdd = new RecipeTag
                    {
                        RecipeId = recipeTagsId,
                        TagId = tagToCreate.Id
                    };

                    tagToCreate.RecipeTags.Add(recipeTagToAdd);
                }
            }

            tagToCreate.CreatedBy = currentUserName;

            _tagRepository.Add(tagToCreate);

            return true;
        }

        public EditTagBindingModel GetTagEditingDetails(string tagId)
        {
            var tagToEdit = _tagRepository
                    .GetAllByCondition(t => t.Id == tagId)
                        .Include(t => t.RecipeTags)
                            .ThenInclude(rt => rt.Recipe)
                                .FirstOrDefault();

            if (tagToEdit is null)
            {
                return null;
            }

            var tagToEditDetails = new EditTagBindingModel
            {
                Id = tagToEdit.Id,
                Name = tagToEdit.Name,
                AssignedRecipeTags = PopulateAssignedRecipeTagsData(tagToEdit)
            };

            return tagToEditDetails;
        }

        public bool EditTag(EditTagBindingModel editTagBindingModel, string[] selectedRecipeTags, string currentUserName)
        {
            var tagToUpdate = _tagRepository
                        .GetAllByCondition(t => t.Id == editTagBindingModel.Id)
                            .Include(t => t.RecipeTags)
                                .ThenInclude(rt => rt.Recipe)
                                    .FirstOrDefault();

            tagToUpdate.Name = editTagBindingModel.Name;

            var filteredTags = _tagRepository
                .GetAllAsNoTracking()
                    .Where(t => !t.Id.Equals(tagToUpdate.Id))
                        .AsQueryable();

            if (_tagRepository.Exists(filteredTags, tagToUpdate))
            {
                return false;
            }

            tagToUpdate.ModifiedBy = currentUserName;

            _tagRepository.Update(tagToUpdate);

            UpdateRecipeTagsByTag(selectedRecipeTags, tagToUpdate);

            return true;
        }

        public DeleteTagViewModel GetTagDeletionDetails(string tagId)
        {
            var tagToDelete = FindTag(tagId);

            if (tagToDelete is null)
            {
                return null;
            }

            var tagToDeleteDetails = new DeleteTagViewModel
            {
                Name = tagToDelete.Name,
            };

            return tagToDeleteDetails;
        }

        public void DeleteTag(Tag tag)
        {
            var recipeTagsByTag = _recipeTagRepository
                    .GetAllByCondition(ri => ri.TagId == tag.Id)
                        .ToArray();

            if (recipeTagsByTag.Any())
            {
                _recipeTagRepository.DeleteRange(recipeTagsByTag);
            }

            _tagRepository.Delete(tag);
        }

        public Tag FindTag(string tagId)
        {
            return _tagRepository.GetById(tagId);
        }

        private List<AssignedRecipeTagsDataViewModel> PopulateAssignedRecipeTagsData(
           Tag tag
        )
        {
            var allRecipes = _recipeRepository
              .GetAllAsNoTracking()
                  .ToList();

            var RecipesOfATag = new HashSet<string>(tag.RecipeTags
                .Select(rt => rt.Recipe.Id));

            var assignedRecipeTagsDataViewModel =
                    new List<AssignedRecipeTagsDataViewModel>();

            foreach (var recipe in allRecipes)
            {
                assignedRecipeTagsDataViewModel.Add(new AssignedRecipeTagsDataViewModel
                {
                    RecipeTagId = tag.Id,
                    Name = tag.Name,
                    IsAssigned = RecipesOfATag.Contains(tag.Id)
                });
            }

            return assignedRecipeTagsDataViewModel;
        }

        private void UpdateRecipeTagsByTag(string[] selectedRecipeTags, Tag tag)
        {
            if (selectedRecipeTags == null)
            {
                tag.RecipeTags = new List<RecipeTag>();
                return;
            }

            var selectedRecipeTagsIds = new HashSet<string>(selectedRecipeTags);

            var RecipesOfATag = new HashSet<string>(tag.RecipeTags
                 .Select(rt => rt.Recipe.Id));

            var allRecipes = _recipeRepository
                .GetAllAsNoTracking();

            foreach (var recipe in allRecipes)
            {
                if (selectedRecipeTagsIds.Contains(recipe.Id))
                {
                    if (!RecipesOfATag.Contains(recipe.Id))
                    {
                        tag.RecipeTags.Add(new RecipeTag
                        {
                            RecipeId = recipe.Id,
                            TagId = tag.Id
                        });
                    }
                }
                else
                {
                    if (RecipesOfATag.Contains(recipe.Id))
                    {
                        RecipeTag recipeTagToRemove =
                            tag.RecipeTags
                                    .FirstOrDefault(rt =>
                                        rt.RecipeId == recipe.Id
                                    );

                        _recipeTagRepository.Delete(recipeTagToRemove);
                    }
                }
            }
        }
    }
    
}
