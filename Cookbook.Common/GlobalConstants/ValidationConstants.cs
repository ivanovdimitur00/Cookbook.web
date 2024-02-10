using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Common.GlobalConstants
{
    public class ValidationConstants
    {
        //related to length or size of number

        //ApplicationUser
        public const string ApplicationUserFirstNameMinimumLengthValidationMessage = "The first name of the " +
            "user cannot be shorter than 2 symbols";
        
        public const string ApplicationUserFirstNameMaximumLengthValidationMessage = "The first name of the " +
            "user cannot be longer than 30 symbols";
        
        public const string ApplicationUserLastNameMinimumLengthValidationMessage = "The last name of the " +
            "user cannot be shorter than 2 symbols";
        
        public const string ApplicationUserLastNameMaximumLengthValidationMessage = "The last name of the " +
            "user cannot be longer than 30 symbols";

        public const string ApplicationUserNicknameMinimumLengthValidationMessage = "The nickname of the " +
            "user cannot be shorter than 2 symbols";

        public const string ApplicationUserNicknameMaximumLengthValidationMessage = "The nickname of the " +
            "user cannot be longer than 30 symbols";

        //Country
        public const string CountryNameMinimumLengthValidationMessage = "The country name " +
            "cannot be shorter than 2 symbols";

        public const string CountryNameMaximumLengthValidationMessage = "The country name " +
            "cannot be longer than 20 symbols";

        //Ingredient
        public const string IngredientNameMinimumLengthValidationMessage = "The ingredient name " +
            "cannot be shorter than 2 symbols";

        public const string IngredientNameMaximumLengthValidationMessage = "The ingredient name " +
            "cannot be longer than 30 symbols";

        //Measurement
        public const string MeasurementUnitMinimumLengthValidationMessage = "The name of the " +
            "measurement unit cannot be shorter than 1 symbol";

        public const string MeasurementUnitMaximumLengthValidationMessage = "The name of the " +
            "measuremnt unit cannot be longer than 20 symbols";

        public const string MeasurementQuantityRangeValidationMessage = "The quantity of the " +
            "measurement must be in the range 0.05 - 100,000.00 units";

        //PreparationStep
        public const string PreparationStepNumberRangeValidationMessage = "The number of the " +
            "preparation step must be in the range 1 - 24";

        public const string PreparationStepDescriptionMaximumLengthValidationMessage = "The description of the " +
            "preparation step cannot be longer than 500 symbols";

        //Recipe
        public const string RecipeTitleMinimumLengthValidationMessage = "The title of the " +
            "recipe cannot be shorter than 2 symbols";

        public const string RecipeTitleNameMaximumLengthValidationMessage = "The title of the " +
            "recipe cannot be longer than 30 symbols";

        public const string RecipeDescriptionMinimumLengthValidationMessage = "The description of the " +
            "recipe cannot be shorter than 20 symbols";

        public const string RecipeDescriptionMaximumLengthValidationMessage = "The description of the " +
            "recipe cannot be longer than 500 symbols";

        public const string RecipePreparationtimeRangeValidationMessage = "The preparation time of the " +
            "recipe must be in the range 5 - 720 units";

        public const string RecipeServingsRangeValidationMessage = "The servings of the " +
            "recipe must be in the range 1 - 24 units";

        public const string RecipePreparationTimeUnitMinimumLengthValidationMessage = "The unit of the " +
            "preparation time cannot be shorter than 1 symbol";

        public const string RecipePreparationTimeUnitMaximumLengthValidationMessage = "The unit of the " +
            "preparation time cannot be longer than 16 symbols";

        //Tag
        public const string TagNameMinimumLengthValidationMessage = "The name of the " +
            "tag cannot be shorter than 2 symbols";

        public const string TagNameMaximumLengthValidationMessage = "The name of the " +
            "tag cannot be longer than 30 symbols";
    }
}
