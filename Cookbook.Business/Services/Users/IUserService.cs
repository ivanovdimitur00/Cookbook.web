using Cookbook.Web.Models.Users;
using Data.DataModels.Entities.Identity;

namespace Cookbook.Business.Services.Users
{
    public interface IUserService
    {
        IEnumerable<AllUsersViewModel> GetAllUsers(string currentUserId);

        Task PromoteUser(string userId);

        ApplicationUser FindUser(string userId);

        void DeclinePromotion(string userId);

        Task DemoteUser(string userId);

        void EnrollForUploaderRole(string userId);

        void EnrollForEditorRole(string userId);

        DeleteUserViewModel GetUserDeletionDetails(string userId);

        Task<bool> DeleteUser(string userId);
    }
}