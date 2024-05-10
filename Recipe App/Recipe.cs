using System;

namespace Recipe_App
{
    internal static class Recipes
    {
        public static void PrintRecipe(List<string> ingredientsName, List<double> ingredientsAmount, List<string> ingredientsUnit, List<string> steps)
        {
            // Check if there are any ingredients in the recipe
            if (ingredientsName.Count == 0)
            {
                Console.WriteLine("There are no ingredients in the recipe.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                return;
            }
            else
            {
                // Print the ingredients
                Console.WriteLine("Ingredients: ");
                // Loop through the List and print the ingredients
                for (int i = 0; i < ingredientsName.Count; i++)
                {
                    // Print the ingredients
                    Console.WriteLine(ingredientsAmount[i] + " " + ingredientsUnit[i] + " of " + ingredientsName[i]);
                }
            }
            // Check if there are any steps in the recipe
            if (steps.Count == 0)
            {
                Console.WriteLine("There are no steps in the recipe.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                return;
            }
            else
            {
                // Print the steps
                Console.WriteLine("\nSteps: ");
                // Loop through the List and print the steps
                for (int i = 0; i < steps.Count; i++)
                {
                    // Print the steps
                    Console.WriteLine((i + 1) + ". " + steps[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
        }
    }
}

