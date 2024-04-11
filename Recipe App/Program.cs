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
    }
}
