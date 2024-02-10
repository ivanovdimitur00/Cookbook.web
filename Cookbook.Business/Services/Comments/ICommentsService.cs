using Cookbook.Web.Models.Comments.BindingModels;
using Cookbook.Web.Models.Comments.ViewModels;
using Cookbook.Web.Models.Recipes;


namespace Cookbook.Business.Services.Comments
{
    public interface ICommentService
    {
        bool CreateComment(CreateCommentBindingModel createCommentBindingModel, string recipeId, string userId);

        IEnumerable<AllCommentsForRecipeViewModel> GetAllCommentsForRecipe(string recipeId);
    }
}
