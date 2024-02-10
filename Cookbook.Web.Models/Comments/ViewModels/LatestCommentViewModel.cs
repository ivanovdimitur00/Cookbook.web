using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Comments.ViewModels
{
    public class LatestCommentViewModel
    {
        public string RecipeId { get; set; }

        public string RecipeName { get; set; }

        public string UserName { get; set; }
    }
}
