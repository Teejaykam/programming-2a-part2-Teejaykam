using System;
using System.Collections.Generic;

namespace Recipe_App
{
    public class Program
    {
        public static List<Recipe> recipes = new List<Recipe>();
        public static int option = 0;

        public static void Menu()
        {
            recipes = recipes.OrderBy(recipe => recipe.GetName()).ToList();

            Console.WriteLine("1. Create a new recipe" +
                              "\n2. View all recipes" +
                              "\n3. Scale quantities" +
                              "\n4. Reset quantities" +
                              "\n5. Clear the recipe" +
                              "\n6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            int choiceInt;

            while (!int.TryParse(choice, out choiceInt) || choiceInt < 1 || choiceInt > 6)
            {
                Console.Write("Please enter a valid option between 1 and 6: ");
                choice = Console.ReadLine();
            }

            switch (choiceInt)
            {
                case 1:
                    MainApp.Ingredients(recipes);
                    break;
                case 2:
                    HelperClass.PrintRecipe(recipes);
                    break;
                case 3:
                    EditQuantities.ConvertUnits(recipes);    
                    break;
                case 4:
                    EditQuantities.ResetQuantities(recipes);    
                    break;
                case 5: 
                    EditQuantities.ClearData(recipes);  
                    break;
                case 6:
                    Environment.Exit(0);    
                    break;  
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}