using System;
using static Recipe_App.ConsoleCustomization;

namespace Recipe_App
{
    public class Recipe
    {
        private string name;
        private List<Ingredients> ingredientsList;
        private List<string> stepsList;

        public Recipe(string name)
        {
            this.name = name;
            this.ingredientsList = new List<Ingredients>();
            this.stepsList = new List<string>();
        }

        public string GetName()
        {
            return name;
        }

        public void AddIngredient(Ingredients ingredient)
        {
            ingredientsList.Add(ingredient);
        }

        public void AddStep(string step)
        {
            stepsList.Add(step);
        }

        public List<string> GetSteps()
        {
            return stepsList;   
        }

        public List<Ingredients> GetIngredients()
        {
            return ingredientsList;
        }
    }
}

