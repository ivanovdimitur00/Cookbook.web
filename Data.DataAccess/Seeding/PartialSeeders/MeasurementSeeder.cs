using Data.DataModels.Entities;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class MeasurementSeeder
    {
        internal static Measurement[] measurementSeedingArray { get; private set; } = SeedMeasurements();

        private static Measurement[] SeedMeasurements()
        {
            var measurementsToSeed = new Measurement[]
                {
                    new Measurement()
                    {
                        Quantity = 2,
                        Unit = "medium or large",
                    },
                    new Measurement()
                    {
                        Quantity = 2,
                        Unit = "large",
                    },
                    new Measurement()
                    {
                        Quantity = 200,
                        Unit = "grams",
                    },
                    new Measurement()
                    {
                        Quantity = 10,
                        Unit = "grams",
                    },
                    new Measurement()
                    {
                        Quantity = 75,
                        Unit = "mililiters",
                    },
                    new Measurement()
                    {
                        Quantity = 1,
                        Unit = "pinch",
                    },
                    new Measurement()
                    {
                        Quantity = 500,
                        Unit = "grams",
                    },
                    new Measurement()
                    {
                        Quantity = 70,
                        Unit = "mililiters",
                    },
                    new Measurement()
                    {
                        Quantity = 2,
                        Unit = "tablespoons",
                    },
                    new Measurement()
                    {
                        Quantity = 1,
                        Unit = "tablespoon",
                    },
                    new Measurement()
                    {
                        Quantity = 15,
                        Unit = "grams",
                    },
                    new Measurement()
                    {
                        Quantity = 3,
                        Unit = "medium or large",
                    },
                    new Measurement()
                    {
                        Quantity = 100,
                        Unit = "grams",
                    },
                };
            return measurementsToSeed;
        }
    }
}
