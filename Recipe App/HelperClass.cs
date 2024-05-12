using System;
using System.Text.RegularExpressions;
using static Recipe_App.ConsoleCustomization;

namespace Recipe_App
{
    public class HelperClass
    {
        public static void PrintRecipe(List<Recipe> recipes)
        {
            try
            {
                if (recipes == null)
                {
                    throw new ArgumentNullException("Recipe list is null.");
                }

                if (recipes.Count == 0)
                {
                    ConsoleCustomization.SetColor("There are no recipes in the list.", Colours.Black, Colours.Red, true, true);
                    ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Red, true, true);
                    Program.Menu();
                    return;
                }

                int choice = 0;
                foreach (Recipe recipe in recipes)
                {
                    choice++;
                    var recipeName = recipe.GetName();
                    var totalCalories = HelperClass.CalculateTotalCalories(recipe);
                    ConsoleCustomization.SetColor($"\n{choice}. Recipe Name: {recipeName} | (Calories: {totalCalories})", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.White, true, true);

                    List<Ingredients> ingredients = recipe.GetIngredients();
                    if (ingredients.Count == 0)
                    {
                        ConsoleCustomization.SetColor("There are no ingredients in the recipe.", Colours.Black, Colours.Red, true, true);
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

                    var steps = recipe.GetSteps();
                    if (steps.Count == 0)
                    {
                        ConsoleCustomization.SetColor("There are no steps in the recipe.", Colours.Black, Colours.Red, true, true);
                        ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Cyan, true, true);
                        Program.Menu();
                        return;
                    }

                    ConsoleCustomization.SetColor("\nSteps: ", Colours.Black, Colours.White, true, false);
                    for (int i = 0; i < steps.Count; i++)
                    {
                        ConsoleCustomization.SetColor($"- Step #{i + 1}: {steps[i]}", Colours.Black, Colours.White, true, false);
                    }

                    ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Cyan, true, true);
                }
            }
            catch (ArgumentException ex)
            {
                ConsoleCustomization.SetColor("Error: " + ex.Message, Colours.Red, Colours.White, true, true);
            }
            catch (Exception ex)
            {
                ConsoleCustomization.SetColor("An unexpected error occurred: " + ex.Message, Colours.Red, Colours.White, true, true);
            }

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