// Import the Recipe_App namespace, which contains the classes we'll be using
using Recipe_App;
using System;

// Start of the Recipe_App namespace
namespace Recipe_App
{
    // CalorieCalculationTest class, used for testing the calorie calculation feature
    public class CalorieCalculationTest
    {
        // Method to run the test
        public static void RunTest()
        {
            // Create a new Recipe object with a name
            Recipe testRecipe = new Recipe("Test Recipe");

            // Add three Ingredients to the Recipe
            testRecipe.AddIngredient(new Ingredients("Ingredient 1", 100, 100, 75, "Starch", "Kilograms"));
            testRecipe.AddIngredient(new Ingredients("Ingredient 2", 200, 200, 90, "Vegetable or fruit", "Grams"));
            testRecipe.AddIngredient(new Ingredients("Ingredient 3", 150, 150, 115, "Protein", "grams"));

            // Calculate the expected total calories by summing the calories of the Ingredients
            float expectedTotalCalories = 75 + 90 + 115;

            // Calculate the actual total calories by calling the CalculateTotalCalories method of the HelperClass
            float actualTotalCalories = HelperClass.CalculateTotalCalories(testRecipe);

            // Check if the expected and actual total calories are equal
            // If they are, print a success message
            // If they aren't, print a failure message
            if (expectedTotalCalories == actualTotalCalories)
            {
                Console.WriteLine("Calorie calculation test 1 passed!");
            }
            else
            {
                Console.WriteLine("Calorie calculation test 1 failed!");
            }

            // Add another Ingredient to the Recipe
            testRecipe.AddIngredient(new Ingredients("Ingredient 4", 50, 30, 20, "Protein", "Grams"));

            // Update the expected total calories by adding the calories of the new Ingredient
            expectedTotalCalories += 20;

            // Recalculate the actual total calories
            actualTotalCalories = HelperClass.CalculateTotalCalories(testRecipe);

            // Check if the expected and actual total calories are equal
            // If they are, print a success message
            // If they aren't, print a failure message
            if (expectedTotalCalories == actualTotalCalories)
            {
                Console.WriteLine("Calorie calculation test 2 passed!");
            }
            else
            {
                Console.WriteLine("Calorie calculation test 2 failed!");
            }
        }
        // Main method, which runs the RunTest method
        /*static void Main(String[] args)
        {
            RunTest();
        } */
    }
}