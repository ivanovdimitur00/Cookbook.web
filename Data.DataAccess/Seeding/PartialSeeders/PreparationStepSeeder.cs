using Data.DataModels.Entities;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class PreparationStepSeeder
    {
        internal static PreparationStep[] preparationStepSeedingArray { get; private set; } = SeedPreparationSteps();
        private static PreparationStep[] SeedPreparationSteps()
        {
            var preparationStepToSeed = new PreparationStep[]
                {
                    new PreparationStep()
                    {
                        Number = 1,
                        Description = "Mix the Sugar, eggs and oil. Whisk together. Add a pinch of salt."
                    },
                    new PreparationStep()
                    {
                        Number = 2,
                        Description = "Mash the bananans and mix them in."
                    },
                    new PreparationStep()
                    {
                        Number = 3,
                        Description = "Sift the flour and baking soda. mix them in slowly."
                    },
                    new PreparationStep()
                    {
                        Number = 4,
                        Description = "Pour the mix in a bread baking tray."
                    },
                    new PreparationStep()
                    {
                        Number = 5,
                        Description = "Bake in the oven on 170 degrees for around 40 minutes or until done."
                    },

                    new PreparationStep()
                    {
                        Number = 1,
                        Description = "Put the beans in a pot with water and boil until 3/4 done. time depends on the type of beans."
                    },
                    new PreparationStep()
                    {
                        Number = 2,
                        Description = "Cut up the carrots and onions and add them to the pot."
                    },
                    new PreparationStep()
                    {
                        Number = 3,
                        Description = "Boil the mix for around 20 - 30 minutes. then add the beans spice mix."
                    },
                    new PreparationStep()
                    {
                        Number = 4,
                        Description = "In a small saucepan, add the oil and bring it to hot. "
                    },
                    new PreparationStep()
                    {
                        Number = 5,
                        Description = "Add the flour and stir it in."
                    },
                    new PreparationStep()
                    {
                        Number = 6,
                        Description = "Add the paprika powder and stir it in."
                    },
                    new PreparationStep()
                    {
                        Number = 7,
                        Description = "Pour the mixture into the pot. Wait 5 - 10 minutes. The dish is done."
                    },

                    new PreparationStep()
                    {
                        Number = 1,
                        Description = "Put the lentils in a pot with water and boil for 1 hour."
                    },
                    new PreparationStep()
                    {
                        Number = 2,
                        Description = "Cut up the carrots and onions and add them to the pot."
                    },
                    new PreparationStep()
                    {
                        Number = 3,
                        Description = "Boil the mix for around 20 - 30 minutes. then add some spices."
                    },
                    new PreparationStep()
                    {
                        Number = 4,
                        Description = "In a small saucepan, add the oil and bring it to hot. "
                    },
                    new PreparationStep()
                    {
                        Number = 5,
                        Description = "Add the flour and stir it in."
                    },
                    new PreparationStep()
                    {
                        Number = 6,
                        Description = "Add the paprika powder and stir it in."
                    },
                    new PreparationStep()
                    {
                        Number = 7,
                        Description = "Pour the mixture into the pot. Wait 5 - 10 minutes. The dish is done."
                    },

                    new PreparationStep()
                    {
                        Number = 1,
                        Description = "Break the eggs in a bowl and whisk them.Add salt and pepper to taste."
                    },
                    new PreparationStep()
                    {
                        Number = 2,
                        Description = "Crush the white cheese and mix it in."
                    },
                    new PreparationStep()
                    {
                        Number = 3,
                        Description = "Cook in a heated pan, lightly greased. mix from time to time, untill hardened."
                    }
                };

            return preparationStepToSeed;
        }
    }
}
