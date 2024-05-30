// Importing the necessary libraries
using System;
using System.Collections.Generic;

// Defining the namespace for our application
namespace Recipe_App
{
    // Defining the main class of our application
    public class Program
    {
        // Defining a list to hold our recipes
        public static List<Recipe> recipes = new List<Recipe>();

        // Defining a variable to hold the user's menu option
        public static int option = 0;

        // Defining the method that displays the menu and handles user input
        public static void Menu()
        {
            // Sorting the list of recipes by name
            recipes = recipes.OrderBy(recipe => recipe.GetName()).ToList();

            // Displaying the menu options to the user
            Console.WriteLine("1. Create a new recipe" +
                              "\n2. View all recipes" +
                              "\n3. Scale quantities" +
                              "\n4. Reset quantities" +
                              "\n5. Clear the recipe" +
                              "\n6. Exit");

            // Asking the user for their menu option
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            int choiceInt;

            // Checking that the user's input is a valid integer between 1 and 6
            while (!int.TryParse(choice, out choiceInt) || choiceInt < 1 || choiceInt > 6)
            {
                Console.Write("Please enter a valid option between 1 and 6: ");
                choice = Console.ReadLine();
            }

            // Switching on the user's menu option
            switch (choiceInt)
            {
                case 1:
                    // If the user chose to create a new recipe, we call the Ingredients method in the MainApp class
                    MainApp.Ingredients(recipes);
                    break;
                case 2:
                    // If the user chose to view all recipes, we call the PrintRecipe method in the HelperClass
                    HelperClass.PrintRecipe(recipes);
                    break;
                case 3:
                    // If the user chose to scale quantities, we call the ConvertUnits method in the EditQuantities class
                    EditQuantities.ConvertUnits(recipes);
                    break;
                case 4:
                    // If the user chose to reset quantities, we call the ResetQuantities method in the EditQuantities class
                    EditQuantities.ResetQuantities(recipes);
                    break;
                case 5:
                    // If the user chose to clear the recipe, we call the ClearData method in the EditQuantities class
                    EditQuantities.ClearData(recipes);
                    break;
                case 6:
                    // If the user chose to exit, we exit the application
                    Environment.Exit(0);
                    break;
            }
        }

        // Defining the main method of our application
        static void Main(string[] args)
        {
            // Looping until the user chooses to exit
            while (option != 6)
            {
                // Displaying the menu and handling the user's input
                Menu();
            }
        }
    }
}