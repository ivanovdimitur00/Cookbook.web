﻿using Data.DataModels.Entities;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class CountrySeeder
    {
        internal static Country[] countrySeedingArray { get; private set; } = SeedCountries();

        private static Country[] SeedCountries()
        {
            var countriesToSeed = new Country[]
            {
                new Country()
                {
                    Name = "USA",
                    CreatedOn = DateTime.UtcNow
                },
                new Country()
                {
                    Name = "UK",
                    CreatedOn = DateTime.UtcNow
                },
                new Country()
                {
                    Name = "Germany",
                    CreatedOn = DateTime.UtcNow
                },
                new Country()
                {
                    Name = "Spain",
                    CreatedOn = DateTime.UtcNow
                },
                new Country()
                {
                    Name = "Australia",
                    CreatedOn = DateTime.UtcNow
                },
                new Country()
                {
                    Name = "Bulgaria",
                    CreatedOn = DateTime.UtcNow
                }
            };

            return countriesToSeed;
        }
    }
}