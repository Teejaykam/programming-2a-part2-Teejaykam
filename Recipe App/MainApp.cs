using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Recipe_App
{
    public class MainApp
    {
        public delegate string NotifyTotalCaloriesExceedLimit(Recipe ingredientName);
        public delegate void NotifyTotalCaloriesExceedLimitDelegate(int totalCalories);
        public static event NotifyTotalCaloriesExceedLimitDelegate NotifyTotalCaloriesExceedLimits;

        /// <summary>
        /// This method allows the user to create a new recipe and add it to the list of recipes.
        /// </summary>
        /// <param name="recipes">The list of existing recipes.</param>
        public static void Ingredients(List<Recipe> recipes)
        {
            // Flag to check if the entered name is valid.
            bool nameValid = false;
            // The name of the new recipe.
            string name = "";

            // Loop until a valid name is entered.
            while (!nameValid)
            {
                // Prompt the user to enter the name of the recipe.
                Console.Write("Enter the name of your recipe: ");
                // Read the name from the console.
                name = Console.ReadLine();

                // Check if the entered name is empty or contains invalid characters.
                if (string.IsNullOrWhiteSpace(name) || !HelperClass.ValidString(name))
                {
                    // If the name is invalid, notify the user.
                    Console.WriteLine("Name is invalid!");
                }
                else
                {
                    // Check if a recipe with the same name already exists.
                    bool exists = recipes.Any(recipe => recipe.GetName().ToLower() == name.ToLower());

                    if (exists)
                    {
                        // If a recipe with the same name already exists, notify the user.
                        Console.WriteLine($"Recipe {name} Already Exists");
                    }
                    else
                    {
                        // If the name is valid and no recipe with the same name exists, the loop is exited.
                        nameValid = true;
                    }
                }
            }

            // Create a new Recipe object with the entered name.
            Recipe newRecipe = new Recipe(name);

            // Prompt the user to enter the number of ingredients for the recipe.
            Console.Write("Enter the amount of ingredients: ");
            // Read the number of ingredients from the console.
            string input = Console.ReadLine();
            // The number of ingredients.
            int ingredientsAmount;

            // Loop until a valid number of ingredients is entered.
            while (input == null || !int.TryParse(input, out ingredientsAmount) || ingredientsAmount < 1)
            {
                // If the entered number is invalid, prompt the user to enter a valid number.
                Console.Write("Enter a valid amount of ingredients: ");
                // Read the number of ingredients from the console.
                input = Console.ReadLine();
            }

            // Add the new recipe to the list of recipes.
            recipes.Add(newRecipe);
            // Call the InputIngredientInfo method to get the information about the ingredients.
            InputIngredientInfo(ingredientsAmount, newRecipe, NotifyTotalCaloriesExceed);
        }


        // This method is used to notify the user if the total calories of a recipe exceeds 300.
        // It allows the user to adjust the calories of a specific ingredient if they choose to.
        // The method returns a string indicating whether the calories have been changed or not.
        private static String NotifyTotalCaloriesExceed(Recipe recipe)
        {
            // Initialize a string to keep track of whether the calories have been changed or not.
            string changed = "";

            // Prompt the user to confirm if they want to adjust the recipe.
            Console.Write("Calories have exceeded 300. Would you like to adjust the recipe?\n1. Yes\n2. No\nEnter your choice: ");
            string input = Console.ReadLine();

            // Validate the user's input.
            while (input == null || !HelperClass.ValidInteger(input) || int.Parse(input) > 2 || int.Parse(input) < 1)
            {
                Console.Write($"Please enter a valid option between 1 and 2: ");
                input = Console.ReadLine();
            }

            // Parse the user's input into an integer.
            int answer = int.Parse(input);

            // If the user chooses to adjust the recipe, proceed.
            if (answer == 1)
            {
                // Get the list of ingredients for the recipe.
                List<Ingredients> ingredients = recipe.GetIngredients();

                // Display the ingredients of the recipe.
                Console.WriteLine($"Listing the ingredients within {recipe.GetName()}:\n");
                Console.WriteLine($"================================ {recipe.GetName()} ================================");
                foreach (Ingredients ingredient in ingredients)
                {
                    // Display the name and calories of each ingredient.
                    Console.WriteLine($"{++counter}. Ingredient Name: {ingredient.Name} | Calories: {ingredient.Calories}");
                    Console.WriteLine($"Name: {ingredient.Name}" +
                                      $"\nQuantity: {ingredient.Quantity}" +
                                      $"\nMeasurement: {ingredient.Measurement}" +
                                      $"\nCalories: {ingredient.Calories}" +
                                      $"\nFood Group: {ingredient.FoodGroup}");
                }

                // Prompt the user to choose an ingredient to adjust.
                Console.WriteLine();
                Console.Write("Enter an option: ");
                string option = Console.ReadLine();

                // Validate the user's input.
                while (option == null || !HelperClass.ValidInteger(option) || int.Parse(option) > ingredients.Count ||
                       int.Parse(option) < 1)
                {
                    Console.Write($"Please enter a valid option between 1 and {ingredients.Count}: ");
                    option = Console.ReadLine();
                }

                // Parse the user's input into an integer.
                int optionTwo = int.Parse(option);
                int counterTwo = 0;

                // Iterate over the ingredients.
                foreach (Ingredients ingredient in ingredients)
                {
                    // If the current ingredient matches the chosen ingredient, prompt the user to enter a new calorie value.
                    if (counterTwo == optionTwo - 1)
                    {
                        Console.WriteLine();
                        Console.Write($"Enter the number of calories for {ingredient.Name}: ");
                        String caloriesStr = Console.ReadLine();

                        // Validate the user's input.
                        while (caloriesStr == null || !HelperClass.ValidFloat(caloriesStr) || float.Parse(caloriesStr) > 1000)
                        {
                            Console.Write($"Please enter a valid number of calories for {ingredient.Name}: ");
                            caloriesStr = Console.ReadLine();
                        }

                        // Parse the user's input into a float.
                        float calories = float.Parse(caloriesStr);

                        // Update the calories of the chosen ingredient.
                        ingredient.Calories = calories;

                        // Set the changed string to indicate that the calories have been changed.
                        changed = "changed";
                    }

                    // Increment the counter.
                    counterTwo++;
                }
            }
            // If the user chooses not to adjust the recipe, return "nochange".
            else if (answer == 2)
            {
                return "nochange";
            }

            // Return the changed string.
            return changed;
        }

        // This method is used to get the information about the ingredients.
        // It allows the user to adjust the calories of a specific ingredient if they choose to.
        // The method returns a string indicating whether the calories have been changed or not.

        private static void InputIngredientInfo(int ingredientsAmount, Recipe recipe,
            NotifyTotalCaloriesExceedLimit notify)
        {
            // Loop through the number of ingredients the user wants to input
            for (int i = 0; i < ingredientsAmount; i++)
            {
                // Prompt the user to enter the name of the ingredient
                Console.Write($"Enter the name of ingredient #{i + 1}: ");
                string ingredientName = Console.ReadLine();

                // Validate the user's input. Keep asking until a valid name is entered.
                while (ingredientName == null || !HelperClass.ValidString(ingredientName))
                {
                    Console.Write($"Enter a valid name for ingredient #{i + 1}: ");
                    ingredientName = Console.ReadLine();
                }

                // Prompt the user to enter the quantity of the ingredient
                Console.Write($"Enter the quantity of {ingredientName}: ");
                string inputQuantity = Console.ReadLine();

                // Validate the user's input. Keep asking until a valid quantity is entered.
                while (inputQuantity == null || !HelperClass.ValidFloat(inputQuantity))
                {
                    Console.Write($"Enter a valid quantity of '{ingredientName}': ");
                    inputQuantity = Console.ReadLine();
                }

                // Parse the user's input into a float
                float.TryParse(inputQuantity, out float quantityOfIngredient);
                float originalQuantity = quantityOfIngredient;

                // Prompt the user to enter the measurement unit of the ingredient
                string measurement = GetUnitOfMeasurement().ToString();

                // Prompt the user to enter the number of calories for the ingredient
                Console.Write($"Enter the number of calories for ingredient #{i + 1}: ");
                string inputCalories = Console.ReadLine();

                // Validate the user's input. Keep asking until a valid calorie count is entered.
                while (inputCalories == null || !HelperClass.ValidFloat(inputCalories) ||
                       float.Parse(inputCalories) > 1000)
                {
                    Console.Write(
                        $"Please enter a valid calorie count for ingredient {i + 1} that is between 1 and 2000: ");
                    inputCalories = Console.ReadLine();
                }

                // Parse the user's input into a float
                float calories = float.Parse(inputCalories);

                // Prompt the user to enter the food group for the ingredient
                // Commented out as it seems to be unused
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

                // Create a new Ingredients object with the user's input
                Ingredients ingredient = new Ingredients(ingredientName, quantityOfIngredient, originalQuantity,
                    calories, foodGroup, measurement);

                // Add the ingredient to the recipe
                recipe.AddIngredient(ingredient);
            }

            // Keep prompting the user to adjust the recipe's calories until they are within the limit
            while (HelperClass.CalculateTotalCalories(recipe) > 300)
            { // Notify the user that the total calories exceed the limit string result = notify(recipe);
              // If the user wants to change the recipe, continue the loop and prompt for more ingredients
                string result = notify(recipe);
                if (result == "change") continue;

                // If the user doesn't want to change the recipe, break out of the loop
                else if (result == "nochange") break;
            }

            // Prompt the user to enter the steps of the recipe
            InputSteps(recipe);
        }

        // This method is used to input the steps of the recipe
        // It allows the user to adjust the number of steps if they choose to
        // The method returns a string indicating whether the steps have been changed or not
        private static void InputSteps(Recipe recipe)
        {
            // Clear the console and prompt the user to enter the number of steps required
            Console.WriteLine();
            Console.Write("Please enter the number of steps required: ");
            string steps = Console.ReadLine();
            int stepsCount;

            // Validate the user's input. Keep asking until a valid number of steps is entered.
            while (!int.TryParse(steps, out stepsCount) || stepsCount < 1)
            {
                Console.Write($"Please enter a valid number of steps: ");
                steps = Console.ReadLine();
            }

            // Loop through the number of steps the user wants to input
            for (int i = 0; i < stepsCount; i++)
            {
                // Prompt the user to enter the description of the step
                Console.Write($"Enter the description for step #{i + 1}: ");
                string description = Console.ReadLine();

                // Validate the user's input. Keep asking until a valid description is entered.
                while (description == null || !HelperClass.ValidString(description))
                {
                    Console.Write($"Enter a valid description for step #{i + 1}: ");
                    description = Console.ReadLine();
                }

                // Add the step to the recipe
                recipe.AddStep(description);
            }

            // Clear the console, display a success message, and wait for the user to press a key before returning to the menu
            Console.WriteLine();
            ConsoleCustomization.SetColor("Recipe successfully created!\nPress any key to continue...",
                ConsoleCustomization.Colours.Black,
                ConsoleCustomization.Colours.Green, false, true);
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        // This method is used to get the unit of measurement from the user
        // It allows the user to adjust the unit of measurement if they choose to
        // The method returns the unit of measurement selected by the user
        // The method returns UnitOfMeasurement.None if the user doesn't want to change the unit

        // This method prompts the user to select a unit of measurement from a list of options.
        // It returns the selected unit of measurement as a UnitOfMeasurement enum value.
        private static UnitOfMeasurement GetUnitOfMeasurement()
        {
            // Initialize a boolean flag to track whether the user has entered a valid unit of measurement.
            bool validUoM = false;

            // Initialize a variable to store the selected unit of measurement.
            UnitOfMeasurement returns = UnitOfMeasurement.None;

            // Loop until the user enters a valid unit of measurement.
            do
            {
                // Display a message to the user asking them to select a unit of measurement.
                Console.WriteLine($"Select the unit of measurement");

                // Display a list of options for the user to choose from.
                Console.Write(
                    "(1) Tea spoons [Tsp]\n(2) Table spoons [Tbsp]\n(3) Cups [C]\n(4) Grams [G]\n(5) Kilograms [KG]\n(6) Millilitres [Ml]" +
                    "\n(7) Litres [L]\nEnter unit here: ");

                // Read the user's input from the console.
                String measurement = Console.ReadLine();

                // Try to convert the user's input to a byte value.
                byte UoM;
                try
                {
                    // If the conversion is successful, check if the value is within the valid range.
                    UoM = Convert.ToByte(measurement);
                    if (UoM <= 0 || UoM >= 7)
                    {
                        // If the value is outside the valid range, display an error message and continue the loop.
                        Console.Write("Invalid unit of measurement. Please enter a valid unit of measurement between 1 and 7: ");
                        validUoM = false;
                        continue;
                    }
                    else
                    {
                        // If the value is within the valid range, convert it to a UnitOfMeasurement enum value and set the flag to true.
                        returns = (UnitOfMeasurement)UoM;
                        validUoM = true;
                    }
                }
                catch (OverflowException)
                {
                    // If the conversion fails due to the value being too large, display an error message and continue the loop.
                    Console.Write("That number is too big! Please enter a valid unit of measurement between 1 and 7: ");
                }
                catch (FormatException)
                {
                    // If the conversion fails due to the input not being a valid number, display an error message and continue the loop.
                    Console.WriteLine("Enter a valid number! Please enter a valid unit of measurement between 1 and 7: ");
                }
            } while (!validUoM);

            // Return the selected unit of measurement.
            return returns;
        }


        // This method is used to get the food group for a given ingredient from user input.
        // It takes the name of the ingredient as a parameter and returns the corresponding food group.
        private static string GetIngredientFoodGroup(string ingredientName)
        {
            // Prompt the user to enter the food group for the given ingredient.
            Console.Write(
                $"Enter the food group for ingredient {ingredientName}:\n(1) Starch\n(2) Fruits and Vegetables\n(3) Dry beans, peas, lentils and soya\n(4) Chicken, fish, meat or egg\n(5) Milk or Dairy products\n(6) Fats or Oils\n(7) Water\nEnter your choice: ");

            // Define the available food groups.
            string[] groups = {"Starch", "Fruit or Vegetable", "Dry beans, peas, lentils and soya", "Chicken, fish, meat or egg",
                                "Milk or Dairy products", "Fats or Oils", "Water"};

            // Initialize the variable to store the selected food group.
            string foodGroupName = "";

            // Initialize the variable to store the user's selected group.
            int selectedGroup;

            // Loop until the user enters a valid food group.
            while (true)
            {
                // Read the user's input and parse it as an integer.
                if (!int.TryParse(Console.ReadLine(), out selectedGroup) || selectedGroup < 1 ||
                    selectedGroup > groups.Length)
                {
                    // If the input is not a valid integer or is out of range, prompt the user to enter a valid food group.
                    Console.Write("Please enter a valid food group: ");
                }
                else
                {
                    // If the input is a valid integer, assign the corresponding food group to the variable and break the loop.
                    foodGroupName = groups[selectedGroup - 1];
                    break;
                }
            }

            // Return the selected food group.
            return foodGroupName;
        }

        // This method is used to notify the user when the total calories exceed the limit.
        // It takes the total calories as a parameter and prints a message to the console.
        public static void NotifyTotalCaloriesExceedLimitHandler(int totalCalories)
        {
            ConsoleCustomization.SetColor($"Total calories exceed limit: {totalCalories}", ConsoleCustomization.Colours.Black, ConsoleCustomization.Colours.Red, true, true);
        }
    }
}