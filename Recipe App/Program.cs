﻿// Importing the necessary libraries.
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
        // Creating a public static variable to store the user's option.
        public static int option = 0;
        static void Main(string[] args)
        {
            // Creating an instance of the Recipe class.
            Recipe recipe = new Recipe();

            // Displaying the menu options to the user.
            while(option == 0)
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
                                recipe.addIngredient(count);
                            }
                            recipe.addStep();
                            break;
                        case 2:
                            // Calling the printRecipe method of the Recipe class.
                            recipe.printRecipe();
                            break;
                        case 3:
                            // Calling the convertUnits method of the Recipe class.
                            recipe.convertUnits();
                            break;
                        case 4:
                            // Calling the resetQuantities method of the Recipe class.
                            recipe.resetQuantities();
                            break;
                        case 5:
                            // Calling the resetQuantities method of the Recipe class.
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The recipe has been reset successfully!");
                            Console.ResetColor();
                            Console.WriteLine("\nIf you wish to create a new recipe, press 1. If you wish to exit, press 2.");

                            // Prompt the user to enter the number of the option they wish to select.
                            int choice = Convert.ToInt32(Console.ReadLine());
                            // Changing the text color
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("============================================================================");
                            Console.ResetColor();
                            if (choice == 2)
                            {
                                // Exiting the program.
                                option = 6;
                            }
                            else
                            {
                                // Clearing the recipe data.
                                recipe.ClearData();
                                Console.Clear();
                                option = 0;
                            }
                            break;
                        default:
                            option = 0;
                            break;
                    }
                }
                // Ensuring the while loop is repeated
                option = 0;
                
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
        
    }

    /* Represents a recipe with ingredients and steps.
     This class will contain methods for adding ingredients, steps, and printing the recipe.
     It will also contain a method for scaling the recipe.
     It will also contain a method for resetting the quantities.
     It will also contain a method for clearing the recipe. */
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
            // Check if the quantity is valid
            if (quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number only.");
                quantity = Convert.ToDouble(Console.ReadLine()); 
            }
            // Add the quantity to the ArrayList
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
        public void addStep()
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
            printRecipe();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
        }
        // Prints the recipe.
        public void printRecipe()
        {
            // Check if there are any ingredients in the recipe
            if (ingredientsName.Count == 0)
            {
                Console.WriteLine("There are no ingredients in the recipe.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                return;
            }
            else {
                // Print the ingredients
                Console.WriteLine("Ingredients: ");
                // Loop through the ArrayList and print the ingredients
                for (int i = 0; i < ingredientsName.Count; i++)
                {
                    // Print the ingredients
                    Console.WriteLine(ingredientsAmount[i] + "" + ingredientsUnit[i] + " of " + ingredientsName[i]);
                }
            }
            // Check if there are any steps in the recipe
            if (steps.Count <= 0)
            {
                Console.WriteLine("There are no steps in the recipe.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                return;
            }
            else
            {
                // Print the steps
                Console.WriteLine("\nSteps: ");
                // Loop through the ArrayList and print the steps
                for (int i = 0; i < steps.Count; i++)
                {
                    // Print the steps
                    Console.WriteLine((i + 1) + ". " + steps[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("============================================================================");
            Console.ResetColor();
        }
        // Method for scaling
        public void convertUnits()
        {
            // Check if there are any ingredients in the recipe
            if (ingredientsAmount.Count <= 0) { 
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
                } else {
                    // Loop through the ArrayList and scale the quantities
                    for (int i = 0; i < ingredientsAmount.Count; i++)
                    {
                        // Scale the quantities
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
        }
        // Reset the quantities
        public void resetQuantities()
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
                Console.WriteLine("Are you sure you want to reset the quantities? (y/n) ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    // Reset the quantities
                    Console.WriteLine("The recipe has been reset: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("============================================================================");
                    Console.ResetColor();
                    // Resetting the values in the ArrayList
                    ingredientsAmount.Clear();
                    // Add the original quantities back to the ArrayList
                    ingredientsAmount.AddRange(originalQuantities);
                    Console.WriteLine("The Original Recipe: ");
                    // Print the original recipe
                    printRecipe();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("============================================================================");
                    Console.ResetColor();
                }
                else
                {
                    return;
                }
            }
        }
        // Clear the data
        public void ClearData()
        {
            Console.WriteLine("Are you sure you want to clear the data? (y/n) ");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                // Clear the data
                Console.WriteLine("The data has been cleared.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================================================");
                Console.ResetColor();
                // Clearing the data in the ArrayLists
                ingredientsName.Clear();
                ingredientsAmount.Clear();
                ingredientsUnit.Clear();
                steps.Clear();
                originalQuantities.Clear();
            }
            else
            {
                return;
            }
        }
    }
}
