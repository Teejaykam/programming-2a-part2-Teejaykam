using System;
using static Recipe_App.ConsoleCustomization;

namespace Recipe_App
{
    // This is a class that represents a recipe. It has a name, a list of ingredients, and a list of steps.
    public class Recipe
    {
        // This is the name of the recipe.
        private string name;

        // This is a list of ingredients for the recipe.
        private List<Ingredients> ingredientsList;

        // This is a list of steps to make the recipe.
        private List<string> stepsList;

        // This is the constructor for the Recipe class. It takes a name as a parameter and initializes the instance variables.
        public Recipe(string name)
        {
            this.name = name;
            this.ingredientsList = new List<Ingredients>();
            this.stepsList = new List<string>();
        }

        // This method returns the name of the recipe.
        public string GetName()
        {
            return name;
        }

        // This method adds an ingredient to the list of ingredients for the recipe.
        public void AddIngredient(Ingredients ingredient)
        {
            ingredientsList.Add(ingredient);
        }

        // This method adds a step to the list of steps for the recipe.
        public void AddStep(string step)
        {
            stepsList.Add(step);
        }

        // This method returns the list of steps for the recipe.
        public List<string> GetSteps()
        {
            return stepsList;
        }

        // This method returns the list of ingredients for the recipe.
        public List<Ingredients> GetIngredients()
        {
            return ingredientsList;
        }
    }
}

