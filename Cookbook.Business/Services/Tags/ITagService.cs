using Data.DataModels.Entities;
using Cookbook.Web.Models.Tags.BindingModels;
using Cookbook.Web.Models.Tags.ViewModels;
using System.IO;

namespace Cookbook.Business.Services.Tags
{
    public interface ITagService
    {
        IEnumerable<AllTagsViewModel> GetAllTags();

        CreateTagBindingModel GetTagCreatingDetails();

        TagDetailsViewModel GetTagDetails(string tagId);

        bool CreateTag(CreateTagBindingModel createTagBindingModel, string[] selectedRecipeTags, string currentUserName);

        EditTagBindingModel GetTagEditingDetails(string tagId);

        bool EditTag(EditTagBindingModel editTagBindingModel, string[] selectedRecipeTags, string currentUserName);

        DeleteTagViewModel GetTagDeletionDetails(string tagId);

        void DeleteTag(Tag tag);

        Tag FindTag(string tagId);
    }
}
