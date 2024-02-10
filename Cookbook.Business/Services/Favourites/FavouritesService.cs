using Data.DataAccess.Repositories.Interfaces;
using Cookbook.Web.Models.Favourites;
using Cookbook.Web.Models.Recipes.ViewModels;

namespace Cookbook.Business.Services.Favourites
{
    public class FavouritesService : IFavouritesService
    {
        private readonly IFavouritesRepository _favouritesRepository;

        private readonly IRecipeRepository _recipeRepository;

        public FavouritesService(
            IFavouritesRepository favouritesRepository,
            IRecipeRepository recipeRepository
        )
        {
            _favouritesRepository = favouritesRepository;
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<UserFavouritesViewModel> GetAllUserFavourites(string userId)
        {
            List<string> allUserFavouritesRecipeIds = _favouritesRepository
                .GetAllByCondition(f => f.ApplicationUserId == userId)
                    .Select(f => f.RecipeId)
                        .ToList();

            List<UserFavouritesViewModel> allUserFavourites = _recipeRepository
                .GetAllByCondition(s => allUserFavouritesRecipeIds.Contains(s.Id))
                    .Select(s => new UserFavouritesViewModel
                    {
                        Id = s.Id,
                        Title = s.Title,
                        UploaderUserName = s.ApplicationUser.UserName,
                        RelatedRecipes = new RecipeConciseInformationViewModel
                        {
                            Title = s.Title
                        }
                    })
                    .OrderBy(uf => uf.Title)
                    .ToList();

            return allUserFavourites;
        }

        public bool AddToFavourites(string userId, string recipeId)
        {
            Data.DataModels.Entities.Favourites favouritesToCreate = new Data.DataModels.Entities.Favourites
            {
                ApplicationUserId = userId,
                RecipeId = recipeId
            };

            var allFavourites = _favouritesRepository.GetAllAsNoTracking();

            if (_favouritesRepository.Exists(allFavourites, favouritesToCreate))
            {
                return false;
            }

            _favouritesRepository.Add(favouritesToCreate);

            return true;
        }

        public void RemoveFromFavourites(Data.DataModels.Entities.Favourites favourites)
        {
            _favouritesRepository.Delete(favourites);
        }

        public Data.DataModels.Entities.Favourites FindFavourites(string userId, string recipeId)
        {
            return _favouritesRepository
                .GetAllByCondition(f => f.ApplicationUserId == userId && f.RecipeId == recipeId)
                    .FirstOrDefault();
        }
    }
}