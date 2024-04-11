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
            Recipe recipe = new Recipe();
            bool clear = false;

            while(clear == false)
            {
                Console.WriteLine("Welcome to Teejay's Recipe App!");
                Console.WriteLine("================================ New Recipe ================================");

                Console.WriteLine("Enter the number of ingredients within your recipe: ");
                int numIngredients = Convert.ToInt32(Console.ReadLine());
            }
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


        // Constructor that allows the user to add steps.
        public void addStep()
        {
            // Prompt the user to describe the step
            Console.WriteLine("Describe this step: ");
            steps.Add(Console.ReadLine());
        }

        public void printRecipe()
        {
            // Print the ingredients
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < ingredientsName.Count; i++)
            {
                Console.WriteLine("#" +ingredientsAmount[i] + " " + ingredientsUnit[i] + " " + ingredientsName[i]);
            }

            // Print the steps
            Console.WriteLine("Steps: ");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + steps[i]);
            }
        }

        public void convertUnits(double scaleFactor)
        {
            // Prompt the user to enter the unit of measurement they want to convert to
            Console.WriteLine("Enter the unit of measurement you want to scale  to: ");

            // Convert the units
            for (int i = 0; i < ingredientsAmount.Count; i++)
            {
                if (ingredientsAmount[i] != null)
                {
                    double? ingredientValue = ingredientsAmount[i] as double?;
                    if (ingredientValue != null)
                    {
                        double scaledQuantity = ingredientValue.Value * scaleFactor;
                    }
                    else
                    {
                        // Handle the case where ingredientsAmount[i] is not a valid double value
                        Console.WriteLine("Error: ingredientsAmount[i] is not a valid double value");
                        break;
                    }
                }
                else
                {
                    // Handle the case where ingredientsAmount[i] is null
                    Console.WriteLine("Error: You don't have any ingredients");
                    break;
                }
            }

            Console.WriteLine("The recipe has been scaled: ");
            printRecipe();
            Console.WriteLine("Do you wish to reset the quantities to their original values? (y/n)");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                resetQuantities();
            }
        }

        private void resetQuantities()
        {
            Console.WriteLine("The recipe has been reset: ");
            ingredientsAmount.Clear();
            ingredientsAmount.AddRange(originalQuantities);
            Console.WriteLine("The Original Recipe: ");
            printRecipe();
        }

        public void ClearData()
        {
            ingredientsName.Clear();
            ingredientsAmount.Clear();
            ingredientsUnit.Clear();
            steps.Clear();
            originalQuantities.Clear();
        }
    }
}
