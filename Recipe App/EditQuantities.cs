using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using static Recipe_App.ConsoleCustomization;


namespace Recipe_App
{
    public class EditQuantities
    {
        // Method for scaling
        public static void ConvertUnits(List<Recipe> recipes)
        {
            // Check if there are any ingredients in the recipe
            if (recipes.Count <= 0)
            {
                ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", Colours.Black, Colours.Red, false, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();
                return;
            }

            ConsoleCustomization.SetColor("Select a recipe to scale its quantities: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);

            int choice = 0;
            foreach (Recipe Recipe in recipes)
            {
                choice++;
                ConsoleCustomization.SetColor($"[{choice}]. Recipe Name: {Recipe.GetName()}\t| Calories: {HelperClass.CalculateTotalCalories(Recipe)}\t| Ingredients amount: {Recipe.GetIngredients().Count}\t| Steps amount: {Recipe.GetSteps().Count}", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
            }

            // Ask the user which recipe number they would like to view
            ConsoleCustomization.SetColor("Enter the number of the recipe you would like to scale: ", Colours.Black, Colours.White, false, true);
            string? input = Console.ReadLine();
            while (input == null || !HelperClass.ValidInteger(input) || int.Parse(input) < 1 || int.Parse(input) > recipes.Count)
            {
                ConsoleCustomization.SetColor("Invalid input. Please enter a valid number: ", Colours.Black, Colours.Red, false, true);
                input = Console.ReadLine();
            }

            int index = int.Parse(input) - 1;
            if (index < 0 || index >= recipes.Count)
            {
                ConsoleCustomization.SetColor("Invalid input. Please enter a valid number: ", Colours.Black, Colours.Red, false, true);
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
                        ConsoleCustomization.SetColor("Enter a valid scaling factor between 0 and 50: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                        factorStr = Console.ReadLine();

                        if (float.TryParse(factorStr, out float parsedFactor) && parsedFactor >= 0 && parsedFactor <= 50)
                        {
                            factor = parsedFactor;
                            break;
                        }
                        else
                        {
                            ConsoleCustomization.SetColor("Invalid input. Please enter a valid scaling factor.", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                        }
                    }

                    int counter = 0;

                    foreach (Ingredients ingredient in ingredients)
                    {
                        ingredient.Quantity *= factor;
                        ingredient.Calories *= factor;
                        counter++;
                    }
                }
                else if (count > ans)
                {
                    break;
                }

                count++;
            }

            ConsoleCustomization.SetColor("The recipe has been scaled successfully!", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Green, true, true);
            ConsoleCustomization.SetColor("Press any key to continue...", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        public static void ResetQuantities(List<Recipe> recipes)
        {
            if (recipes.Count <= 0)
            {
                ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", ConsoleCustomization.Colours.Black,ConsoleCustomization.Colours.Red, false, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();
                return;
            }

            /*ConsoleCustomization.SetColor("Select a recipe to reset its quantities", ConsoleCustomization.Colours.Cyan,
                ConsoleCustomization.Colours.White, true, true);*/
            int choice = 0;

            foreach (Recipe recipe in recipes)
            {
                ConsoleCustomization.SetColor(
                    $"\n{++choice}. Recipe Name: {recipe.GetName()} | (Calories: {HelperClass.CalculateTotalCalories(recipe)})",
                    ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
               /* Console.WriteLine("List of Ingredients: ");
                List<Ingredients> ingredients = recipe.GetIngredients();

                if (ingredients.Count <= 0)
                {
                    Console.WriteLine("There are no ingredients in the recipe.");
                }
                else
                {
                    foreach (Ingredients ingredient in ingredients)
                    {
                        ConsoleCustomization.SetColor(
                            $"\n- Name: {ingredient.Name}" +
                            $"\n- Quantity: {ingredient.Quantity}" +
                            $"\n- Measurement: {ingredient.Measurement}" +
                            $"\n- Calories: {ingredient.Calories}" +
                            $"\n- Food Group: {ingredient.FoodGroup}",
                            ConsoleCustomization.Colours.Black,
                            ConsoleCustomization.Colours.White,
                            true,
                            false
                        );
                    }
                }*/
            }

            ConsoleCustomization.SetColor("Enter your choice of recipe to reset: ", ConsoleCustomization.Colours.Black,
                ConsoleCustomization.Colours.White, false, true);
            string choiceAnswer = Console.ReadLine();

            if (choiceAnswer == null)
            {
                // Handle the case where the user didn't enter anything
                Console.WriteLine("You didn't enter a choice. Please try again.");
                choiceAnswer = Console.ReadLine();
            }

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

            if (answer == null)
            {
                // Handle the case where the user didn't enter anything
                Console.WriteLine("You didn't enter a choice. Please try again.");
                answer = Console.ReadLine();
            }
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
            if (recipes == null || recipes.Count == 0)
            {
                ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", Colours.Black, Colours.Red, false, true);
                Console.ReadKey();
                Console.Clear();
                Program.Menu();
                return;
            }
            Console.WriteLine("Are you sure you want to clear the data?\n1.Yes\n2.No");
            Console.Write("Enter your choice: ");
            string answer = Console.ReadLine();
            while (answer == null || !HelperClass.ValidInteger(answer))
            {
                Console.Write("Please enter a valid option: ");
                answer = Console.ReadLine();
            }

            int.TryParse(answer, out int validAnswer);

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