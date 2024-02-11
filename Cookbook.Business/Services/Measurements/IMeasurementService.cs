using Data.DataModels.Entities;
using Cookbook.Web.Models.Measurements.BindingModels;
using Cookbook.Web.Models.Measurements.ViewModels;
using System.IO;

namespace Cookbook.Business.Services.Measurements
{
    public interface IMeasurementService
    {
        IEnumerable<AllMeasurementsViewModel> GetAllMeasurements();

        CreateMeasurementBindingModel GetMeasurementCreatingDetails();

        MeasurementDetailsViewModel GetMeasurementDetails(string measurementId);

        bool CreateMeasurement(CreateMeasurementBindingModel createMeasurementBindingModel, string[] selectedRecipeIngredients, string currentUserName);

        EditMeasurementBindingModel GetMeasurementEditingDetails(string measurementId);

        bool EditMeasurement(EditMeasurementBindingModel editMeasurementBindingModel, string[] selectedRecipeIngredients, string currentUserName);

        DeleteMeasurementViewModel GetMeasurementDeletionDetails(string measurementId);

        void DeleteMeasurement(Measurement measurement);

        Measurement FindMeasurement(string measurementId);
    }
}
