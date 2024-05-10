using System;
using System.Collections.Generic;

namespace Recipe_App
{
    internal class Program
    {
        // Creating a public static variable to store the user's option.
        public static int option = 0;
        // Lists for storing the recipe information.
        public static List<string> ingredientsName { get; private set; } = new List<string>();
        public static List<double> ingredientsAmount { get; private set; } = new List<double>();
        public static List<string> ingredientsUnit { get; private set; } = new List<string>();
        public static List<string> steps { get; private set; } = new List<string>();
        public static List<double> originalQuantities { get; private set; } = new List<double>();

        static void Main(string[] args)
        {
            // Creating an instance of the Recipe class.
            Recipe recipe = new Recipe();

            // Displaying the menu options to the user.
            while (option == 0)
            {
                // Calling the menu method.
                menu();
                // Check if the user's option is valid.
                if (option > 6 || option < 1)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    option = 0;
                }
                // If the user chooses to exit the program.
                if (option == 6)
                {
                    break;
                }
                else
                {
                    // Switch statement to handle the user's choice.
                    switch (option)
                    {
                        case 1:
                            // Calling the addIngredient method of the Recipe class.
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("================================ New Recipe ================================");
                            Console.ResetColor();
                            Console.WriteLine("Enter the number of ingredients within your recipe: ");
                            int numIngredients = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < numIngredients; i++)
                            {
                                int count = i + 1;
                                recipe.AddIngredient(count);
                            }
                            recipe.AddStep();
                            break;
                        case 2:
                            // Calling the PrintRecipe method of the Recipe class.
                            recipe.PrintRecipe();
                            break;
                        case 3:
                            // Calling the ConvertUnits method of the Recipe class.
                            recipe.ConvertUnits();
                            break;
                        case 4:
                            // Calling the ResetQuantities method of the Recipe class.
                            recipe.ResetQuantities();
                            break;
                        case 5:
                            // Calling the ClearData method of the Recipe class.
                            EditQuantities.ClearData(ingredientsName, ingredientsAmount, ingredientsUnit, steps, originalQuantities);
                            break;
                        default:
                            option = 0;
                            break;
                    }
                }
                // Ensuring the while loop is repeated
                option = 0;
            }
        }

        // Method to display the menu options to the user.
        static void menu()
        {
            // Changing the text color
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
            // Prompt the user to enter the number of the option they wish to select.
            option = Convert.ToInt32(Console.ReadLine());
        }
    }

    /* Represents a recipe with ingredients and steps.
     This class will contain methods for adding ingredients, steps, and printing the recipe.
     It will also contain a method for scaling the recipe.
     It will also contain a method for resetting the quantities.
     It will also contain a method for clearing the recipe. */
    public class Recipe
    {

        

        // Constructor that allows the user to add ingredients: name, quantity, and unit of measurement.
        public void AddIngredient(int number)
        {

            // Prompt the user to enter the name of the ingredient
            Console.WriteLine("Enter the name of ingredient #" + number + ": ");
            ingredientsName.Add(Console.ReadLine());

            // Prompt the user to enter the quantity of the ingredient
            Console.WriteLine("Enter the quantity of ingredient #" + number + ": ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            // Check if the quantity is valid
            if (quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number only.");
                quantity = Convert.ToDouble(Console.ReadLine());
            }
            // Add the quantity to the List
            ingredientsAmount.Add(quantity);
            originalQuantities.Add(quantity);

            // Prompt the user to enter the unit of measurement for the ingredient e.g. tsp, tbsp, cup, etc.
            Console.WriteLine("Enter the unit of measurement for ingredient #" + number + ": ");
            ingredientsUnit.Add(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
        }

        // Adds steps to the recipe.
        public void AddStep()
        {
            Console.WriteLine("Enter the number of steps within your recipe: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());
            // Check if the number of steps is valid
            if (numSteps <= 0)
            {
                Console.WriteLine("Invalid number of steps. Please enter a positive number only.");
            }
            // Prompt the user to enter the steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": ");
                Console.WriteLine("Describe this step: ");
                steps.Add(Console.ReadLine());
            }

            // Print the recipe
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
            PrintRecipe();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
        }

        

        // Method for scaling
        public void ConvertUnits()
        {
            // Check if there are any ingredients in the recipe
            if (ingredientsAmount.Count <= 0)
            {
                Console.WriteLine("There are no ingredients in the recipe.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                return;
            }
            else
            {
                double factor = 1;
                // Prompt the user to enter the unit of measurement they want to convert to
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("See the recipe at a different scale: ");
                Console.ResetColor();
                Console.WriteLine("Enter the number corresponding with the scale value you require: \n" +
                                    "1: A factor of 0.5 (half)\n" +
                                    "2: A factor of 2 (double)\n" +
                                    "3: A factor of 3 (triple)\n" +
                                    "4: Return to the main menu");
                int option = Convert.ToInt32(Console.ReadLine());
                // Set the factor based on the user's choice
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
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                // Convert the units
                if (ingredientsAmount.Count <= 0)
                {
                    Console.WriteLine("There are no ingredients to scale.");
                    return;
                }
                else
                {
                    // Loop through the List and scale the quantities
                    for (int i = 0; i < ingredientsAmount.Count; i++)
                    {
                        // Scale the quantities
                        double scaledQuantity = ingredientsAmount[i] * factor;
                        ingredientsAmount[i] = scaledQuantity;
                    }
                }

                Console.WriteLine("The recipe has been scaled: ");
                PrintRecipe();
                Console.WriteLine("Do you wish to reset the quantities to their original values? (y/n) ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    EditQuantities.ResetQuantities();
                }
            }
        }

    }
}
