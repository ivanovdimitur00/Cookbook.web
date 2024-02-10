using Data.DataAccess.Repositories.Interfaces;
using Data.DataModels.Entities;
using Cookbook.Web.Models.Comments.BindingModels;
using Cookbook.Web.Models.Comments.ViewModels;

namespace Cookbook.Business.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public bool CreateComment(CreateCommentBindingModel createCommentBindingModel, string recipeId, string userId)
        {
            Comment commentToCreate = new Comment()
            {
                Content = createCommentBindingModel.Content,
                RecipeId = recipeId,
                ApplicationUserId = userId
            };

            var allComments = _commentRepository.GetAllAsNoTracking();

            if (_commentRepository.Exists(allComments, commentToCreate))
            {
                return false;
            }

            _commentRepository.Add(commentToCreate);

            return true;
        }

        public IEnumerable<AllCommentsForRecipeViewModel> GetAllCommentsForRecipe(string recipeId)
        {
            var allCommentsForRecipe = _commentRepository
                .GetAllAsNoTracking()
                    .Where(c => c.RecipeId == recipeId)
                    .Select(c => new AllCommentsForRecipeViewModel
                    {
                        Username = c.ApplicationUser.UserName,
                        CreatedOn = c.CreatedOn,
                        Content = c.Content,
                    })
                    .ToList();

            return allCommentsForRecipe;
        }
    }
}
