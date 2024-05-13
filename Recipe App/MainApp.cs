using System;
using System.Security.Cryptography.X509Certificates;
using Console = System.Console;

namespace Recipe_App
{
    public class MainApp
    {
        public delegate string NotifyTotalCaloriesExceedLimit(Recipe ingredientName);

        public static void Ingredients(List<Recipe> recipes)
        {
            bool nameValid = false;
            string name;

            if (!nameValid)
            {
                Console.Write("Enter the name of your recipe: ");
                name = Console.ReadLine() ?? "none";
                while (!nameValid)
                {
                    if (name == "none")
                    {
                        Console.WriteLine("Name is invalid!");
                    }
                    else
                    {
                        bool exists = false;
                        if (recipes.Count != 0)
                        {
                            foreach (Recipe recipe in recipes)
                            {
                                if (recipe.GetName().ToLower() == name.ToLower())
                                {
                                    exists = true;
                                }
                            }
                        }

                        if (exists)
                        {
                            Console.WriteLine($"Recipe {name} Already Exists");
                        }
                        else
                        {
                            nameValid = true;
                        }
                    }
                }
                /*while (name == null || !HelperClass.ValidString(name) || name == "none")
                {
                    Console.Write($"Enter a valid name for the recipe: ");
                    name = Console.ReadLine();
                }

                if (recipes.Count != 0)
                {
                    foreach (Recipe recipe in recipes)
                        if (recipe.GetName().ToLower() == name.ToLower())
                        {
                            exists = true;
                        }
                }*/

                Recipe newRecipe = new Recipe(name);

                Console.Write("Enter the amount of ingredients: ");
                string input = Console.ReadLine();
                int ingredientsAmount;

                while (input == null || !int.TryParse(input, out ingredientsAmount) || ingredientsAmount < 1)
                {
                    Console.Write($"Enter a valid amount of ingredients between 1 and e: ");
                    input = Console.ReadLine();
                }

                recipes.Add(newRecipe);
                ;
                InputIngredientInfo(ingredientsAmount, newRecipe, NotifyTotalCaloriesExceed);
            }
        }

        private static string NotifyTotalCaloriesExceed(Recipe ingredientname)
        {
            throw new NotImplementedException();
        }

        private static void InputIngredientInfo(int ingredientsAmount, Recipe recipe,
            NotifyTotalCaloriesExceedLimit notify)
        {
            for (int i = 0; i < ingredientsAmount; i++)
            {
                Console.Write($"Enter the name of ingredient #{i + 1}: ");
                string ingredientName = Console.ReadLine();

                while (ingredientName == null || !HelperClass.ValidString(ingredientName))
                {
                    Console.Write($"Enter a valid name for the ingredient #{i + 1}: ");
                    ingredientName = Console.ReadLine();
                }

                Console.Write($"Enter the quantity of {ingredientName}: ");
                string inputQuantity = Console.ReadLine();

                while (inputQuantity == null || !HelperClass.ValidFloat(inputQuantity))
                {
                    Console.Write($"Enter a valid quantity for the ingredient '{ingredientName}': ");
                    inputQuantity = Console.ReadLine();
                }

                float.TryParse(inputQuantity, out float quantityOfIngredient);
                float originalQuantity = quantityOfIngredient;

                GetUnitOfMeasurement();

                Console.Write($"Eneter the number of calories for ingredient #{i + 1}: ");
                string inputCalories = Console.ReadLine();

                while (inputCalories == null || !HelperClass.ValidFloat(inputCalories) ||
                       float.Parse(inputCalories) > 1000)
                {
                    Console.Write(
                        $"Please enter a valid calorie count for ingredient {i + 1} that is between 1 and 2000: ");
                    inputCalories = Console.ReadLine();
                }

                float calories = float.Parse(inputCalories);

                /*Console.WriteLine();
                Console.WriteLine($"Enter the food group for ingredient {ingredientName}: ");
                Console.WriteLine(
                    "1. Starch" +
                    "\n2. Vegetables and fruits" +
                    "\n3. Dry beans, peas, lentils or soya" +
                    "\n4. Chicken, fish, meat or egg" +
                    "\n5. Milk or dairy products" +
                    "\n6. Fats or oil" +
                    "\n7. Water");
                Console.Write("Enter a choice: ");*/
                String foodGroup = GetIngredientFoodGroup(ingredientName);

                Ingredients ingredient = new Ingredients(ingredientName, quantityOfIngredient,originalQuantity,
                    calories, foodGroup, GetUnitOfMeasurement().ToString());

                recipe.AddIngredient(ingredient);
            }

            while (HelperClass.CalculateTotalCalories(recipe) > 300)
            {
                string result = notify(recipe);
                if (result == "change") continue;
                else if (result == "nochange") break;
            }

            InputSteps(recipe);
        }

        private static void InputSteps(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        private static UnitOfMeasurement GetUnitOfMeasurement()
        {
            bool validUoM = false;
            UnitOfMeasurement returns = UnitOfMeasurement.None;
            do
            {
                Console.WriteLine($"Select the unit of measurement for {i + 1}");
                Console.Write(
                    "(1) Tea spoons [Tsp]\n(2) Table spoons [Tbsp]\n(3) Cups [C]\n(4) Grams [G]\n(5) Kilograms [KG]\n(6) Millilitres [Ml]" +
                    "\n(7) Litres [L]\nEnter unit here: ");
                String measurement = Console.ReadLine();
                byte UoM;

                try
                {
                    UoM = Convert.ToByte(measurement);
                    if (UoM <= 0 || UoM >= 7)
                    {
                        Console.WriteLine("Invalid unit of measurement. Please try again.");
                        validUoM = false;
                        continue;
                    }
                    else
                    {
                        returns = (UnitOfMeasurement)UoM;
                        validUoM = true;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That number is too big!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid number!");
                }
            } while (!validUoM);

            return returns;
        }

        private static string GetIngredientFoodGroup(string ingredientName)
        {
            Console.Write(
                $"Enter the food group for ingredient {ingredientName}:\n(1) Starch\n(2) Fruits and Vegetables\n(3) Dry beans, peas, lentils and soya\n(4) Chicken, fish, meat or egg\n(5) Milk or Dairy products\n(6) Fats or Oils\n(7) Water\nEnter your choice: ");
            string[] groups =
            {
                "Starch", "Fruit or Vegetable", "Dry beans, peas, lentils and soya", "Chicken, fish, meat or egg",
                "Milk or Dairy products", "Fats or Oils", "Water"
            };
            string foodGroupName = "";

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int selectedGroup) || selectedGroup < 1 ||
                    selectedGroup > groups.Length)
                {
                    Console.WriteLine("Invalid Option selected!");
                    continue;
                }

                foodGroupName = groups[selectedGroup - 1];
                break;
            }

            return foodGroupName;
        }
    }
}