using System.ComponentModel;

namespace Cookbook.Web.Models.Recipes.ViewModels
{
    public class DeleteSubtitlesViewModel
    {
        public string Title { get; set; }

        [DisplayName("Date of Creation")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Image")]
        public string ImageName { get; set; }
    }
}
