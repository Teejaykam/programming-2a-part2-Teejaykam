using System;

namespace Recipe_App
{
    public class Ingredients
    {
        public string Name { get; set; }
        public string Measurement { get; set; }
        public float Quantity { get; set; }
        public float Calories { get; set; }
        public string FoodGroup { get; set; }
        public float OriginalQuantity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredients"/> class.
        /// </summary>
        /// <param name="name">The name of the ingredient.</param>
        /// <param name="quantity">The quantity of the ingredient.</param>
        /// <param name="originalQuantity">The original quantity of the ingredient.</param>
        /// <param name="calories">The number of calories in the ingredient.</param>
        /// <param name="group">The food group of the ingredient.</param>
        /// <param name="measurement">The measurement of the ingredient.</param>
        public Ingredients(string name, float quantity, float originalQuantity, float calories, string group, string measurement)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = originalQuantity;
            Calories = calories;
            FoodGroup = group;
            Measurement = measurement;
        }
    }
}