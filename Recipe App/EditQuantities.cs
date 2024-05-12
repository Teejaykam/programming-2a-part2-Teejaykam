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
                ConsoleCustomization.SetColor("There are no recipes.", ConsoleCustomization.Colours.Red,
                    ConsoleCustomization.Colours.White, true, false);
                ;
                Program.Menu();
                return;
            }

            Console.WriteLine("Select a recipe to scale its quantities: ");
            int choice = 0;

            foreach (Recipe recipe in recipes)
            {
                ConsoleCustomization.SetColor(
                    $"\n{++choice}. Recipe Name: {recipe.GetName()} | (Calories: {HelperClass.CalculateTotalCalories(recipe)})",
                    ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                Console.WriteLine("List of Ingredients: ");
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
                }
            }
            Console.Write("Enter your choice: ");
            string? decision = Console.ReadLine();

            while (decision == null || !HelperClass.ValidInteger(decision) || int.Parse(decision) > recipes.Count ||
                   int.Parse(decision) < 1)
            {
                Console.Write($"Enter a valid recipe number between 1 and {recipes.Count}: ");
                decision = Console.ReadLine();
            }

            int ans = int.Parse(decision);
            int count = 0;

            foreach (Recipe recipe in recipes)
            {
                if (count == ans - 1)
                {
                    List<Ingredients> ingredients = recipe.GetIngredients();

                    Console.Write("Enter a valid scaling factor: ");
                    string factorStr = Console.ReadLine();

                    while(factorStr == null || !HelperClass.ValidFloat((factorStr)) || float.Parse(factorStr) > 50.00)
                    {
                        Console.Write("Enter a valid scaling factor between 0 and 50: ");
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
                } else if (count > ans)
                {
                    break;
                }

                count++;
            }
            Console.WriteLine("The recipe has been scaled: ");
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

            ConsoleCustomization.SetColor("Select a recipe to reset its quantity", ConsoleCustomization.Colours.Cyan,
                ConsoleCustomization.Colours.White, true, false);
            int choice = 0;

            foreach (Recipe recipe in recipes)
            {
                ConsoleCustomization.SetColor(
                    $"\n{++choice}. Recipe Name: {recipe.GetName()} | (Calories: {HelperClass.CalculateTotalCalories(recipe)})",
                    ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                Console.WriteLine("List of Ingredients: ");
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
                }
            }

            ConsoleCustomization.SetColor("Enter your choice: ", ConsoleCustomization.Colours.Yellow,
                ConsoleCustomization.Colours.White, false, false);
            string choiceAnswer = Console.ReadLine();

            while (!HelperClass.ValidInteger(choiceAnswer) || int.Parse(choiceAnswer) > recipes.Count ||
                   int.Parse(choiceStr) < 1)
            {
                Console.WriteLine($"Enter a valid number between 1 and {recipes.Count}: ");
                choiceAnswer = Console.ReadLine();
            }

            int option = int.Parse(choiceAnswer);

            ConsoleCustomization.SetColor("Are you sure you want to reset the quantities? (y/n) ",
                ConsoleCustomization.Colours.Yellow, ConsoleCustomization.Colours.White, false, false);
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                ConsoleCustomization.SetColor("The recipe has been reset: ", ConsoleCustomization.Colours.Red,
                    ConsoleCustomization.Colours.White, true, false);
                ingredientsAmount.Clear();
                ingredientsAmount.AddRange(originalQuantities);
                ConsoleCustomization.SetColor("The Original Recipe: ", ConsoleCustomization.Colours.Red,
                    ConsoleCustomization.Colours.White, true, false);
                PrintRecipe(recipe);
            }
        }


        // Clear the data
        public static void ClearData(List<Recipe> recipes)
        {
            Console.WriteLine("Are you sure you want to clear the data?\n1.Yes\n2.No");
            Console.Write("Enter your choice: ");
            string answer = Console.ReadLine();
            while (!HelperClass.ValidInteger(answer))
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
                Console.WriteLine("The data has been cleared.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(
                    "============================================================================\nPress any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Program.Menu();
            }
        }
    }
}