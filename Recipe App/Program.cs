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
        public static int option = 0;
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            //bool clear = false;

            while(option == 0)
            {

                menu();
                if (option > 6 || option < 1)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    option = 0;
                }
                if (option == 6)
                {
                    break;
                }
                else
                {
                    switch (option)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("================================ New Recipe ================================");
                            Console.ResetColor();
                            Console.WriteLine("Enter the number of ingredients within your recipe: ");
                            int numIngredients = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < numIngredients; i++)
                            {
                                int count = i + 1;
                                recipe.addIngredient(count);
                            }
                            break;
                        case 2:
                            recipe.printRecipe();
                            break;
                        case 3:
                            recipe.convertUnits();
                            break;
                        case 4:
                            recipe.resetQuantities();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The recipe has been reset successfuly!" + Console.ResetColor + "\nIf you wish to create a new recipe, press 1. If you wish to exit, press 2.");

                            int choice = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("============================================================================");
                            Console.ResetColor();
                            if (choice == 2)
                            {
                                option = 6;
                            }
                            else
                            {
                                recipe.ClearData();
                                option = 0;
                            }
                            break;
                        default:
                            option = 0;
                            break;
                    }
                    option = 0; //Ensuring the while loop is repeated
                }






                option = 0;

                
            }
            static void menu()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to Teejay's Recipe App!", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                Console.WriteLine("Enter the number of the option you wish to select: ");
                Console.WriteLine("1. Add recipe information");
                Console.WriteLine("2. Print the recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset recipe quantities");
                Console.WriteLine("5. Clear the recipe");
                Console.WriteLine("6. Exit");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();

                option = Convert.ToInt32(Console.ReadLine());
            }
        }
        
    }

    /// Represents a recipe with ingredients and steps.

    public class Recipe
    {

        // ArrayLists for storing the recipe information.
        private ArrayList ingredientsName = new ArrayList();
        private ArrayList ingredientsAmount = new ArrayList();
        private ArrayList ingredientsUnit = new ArrayList();
        private ArrayList steps = new ArrayList();
        private ArrayList originalQuantities = new ArrayList();

        // Constructor that allows the user to add ingredients: name, quantity, and unit of measurement.
        public void addIngredient(int number)
        {

            // Prompt the user to enter the name of the ingredient
            Console.WriteLine("Enter the name of ingredient #" + number + ": ");
            ingredientsName.Add(Console.ReadLine());

            // Prompt the user to enter the quantity of the ingredient
            Console.WriteLine("Enter the quantity of ingredient #" + number + ": ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            if (quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number only.");
                quantity = Convert.ToDouble(Console.ReadLine()); 
            }
            ingredientsAmount.Add(quantity);
            originalQuantities.Add(quantity);

            // Prompt the user to enter the unit of measurement for the ingredient
            Console.WriteLine("Enter the unit of measurement for ingredient #" + number + ": ");
            ingredientsUnit.Add(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
            addStep();

        }


        // Constructor that allows the user to add steps.
        public void addStep()
        {
            Console.WriteLine("Enter the number of steps within your recipe: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": ");
                Console.WriteLine("Describe this step: ");
                steps.Add(Console.ReadLine());
            }
        }

        public void printRecipe()
        {
            if (ingredientsName.Count == 0)
            {
                Console.WriteLine("There are no ingredients in the recipe.");
                return;
            }
            else {
                // Print the ingredients
                Console.WriteLine("Ingredients: ");
                for (int i = 0; i < ingredientsName.Count; i++)
                {
                    Console.WriteLine("#" + ingredientsAmount[i] + " " + ingredientsUnit[i] + " " + ingredientsName[i]);
                }
            }

            // Print the steps
            Console.WriteLine("Steps: ");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + steps[i]);
            }
        }

        public void convertUnits()
        {
            double factor = 1;
            // Prompt the user to enter the unit of measurement they want to convert to
            Console.WriteLine("See the recipe at a different scale: ");
            Console.WriteLine("Enter the number corresponding with the scale value you require: \n" +
                "1: A factor of 0.5 (half)\n" +
                "2: A factor of 2 (double)\n" +
                "3: A factor of 3 (triple)\n" +
                "4: Return to the main menu");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    factor = 0.5;
                    break;
                case 2:
                    factor = 2;
                    break;
                case 3:
                    factor = 3;
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            // Convert the units
            if (ingredientsAmount.Count <= 0)
            {
                Console.WriteLine("There are no ingredients to scale.");
                return;
            } else {
                for (int i = 0; i < ingredientsAmount.Count; i++)
                {
                    double scaledQuantity = (double)ingredientsAmount[i] * factor;
                    ingredientsAmount[i] = scaledQuantity;

                }
            }

            Console.WriteLine("The recipe has been scaled: ");
            printRecipe();
            Console.WriteLine("Do you wish to reset the quantities to their original values? (y/n) ");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                resetQuantities();
            } 
        }

        public void resetQuantities()
        {
            Console.WriteLine("The recipe has been reset: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
            ingredientsAmount.Clear();
            ingredientsAmount.AddRange(originalQuantities);
            Console.WriteLine("The Original Recipe: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
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
