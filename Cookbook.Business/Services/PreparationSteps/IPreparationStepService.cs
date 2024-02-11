using Data.DataModels.Entities;
using Cookbook.Web.Models.PreparationSteps.BindingModels;
using Cookbook.Web.Models.PreparationSteps.ViewModels;
using System.IO;

namespace Cookbook.Business.Services.PreparationSteps
{
    public interface IPreparationStepService
    {
        IEnumerable<AllPreparationStepsViewModel> GetAllPreparationSteps();

        CreatePreparationStepsBindingModel GetPreparationStepCreatingDetails();

        PreparationStepDetailsViewModel GetPreparationStepDetails(string preparationStepId);

        bool CreatePreparationStep(CreatePreparationStepsBindingModel createPreparationStepBindingModel, string[] selectedPreparationStepsList, string currentUserName);

        EditPreparationStepsBindingModel GetPreparationStepEditingDetails(string preparationStepId);

        bool EditPreparationStep(EditPreparationStepsBindingModel editPreparationStepBindingModel, string[] selectedPreparationStepsList, string currentUserName);

        DeletePreparationStepViewModel GetPreparationStepDeletionDetails(string preparationStepId);

        void DeletePreparationStep(PreparationStep preparationStep);

        PreparationStep FindPreparationStep(string preparationStepId);
    }
}
