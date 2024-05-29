using System;
using System.Security.Cryptography.X509Certificates;
using Console = System.Console;

namespace Recipe_App
{
    public class MainApp
    {
        //public delegate string NotifyTotalCaloriesExceedLimit(Recipe ingredientName);
        public delegate void NotifyTotalCaloriesExceedLimitDelegate(int totalCalories);
        public static event NotifyTotalCaloriesExceedLimitDelegate NotifyTotalCaloriesExceedLimit;

        public static void Ingredients(List<Recipe> recipes)
        {
            bool nameValid = false;
            string name = "";

            while (!nameValid)
            {
                Console.Write("Enter the name of your recipe: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name) || !HelperClass.ValidString(name))
                {
                    Console.WriteLine("Name is invalid!");
                }
                else
                {
                    bool exists = recipes.Any(recipe => recipe.GetName().ToLower() == name.ToLower());

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

            Recipe newRecipe = new Recipe(name);

            Console.Write("Enter the amount of ingredients: ");
            string input = Console.ReadLine();
            int ingredientsAmount;

            while (input == null || !int.TryParse(input, out ingredientsAmount) || ingredientsAmount < 1)
            {
                Console.Write("Enter a valid amount of ingredients: ");
                input = Console.ReadLine();
            }

            recipes.Add(newRecipe);
            InputIngredientInfo(ingredientsAmount, newRecipe, NotifyTotalCaloriesExceed);
        }


        private static String NotifyTotalCaloriesExceed(Recipe recipe)
        {
            string changed = "";

            Console.Write("Calories have exceeded 300. Would you like to adjust the recipe?\n1. Yes\n2. No\nEnter your choice: ");
            string input = Console.ReadLine();

            while (input == null || !HelperClass.ValidInteger(input) || int.Parse(input) > 2 || int.Parse(input) < 1)
            {
                Console.Write($"Please enter a valid option between 1 and 2: ");
                input = Console.ReadLine();
            }
            int answer = int.Parse(input);
            int counter = 0;
            Console.WriteLine();
            if (answer == 1)
            {
                List<Ingredients> ingredients = recipe.GetIngredients();
                Console.WriteLine($"Listing the ingredients within {recipe.GetName()}:\n");
                Console.WriteLine($"================================ {recipe.GetName()} ================================");
                foreach (Ingredients ingredient in ingredients)
                {
                    Console.WriteLine($"{++counter}. Ingredient Name: {ingredient.Name} | Calories: {ingredient.Calories}");

                    Console.WriteLine($"Name: {ingredient.Name}" +
                                      $"\nQuantity: {ingredient.Quantity}" +
                                      $"\nMeasurement: {ingredient.Measurement}" +
                                      $"\nCalories: {ingredient.Calories}" +
                                      $"\nFood Group: {ingredient.FoodGroup}");
                }

                Console.WriteLine();
                Console.Write("Enter an option: ");
                string option = Console.ReadLine();

                while (option == null || !HelperClass.ValidInteger(option) || int.Parse(option) > ingredients.Count ||
                       int.Parse(option) < 1)
                {
                    Console.Write($"Please enter a valid option between 1 and {ingredients.Count}: ");
                    option = Console.ReadLine();
                }

                int optionTwo = int.Parse(option);
                int counterTwo = 0;

                foreach (Ingredients ingredient in ingredients)
                {
                    if (counterTwo == optionTwo - 1)
                    {
                        Console.WriteLine();
                        Console.Write($"Enter the number of calories for {ingredient.Name}: ");
                        String caloriesStr = Console.ReadLine();

                        while (caloriesStr == null || !HelperClass.ValidFloat(caloriesStr) || float.Parse(caloriesStr) > 1000)
                        {
                            Console.Write($"Please enter a valid number of calories for {ingredient.Name}: ");
                            caloriesStr = Console.ReadLine();
                        }

                        float calories = float.Parse(caloriesStr);
                        ingredient.Calories = calories;

                        changed = "changed";
                    }

                    counterTwo++;
                }
            } else if (answer == 2)
            {
                return "nochange";
            }

            return changed;
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
                    Console.Write($"Enter a valid name for ingredient #{i + 1}: ");
                    ingredientName = Console.ReadLine();
                }

                Console.Write($"Enter the quantity of {ingredientName}: ");
                string inputQuantity = Console.ReadLine();

                while (inputQuantity == null || !HelperClass.ValidFloat(inputQuantity))
                {
                    Console.Write($"Enter a valid quantity of '{ingredientName}': ");
                    inputQuantity = Console.ReadLine();
                }

                float.TryParse(inputQuantity, out float quantityOfIngredient);
                float originalQuantity = quantityOfIngredient;

                string measurement = GetUnitOfMeasurement().ToString();

                Console.Write($"Enter the number of calories for ingredient #{i + 1}: ");
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
                    calories, foodGroup, measurement );

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
            Console.WriteLine();
            Console.Write("Please enter the number of steps required: ");
            string steps = Console.ReadLine();
            int stepsCount;

            while (!int.TryParse(steps, out stepsCount) || stepsCount < 1 )
            {
                Console.Write($"Please enter a valid number of steps: ");
                steps = Console.ReadLine();
            }

            for (int i = 0; i < stepsCount; i++)
            {
                Console.Write($"Enter the description for step #{i+1}: ");
                string description = Console.ReadLine();

                while (description == null || !HelperClass.ValidString(description))
                {
                    Console.Write($"Enter a valid description for step #{i + 1}: ");
                    description = Console.ReadLine();   
                }
                recipe.AddStep(description);
            }

            Console.WriteLine();
            ConsoleCustomization.SetColor("Recipe successfully created!\nPress any key to continue...",
                ConsoleCustomization.Colours.Black,
                ConsoleCustomization.Colours.Green, false, true);
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        private static UnitOfMeasurement GetUnitOfMeasurement()
        {
            bool validUoM = false;
            UnitOfMeasurement returns = UnitOfMeasurement.None;
            do
            {
                Console.WriteLine($"Select the unit of measurement");
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
                        Console.Write("Invalid unit of measurement. Please enter a valid unit of measurement between 1 and 7: ");
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
                    Console.Write("That number is too big! Please enter a valid unit of measurement between 1 and 7: ");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid number! Please enter a valid unit of measurement between 1 and 7: ");
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
            int selectedGroup;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out selectedGroup) || selectedGroup < 1 ||
                    selectedGroup > groups.Length)
                {
                    Console.Write("Please enter a valid food group: ");
                }
                else
                {
                    foodGroupName = groups[selectedGroup - 1];
                    break;
                }
            }
            Console.WriteLine();
            return foodGroupName;
        }

        public static void NotifyTotalCaloriesExceedLimitHandler(int totalCalories)
        {
            ConsoleCustomization.SetColor($"Total calories exceed limit: {totalCalories}", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, true, true);
        }
    }
}