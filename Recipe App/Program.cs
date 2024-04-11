// Importing the necessary libraries.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Recipe_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    /// Represents a recipe with ingredients and steps.

    public class Recipe
    {

        // ArrayLists for storing the recipe information.
        public ArrayList ingredientsName = new ArrayList();
        public ArrayList ingredientsAmount = new ArrayList();
        public ArrayList ingredientsUnit = new ArrayList();
        public ArrayList steps = new ArrayList();
        public ArrayList originalQuantities = new ArrayList();

        // Constructor that allows the user to add ingredients: name, quantity, and unit of measurement.
        public void addIngredient()
        {
            // Prompt the user to enter the name of the ingredient
            Console.WriteLine("Enter the name of the ingredient: ");
            ingredientsName.Add(Console.ReadLine());

            // Prompt the user to enter the quantity of the ingredient
            Console.WriteLine("Enter the quantity of the ingredient: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            ingredientsAmount.Add(quantity);
            originalQuantities.Add(quantity);

            // Prompt the user to enter the unit of measurement for the ingredient
            Console.WriteLine("Enter the unit of measurement: ");
            ingredientsUnit.Add(Console.ReadLine());
        }

    }
}
