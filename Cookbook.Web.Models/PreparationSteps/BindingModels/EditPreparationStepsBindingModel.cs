﻿using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.PreparationSteps.BindingModels
{
    public class EditPreparationStepsBindingModel
    {
        public string Id { get; set; }

        [Required]
        [Range(1, 24, ErrorMessage = ValidationConstants.PreparationStepNumberRangeValidationMessage)]
        public int Number { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20,
            ErrorMessage = ValidationConstants.PreparationStepDescriptionMaximumLengthValidationMessage)]
        [DisplayName(DisplayConstants.UnitDisplayName)]
        public string Description { get; set; }

        public IEnumerable<AssignedPreparationStepsListDataViewModel>? AssignedPreparationStepsList { get; set; }
    }
}
