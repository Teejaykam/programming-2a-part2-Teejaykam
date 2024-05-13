using System;

namespace Recipe_App
{
    /// <summary>
    /// Represents the unit of measurement for ingredients.
    /// </summary>
    public enum Units : byte
    {
        None = 0,
        Tsp = 1,
        Tbsp = 2,
        Cup = 3,
        G = 4,
        Kg = 5,
        Ml = 6,
        L = 7
    }

    /// <summary>
    /// Represents the unit of measurement conversion.
    /// </summary>
    public static class UnitOfMeasurement
    {
        /// <summary>
        /// Converts the unit of measurement to its name.
        /// </summary>
        /// <param name="UoM">The unit of measurement.</param>
        /// <param name="pluralForm">Whether to use the plural form or not.</param>
        /// <returns>The name of the unit of measurement.</returns>
        public static string UnitsToName(Units UoM, bool pluralForm)
        {
            // Validate input enum value
            if (!Enum.IsDefined(typeof(Units), UoM) || UoM == Units.None)
            {
                throw new ArgumentException("Invalid unit of measurement.");
            }

            switch (UoM)
            {
                //ternary operator to return either the value for true or false
                case Units.Tsp:
                    return pluralForm ? "tea spoons" : "tea spoon";
                case Units.Tbsp:
                    return pluralForm ? "table spoons" : "table spoon";
                case Units.Cup:
                    return pluralForm ? "cups" : "cup";
                case Units.G:
                    return pluralForm ? "grams" : "gram";
                case Units.Kg:
                    return pluralForm ? "kilograms" : "kilogram";
                case Units.Ml:
                    return pluralForm ? "millilitres" : "millilitre";
                case Units.L:
                    return pluralForm ? "litres" : "litre";
                default:
                    throw new ArgumentException("Invalid unit of measurement.");
            }
        }
    }
}