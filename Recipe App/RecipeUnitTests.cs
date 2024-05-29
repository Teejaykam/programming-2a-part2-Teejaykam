using Recipe_App;
using NUnit.Framework;

[Test]
public void CalculateTotalCalories_ReturnsZero_WhenRecipeHasNoIngredients()
{
    Recipe recipe = new Recipe();
    Assert.AreEqual(0, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_ReturnsSumOfIngredientCalories_WhenRecipeHasIngredients()
{
    Recipe recipe = new Recipe();
    recipe.AddIngredient(new Ingredients { Calories = 10 });
    recipe.AddIngredient(new Ingredients { Calories = 20 });
    Assert.AreEqual(30, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_HandlesNullIngredients()
{
    Recipe recipe = new Recipe();
    recipe.AddIngredient(null);
    recipe.AddIngredient(new Ingredients { Calories = 10 });
    Assert.AreEqual(10, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_ReturnsZero_WhenRecipeHasNullIngredients()
{
    Recipe recipe = new Recipe();
    recipe.Ingredients = null;
    Assert.AreEqual(0, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_ReturnsZero_WhenRecipeHasEmptyIngredientsList()
{
    Recipe recipe = new Recipe();
    recipe.Ingredients = new List<Ingredients>();
    Assert.AreEqual(0, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_ReturnsSumOfIngredientCalories_WhenIngredientsHaveNegativeCalories()
{
    Recipe recipe = new Recipe();
    recipe.AddIngredient(new Ingredients { Calories = -10 });
    recipe.AddIngredient(new Ingredients { Calories = -20 });
    Assert.AreEqual(-30, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_ReturnsSumOfIngredientCalories_WhenIngredientsHaveMixedCalories()
{
    Recipe recipe = new Recipe();
    recipe.AddIngredient(new Ingredients { Calories = 10 });
    recipe.AddIngredient(new Ingredients { Calories = -20 });
    Assert.AreEqual(-10, RecipeCalculator.CalculateTotalCalories(recipe));
}

[Test]
public void CalculateTotalCalories_CallsDelegate_WhenTotalCaloriesExceeds300()
{
    Recipe recipe = new Recipe();
    recipe.AddIngredient(new Ingredients { Calories = 250 });
    recipe.AddIngredient(new Ingredients { Calories = 50 });
    bool delegateCalled = false;
    recipe.CaloriesExceeded += (totalCalories) => delegateCalled = true;
    RecipeCalculator.CalculateTotalCalories(recipe);
    Assert.IsTrue(delegateCalled);
}