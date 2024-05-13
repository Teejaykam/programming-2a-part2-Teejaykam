using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;


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
                ConsoleCustomization.SetColor("There are no recipes.", ConsoleCustomization.Colours.Red, ConsoleCustomization.Colours.White, true, false);
                Program.Menu();
                return;
            }

            ConsoleCustomization.SetColor("Select a recipe to scale its quantities: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);

            int choice = 0;

            foreach (Recipe recipe in recipes)
            {
                ConsoleCustomization.SetColor(
                    $"\n{++choice}. Recipe Name: {recipe.GetName()} | (Calories: {HelperClass.CalculateTotalCalories(recipe)})",
                    ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                ConsoleCustomization.SetColor("List of Ingredients: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);

                List<Ingredients> ingredients = recipe.GetIngredients();

                if (ingredients.Count <= 0)
                {
                    ConsoleCustomization.SetColor("There are no ingredients in the recipe.", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);
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
                }
            }

            ConsoleCustomization.SetColor("Enter your choice: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);
            string? decision = Console.ReadLine();

            while (decision == null || !HelperClass.ValidInteger(decision) || int.Parse(decision) > recipes.Count || int.Parse(decision) < 1)
            {
                ConsoleCustomization.SetColor($"Enter a valid recipe number between 1 and {recipes.Count}: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);
                decision = Console.ReadLine();
            }

            int ans = int.Parse(decision);
            int count = 0;

            foreach (Recipe recipe in recipes)
            {
                if (count == ans - 1)
                {
                    List<Ingredients> ingredients = recipe.GetIngredients();

                    ConsoleCustomization.SetColor("Enter a valid scaling factor: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);
                    string factorStr = Console.ReadLine();

                    while (factorStr == null || !HelperClass.ValidFloat((factorStr)) || float.Parse(factorStr) > 50.00)
                    {
                        ConsoleCustomization.SetColor("Enter a valid scaling factor between 0 and 50: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);
                        factorStr = Console.ReadLine();
                    }

                    float factor = float.Parse(factorStr);

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

            ConsoleCustomization.SetColor("The recipe has been scaled: ", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, false);
            Program.Menu();
        }

        public static void ResetQuantities(List<Recipe> recipes)
        {
            if (recipes.Count <= 0)
            {
                ConsoleCustomization.SetColor("There are no recipes.", ConsoleCustomization.Colours.Red,
                    ConsoleCustomization.Colours.White, true, false);
                ;
            }

            /*ConsoleCustomization.SetColor("Select a recipe to reset its quantities", ConsoleCustomization.Colours.Cyan,
                ConsoleCustomization.Colours.White, true, false);*/
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

            ConsoleCustomization.SetColor("Enter your choice of recipe to reset: ", ConsoleCustomization.Colours.Yellow,
                ConsoleCustomization.Colours.White, false, false);
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
                ConsoleCustomization.Colours.Yellow, ConsoleCustomization.Colours.White, false, false);
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
                Program.menu(0);
            }
        }


        // Clear the data
        public static void ClearData(List<Recipe> recipes)
        {
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
                Program.Menu();
            }
            else
            {
                Program.Menu();
            }
        }
    }
}