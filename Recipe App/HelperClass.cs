using System;
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
                    Program.menu();
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
                        ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Red, true, true);
                        Program.menu();
                        return;
                    }

                    ConsoleCustomization.SetColor("\nSteps: ", Colours.Black, Colours.White, true, false);
                    for (int i = 0; i < steps.Count; i++)
                    {
                        ConsoleCustomization.SetColor($"- Step #{i + 1}: {steps[i]}", Colours.Black, Colours.White, true, false);
                    }

                    ConsoleCustomization.SetColor("============================================================================", Colours.Black, Colours.Red, true, true);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            Program.menu();
        }


    }
}