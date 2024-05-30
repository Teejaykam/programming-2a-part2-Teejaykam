using Recipe_App;
using System;

namespace Recipe_App
{
    public class CalorieCalculationTest
    {
        public static void RunTest()
        {
            // Create a recipe with 3 ingredients
            Recipe testRecipe = new Recipe("Test Recipe");
            testRecipe.AddIngredient(new Ingredients("Ingredient 1", 100, 100, 75, "Starch", "Kilograms"));
            testRecipe.AddIngredient(new Ingredients("Ingredient 2", 200, 200, 90, "Vegetable or fruit", "Grams"));
            testRecipe.AddIngredient(new Ingredients("Ingredient 3", 150, 150, 115, "Protein", "grams"));

            // Calculate the expected total calories
            float expectedTotalCalories = 75 + 90 + 115;

            // Calculate the total calories using the helper method
            float actualTotalCalories = HelperClass.CalculateTotalCalories(testRecipe);

            // Compare the expected and actual total calories
            if (expectedTotalCalories == actualTotalCalories)
            {
                Console.WriteLine("Calorie calculation test 1 passed!");
            }
            else
            {
                Console.WriteLine("Calorie calculation test 1 failed!");
            }

            // Test case 2: Add another ingredient with different values
            testRecipe.AddIngredient(new Ingredients("Ingredient 4", 50, 30, 20, "Protein", "Grams"));
            expectedTotalCalories += 20;
            actualTotalCalories = HelperClass.CalculateTotalCalories(testRecipe);
            if (expectedTotalCalories == actualTotalCalories)
            {
                Console.WriteLine("Calorie calculation test 2 passed!");
            }
            else
            {
                Console.WriteLine("Calorie calculation test 2 failed!");
            }


        }


        static void Main(String[] args)
        {
            RunTest();
        }
    }
}