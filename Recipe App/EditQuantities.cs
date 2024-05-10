using System;
using System.Collections.Generic;

namespace Recipe_App
{
    public class EditQuantities
    {
        // Method for scaling
        public static void ConvertUnits(List<string> ingredientsList, List<double> originalQuantities)
        {
            // Check if there are any ingredients in the recipe
            if (ingredientsList.Count <= 0)
            {
                Console.WriteLine("There are no ingredients in the recipe.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                return;
            }

            else
            {
                double factor = 1;
                // Prompt the user to enter the unit of measurement they want to convert to
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("See the recipe at a different scale: ");
                Console.ResetColor();
                Console.WriteLine("Enter the number corresponding with the scale value you require: \n" +
                    "1: A factor of 0.5 (half)\n" +
                    "2: A factor of 2 (double)\n" +
                    "3: A factor of 3 (triple)\n" +
                    "4: Return to the main menu");
                int option = Convert.ToInt32(Console.ReadLine());
                // Set the factor based on the user's choice
                switch (option)
                {
                    case 1:
                        factor = 0.5;
                        break;
                    case 2:
                        factor = 2;
                        break;
                    case 3:
                        factor = 3;
                        break;
                    case 4:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                // Convert the units
                if (originalQuantities.Count <= 0)
                {
                    Console.WriteLine("There are no ingredients to scale.");
                    return;
                }
                else
                {
                    // Loop through the List and scale the quantities
                    for (int i = 0; i < originalQuantities.Count; i++)
                    {
                        // Scale the quantities
                        double scaledQuantity = originalQuantities[i] * factor;
                        originalQuantities[i] = scaledQuantity;
                    }
                }

                Console.WriteLine("The recipe has been scaled: ");
                PrintRecipe();
                Console.WriteLine("Do you wish to reset the quantities to their original values? (y/n) ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    ResetQuantities(ingredientsList, originalQuantities);
                }
            }
        }
        public static void ResetQuantities(List<string> ingredientsAmount, List<double> originalQuantities)
        {
            ConsoleCustomization.SetColor("There are no ingredients in the recipe.", ConsoleCustomization.Colours.Red, ConsoleCustomization.Colours.White, true, false);
            if (ingredientsAmount.Count <= 0)
            {
                return;
            }

            ConsoleCustomization.SetColor("Are you sure you want to reset the quantities? (y/n) ", ConsoleCustomization.Colours.Yellow, ConsoleCustomization.Colours.White, false, false);
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                ConsoleCustomization.SetColor("The recipe has been reset: ", ConsoleCustomization.Colours.Red, ConsoleCustomization.Colours.White, true, false);
                ingredientsAmount.Clear();
                ingredientsAmount.AddRange(originalQuantities);
                ConsoleCustomization.SetColor("The Original Recipe: ", ConsoleCustomization.Colours.Red, ConsoleCustomization.Colours.White, true, false);
                PrintRecipe(ingredientsAmount);
            }
        }

        private void PrintRecipe(IEnumerable<double> ingredientsAmount)
        {
            foreach (var ingredient in ingredientsAmount)
            {
                Console.WriteLine(ingredient);
            }
        }

        // Clear the data
        public static void ClearData(List<string> ingredientsName, List<double> ingredientsAmount, List<string> ingredientsUnit, List<string> steps, List<double> originalQuantities>)
        {
            Console.WriteLine("Are you sure you want to clear the data? (y/n) ");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                // Clear the data
                Console.WriteLine("The data has been cleared.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                // Clearing the data in the Lists
                ingredientsName.Clear();
                ingredientsAmount.Clear();
                ingredientsUnit.Clear();
                steps.Clear();
                originalQuantities.Clear();
            }
            else
            {
                return;
            }
        }
    }
} 
