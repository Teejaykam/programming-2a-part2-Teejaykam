using Recipe_App;

namespace Recipe_App
{
    public class CalorieCalculationTest
    {
        public static void RunTest()
        {
            Recipe testRecipe = new Recipe("Test Recipe");
            testRecipe.AddIngredient(new Ingredients("Test Ingredient 1", 100, 100, 50, "Grains","grams"));
            testRecipe.AddIngredient(new Ingredients("Test Ingredient 2", 200, 200, 100, "Protein","grams"));
            testRecipe.AddIngredient(new Ingredients("Test Ingredient 3", 300, 300, 120, "Vegetables","grams"));

            float expectedCalories = 270;
            float actualCalories = HelperClass.CalculateTotalCalories(testRecipe);

            if (expectedCalories == actualCalories)
            {
                ConsoleCustomization.SetColor("Test Passed: The total calories were calculated correctly.", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Green, true, true);
            }
            else
            {
                ConsoleCustomization.SetColor("Test Failed: The total calories were not calculated correctly.", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, true, true);
            }
        }
    }
}