using System;
using System.Text.RegularExpressions;
using static Recipe_App.ConsoleCustomization;
using static Recipe_App.MainApp;

namespace Recipe_App
{
    public class HelperClass
    {
        public static void PrintRecipe(List<Recipe> recipes)
        {
            try
            {
                if (recipes.Count == 0 || recipes == null)
                {
                    ConsoleCustomization.SetColor("There are no recipes. Press any key to continue...", Colours.Black, Colours.Red, false, true);
                    Console.ReadKey();
                    Console.Clear();
                    Program.Menu();
                    return;
                }

                int choice = 0;
                foreach (Recipe Recipe in recipes)
                {
                    choice++;
                    ConsoleCustomization.SetColor($"[{choice}]. Recipe Name: {Recipe.GetName()}\t| Calories: {HelperClass.CalculateTotalCalories(Recipe)}\t| Ingredients amount: {Recipe.GetIngredients().Count}\t| Steps amount: {Recipe.GetSteps().Count}", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);
                }

                // Ask the user which recipe number they would like to view
                ConsoleCustomization.SetColor("Enter the number of the recipe you would like to view: ", Colours.Black, Colours.White, false, true);
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

                Recipe recipe = recipes[index];
                var recipeName = recipe.GetName();
                var totalCalories = HelperClass.CalculateTotalCalories(recipe);

                List<Ingredients> ingredients = recipe.GetIngredients();

                ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Cyan, true, true);
                ConsoleCustomization.SetColor($"Recipe Name: {recipeName}", Colours.Black, Colours.White, true, true);

                int totalCalorie = 0;
                ConsoleCustomization.SetColor("\nList of Ingredients: ", Colours.Black, Colours.White, true, true);
                foreach (Ingredients ingredient in ingredients)
                {
                    string measurement = UoMConversion.UnitsToName((UnitOfMeasurement)Enum.Parse(typeof(UnitOfMeasurement), ingredient.Measurement), ingredient.Quantity > 1);
                    ConsoleCustomization.SetColor(
                        $"\n- Name: {ingredient.Name}" +
                        $"\n- Quantity and measurement: {ingredient.Quantity} {measurement}" +
                        $"\n- Calories: {ingredient.Calories}" +
                        $"\n- Food Group: {ingredient.FoodGroup}",
                        ConsoleCustomization.Colours.Black,
                        ConsoleCustomization.Colours.White,
                        true,
                        false
                    );

                    totalCalories += ingredient.Calories;

                    // Check if total calories exceeds the limit
                    if (totalCalories > 300)
                    {
                        // Notify the delegate if total calories exceeds the limit
                        NotifyTotalCaloriesExceedLimit += NotifyTotalCaloriesExceedLimitHandler;
                    } else
                    {
                        NotifyTotalCaloriesExceedLimit -= NotifyTotalCaloriesExceedLimitHandler;
                    }
                }
            
                var steps = recipe.GetSteps();
                if (steps.Count == 0)
                {
                    ConsoleCustomization.SetColor("There are no steps in the recipe. Press any key to continue...", Colours.Black, Colours.Red, true, true);
                    Console.ReadKey();
                    Console.Clear();
                    Program.Menu();
                    return;
                }

                ConsoleCustomization.SetColor("\nSteps: ", Colours.Black, Colours.White, true, true);
                for (int i = 0; i < steps.Count; i++)
                {
                    ConsoleCustomization.SetColor($"- Step #{i + 1}: {steps[i]}", Colours.Black, Colours.White, true, true);
                }

                
                ConsoleCustomization.SetColor("\nTotal calories: " + totalCalories, Colours.Black, Colours.White, true, true);
                ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Cyan, true, true);
            }
            catch (ArgumentException ex)
            {
                ConsoleCustomization.SetColor("Error: " + ex.Message, Colours.Red, Colours.White, true, true);
            }
            catch (Exception ex)
            {
                ConsoleCustomization.SetColor("An unexpected error occurred: " + ex.Message, Colours.Red, Colours.White, true, true);
            }
            ConsoleCustomization.SetColor("Press any key to bring up the menu of options...", Colours.Black, Colours.White, false, true);
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }


        public static float CalculateTotalCalories(Recipe recipe)
        {
            float total = 0;
            foreach (Ingredients ingredient in recipe.GetIngredients())
            {
                total += ingredient.Calories;
            }
            return total;
        }

        public static bool ValidString(string input)
        {
            if(string.IsNullOrEmpty(input)) return false;
            if(!Regex.IsMatch(input, @"^[a-zA-Z\s]+$")) return false;
            return true;
        }

        public static bool ValidInteger(string input)
        {
            if(!int.TryParse(input, out int num)) return false;
            if(num<1) return false;
            return true;
        }

        public static bool ValidFloat(string input)
        {
            if (!float.TryParse(input, out float num)) return false;
            if (num < 0) return false;
            return true;
        }

        public static bool ValidByte(byte input)
        {
            byte num;
            if(!byte.TryParse(input.ToString(), out num)) return false; 
            if(num<0) return false;
            return true;
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void SelectRecipe(List<Recipe> recipes)
        {
            foreach (Recipe recipe in recipes)
            {
                ConsoleCustomization.SetColor(recipe.GetName(), Colours.Black, Colours.White, true, true);
            }
        }
    }
}