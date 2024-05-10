using System;
using static Recipe_App.ConsoleCustomization;

namespace Recipe_App
{
    internal static class Recipes
    {
        public static void PrintRecipe(List<string> ingredientsName, List<double> ingredientsAmount, List<string> ingredientsUnit, List<string> steps)
        {
            try
            {
                // Check if any of the input lists are null
                if (ingredientsName == null || ingredientsAmount == null || ingredientsUnit == null || steps == null)
                {
                    throw new ArgumentNullException("One or more input lists are null.");
                }

                // Check if the number of ingredients is not equal to the number of amounts or units
                if (ingredientsName.Count != ingredientsAmount.Count || ingredientsName.Count != ingredientsUnit.Count)
                {
                    throw new ArgumentException("Number of ingredients, amounts, and units must match.");
                }

                // Check if there are any ingredients in the recipe
                if (ingredientsName.Count == 0)
                {
                    ConsoleCustomization.SetColor("There are no ingredients in the recipe.", Colours.Black, Colours.Red, true, true);
                    ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Red, true, true);
                    return;
                }
                else
                {
                    // Print the ingredients
                    ConsoleCustomization.SetColor("Ingredients: ", Colours.Black, Colours.White, true, false);
                    // Loop through the List and print the ingredients
                    for (int i = 0; i < ingredientsName.Count; i++)
                    {
                        // Print the ingredients
                        ConsoleCustomization.SetColor($"{ingredientsAmount[i]} {ingredientsUnit[i]} of {ingredientsName[i]}", Colours.Black, Colours.White, true, false);
                    }
                }
                // Check if there are any steps in the recipe
                if (steps.Count == 0)
                {
                    ConsoleCustomization.SetColor("There are no steps in the recipe.", Colours.Black, Colours.Red, true, true);
                    ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Red, true, true);
                    return;
                }
                else
                {
                    // Print the steps
                    ConsoleCustomization.SetColor("\nSteps: ", Colours.Black, Colours.White, true, false);
                    // Loop through the List and print the steps
                    for (int i = 0; i < steps.Count; i++)
                    {
                        // Print the steps
                        ConsoleCustomization.SetColor($"{(i + 1)}. {steps[i]}", Colours.Black, Colours.White, true, false);
                    }
                }
                ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Red, true, true);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

    }
}

