using System;
using System.Collections.Generic;

namespace Recipe_App
{
    public class EditQuantities
    {
        // Method to scale quantities
        public static void ConvertUnits(List<Recipe> recipes)
        {
            // Check if there are any recipes in the list
            if (recipes.Count <= 0)
            {
                // Display error message and return
                ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, false, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();
                return;
            }

            // Display list of recipes for user to select from
            ConsoleCustomization.SetColor("Select a recipe to scale its quantities: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);

            int choice = 0;
            foreach (Recipe recipe in recipes)
            {
                choice++;
                // Display recipe information
                ConsoleCustomization.SetColor($"[{choice}]. Recipe Name: {recipe.GetName()}\t| Calories: {HelperClass.CalculateTotalCalories(recipe)}\t| Ingredients amount: {recipe.GetIngredients().Count}\t| Steps amount: {recipe.GetSteps().Count}", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
            }

            // Ask the user which recipe number they would like to scale
            ConsoleCustomization.SetColor("Enter the number of the recipe you would like to scale: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, false, true);
            string? input = Console.ReadLine();
            while (input == null || !HelperClass.ValidInteger(input) || int.Parse(input) < 1 || int.Parse(input) > recipes.Count)
            {
                // Display error message if input is invalid
                ConsoleCustomization.SetColor("Invalid input. Please enter a valid number: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, false, true);
                input = Console.ReadLine();
            }

            int index = int.Parse(input) - 1;
            if (index < 0 || index >= recipes.Count)
            {
                // Display error message if input is invalid
                ConsoleCustomization.SetColor("Invalid input. Please enter a valid number: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, false, true);
                return;
            }

            int ans = int.Parse(input);
            int count = 0;

            foreach (Recipe recipe in recipes)
            {
                if (count == ans - 1)
                {
                    List<Ingredients> ingredients = recipe.GetIngredients();
                    string factorStr;
                    float factor;
                    while (true)
                    {
                        // Ask the user for a scaling factor between 0 and 50
                        ConsoleCustomization.SetColor("Enter a valid scaling factor between 0 and 50: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                        factorStr = Console.ReadLine();

                        if (float.TryParse(factorStr, out float parsedFactor) && parsedFactor >= 0 && parsedFactor <= 50)
                        {
                            factor = parsedFactor;
                            break;
                        }
                        else
                        {
                            // Display error message if input is invalid
                            ConsoleCustomization.SetColor("Invalid input. Please enter a valid scaling factor.", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                        }
                    }

                    int counter = 0;

                    foreach (Ingredients ingredient in ingredients)
                    {
                        // Scale the ingredient's quantity and calories by the scaling factor
                        ingredient.Quantity *= factor;
                        ingredient.Calories *= factor;
                        counter++;
                    }
                }
                else if (count > ans)
                {
                    // Break out of the loop if we've processed all the recipes up to the selected one
                    break;
                }

                count++;
            }
            // Display success message and return to the menu
            ConsoleCustomization.SetColor("The recipe has been scaled successfully!", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Green, true, true);
            ConsoleCustomization.SetColor("Press any key to continue...", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        // Method to reset quantities
        public static void ResetQuantities(List<Recipe> recipes)
        {
            // Check if there are any recipes in the list
            if (recipes.Count <= 0)
            {
                ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", ConsoleCustomization.Colours.Black,ConsoleCustomization.Colours.Red, false, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();
                return;
            }

            int choice = 0;

            // Display list of recipes for user to select from
            foreach (Recipe recipe in recipes)
            {
                ConsoleCustomization.SetColor(
                    $"\n{++choice}. Recipe Name: {recipe.GetName()} | (Calories: {HelperClass.CalculateTotalCalories(recipe)})",
                    ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
            }

            ConsoleCustomization.SetColor("Enter your choice of recipe to reset: ", ConsoleCustomization.Colours.Black,
                ConsoleCustomization.Colours.White, false, true);
            string choiceAnswer = Console.ReadLine();

            // Check if the user entered anything
            if (choiceAnswer == null)
            {
                // Handle the case where the user didn't enter anything
                Console.WriteLine("You didn't enter a choice. Please try again.");
                choiceAnswer = Console.ReadLine();
            }
            // Check if the user entered a valid number
            while (!HelperClass.ValidInteger(choiceAnswer) || int.Parse(choiceAnswer) > recipes.Count ||
                   int.Parse(choiceAnswer) < 1)
            {
                Console.WriteLine($"Enter a valid number between 1 and {recipes.Count}: ");
                choiceAnswer = Console.ReadLine();

                if (choiceAnswer == null)
                {
                    // Handle the case where the user didn't enter anything
                    Console.WriteLine("You didn't enter a choice. Please try again.");
                    choiceAnswer = Console.ReadLine();
                }
            }

            int option = int.Parse(choiceAnswer);

            ConsoleCustomization.SetColor("Are you sure you want to reset the quantities?\n1. Yes\n2. No",
                ConsoleCustomization.Colours.Yellow, ConsoleCustomization.Colours.White, false, true);
            string answer = Console.ReadLine();

            // Check if the user entered anything
            if (answer == null)
            {
                // Handle the case where the user didn't enter anything
                Console.WriteLine("You didn't enter a choice. Please try again.");
                answer = Console.ReadLine();
            }
            // Check if the user entered a valid number
            while (!HelperClass.ValidInteger(answer) || int.Parse(answer) > 2 ||
                   int.Parse(answer) < 1)
            {
                Console.WriteLine($"Enter a valid number between 1 and 2: ");
                answer = Console.ReadLine();

                if (answer == null)
                {
                    // Handle the case where the user didn't enter anything
                    Console.WriteLine("You didn't enter a choice. Please try again.");
                    answer = Console.ReadLine();
                }
            }

            int answerInt = int.Parse(answer);
            // Check if the user wants to reset the quantities
            if (answerInt == 1)
            {
                foreach (Recipe recipe in recipes)
                {
                    List<Ingredients> ingredients = recipe.GetIngredients();
                    foreach (Ingredients ingredient in ingredients)
                    {
                        var scaledFactor = ingredient.OriginalQuantity / ingredient.Quantity;
                        ingredient.Quantity = ingredient.OriginalQuantity;
                        ingredient.Calories *= scaledFactor;
                    }
                }

                ConsoleCustomization.SetColor("The recipe has been reset: ", ConsoleCustomization.Colours.Green,
                    ConsoleCustomization.Colours.White, true, true);
                Program.Menu();
            }
            else
            {
                Console.Clear();
                Program.Menu();
            }
        }


        // Clear the data
        public static void ClearData(List<Recipe> recipes)
        {
            // Check if there are any recipes
            if (recipes == null || recipes.Count == 0)
            {
                ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, false, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();
                return;
            }
            Console.WriteLine("Are you sure you want to clear the data?\n1.Yes\n2.No");
            Console.Write("Enter your choice: ");
            string answer = Console.ReadLine();
            // Check if the user entered anything
            while (answer == null || !HelperClass.ValidInteger(answer))
            {
                Console.Write("Please enter a valid option: ");
                answer = Console.ReadLine();
            }

            int.TryParse(answer, out int validAnswer);
            // Check if the user wants to clear the data
            if (validAnswer == 1)
            {
                // Clearing the data in the Lists
                recipes.Clear();
                // Clear the data
                ConsoleCustomization.SetColor("The data has been reset.", ConsoleCustomization.Colours.Green,
                    ConsoleCustomization.Colours.White, true, true);
                ConsoleCustomization.SetColor("\"============================================================================\\nPress any key to continue...",
                    ConsoleCustomization.Colours.Black,
                    ConsoleCustomization.Colours.Cyan, true, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();

            }
            else
            {
                Program.Menu();
            }
        }
    }
}