using Data.DataModels.Entities;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class IngredientSeeder
    {
        internal static Ingredient[] ingredientSeedingArray { get; private set; } = SeedIngredients();

        private static Ingredient[] SeedIngredients()
        {
            var ingredientsToSeed = new Ingredient[]
                {
                    new Ingredient()
                    {
                        Name = "Eggs",
                        IsAllergen = true,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Banana",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Sugar",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Wheat flour",
                        IsAllergen = true,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Baking powder",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Sunflower seed oil",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Salt",
                        IsAllergen = true,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Beans",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Carrot",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Onion",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Paprika powder",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Beans spice mix",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Lentils",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "White cheese",
                        IsAllergen = true,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Ingredient()
                    {
                        Name = "Black pepper",
                        IsAllergen = false,
                        CreatedOn = DateTime.UtcNow
                    },
                };

            return ingredientsToSeed;
        }
    }
}
