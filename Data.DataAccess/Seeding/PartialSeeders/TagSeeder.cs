using Data.DataModels.Entities;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class TagSeeder
    {
        internal static Tag[] tagSeedingArray { get; private set; } = SeedTags();

        private static Tag[] SeedTags()
        {
            var tagsToSeed = new Tag[]
                {
                    new Tag()
                    {
                        Name = "bread",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "sweet",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "breakfast",
                        CreatedOn = DateTime.UtcNow,
                    },

                    new Tag()
                    {
                        Name = "main dish",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "legume",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "soup",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "stew",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "lunch",
                        CreatedOn = DateTime.UtcNow,
                    },
                    new Tag()
                    {
                        Name = "dinner",
                        CreatedOn = DateTime.UtcNow,
                    },
                };

            return tagsToSeed;
        }
    }
}
