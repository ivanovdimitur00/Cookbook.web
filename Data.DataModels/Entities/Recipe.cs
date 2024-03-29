﻿using Data.DataModels.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.DataModels.Entities.Identity;
using System.Xml.Linq;

namespace Data.DataModels.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
            PreparationStepsList = new HashSet<PreparationStepsList>();
            RecipeTags = new HashSet<RecipeTag>();
            Comments = new HashSet<Comment>();
            Favourites = new HashSet<Favourites>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string CountryId { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(5, 720)]
        public int PreparationTime { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(16)]
        public string PreparationTimeUnit { get; set; }

        [Required]
        [Range(1, 24)]
        public int Servings { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }

        public virtual ICollection<PreparationStepsList> PreparationStepsList { get; set; }

        public virtual ICollection<RecipeTag> RecipeTags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Favourites> Favourites { get; set; }

    }
}
