using System;

namespace Recipe_App
{
    /// <summary>
    /// Represents the unit of measurement for ingredients.
    /// </summary>
    public enum UnitOfMeasurement : byte
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
    public static class UoMConversion
    {
        /// <summary>
        /// Converts the unit of measurement to its name.
        /// </summary>
        /// <param name="UoM">The unit of measurement.</param>
        /// <param name="pluralForm">Whether to use the plural form or not.</param>
        /// <returns>The name of the unit of measurement.</returns>
        public static string UnitsToName(UnitOfMeasurement UoM, bool pluralForm)
        {
            // Validate input enum value
            if (!Enum.IsDefined(typeof(UnitOfMeasurement), UoM) || UoM == UnitOfMeasurement.None)
            {
                throw new ArgumentException("Invalid unit of measurement.");
            }

            switch (UoM)
            {
                //ternary operator to return either the value for true or false
                case UnitOfMeasurement.Tsp:
                    return pluralForm ? "Tea spoons" : "Tea spoon";
                case UnitOfMeasurement.Tbsp:
                    return pluralForm ? "Table spoons" : "Table spoon";
                case UnitOfMeasurement.Cup:
                    return pluralForm ? "Cups" : "Cup";
                case UnitOfMeasurement.G:
                    return pluralForm ? "Grams" : "Gram";
                case UnitOfMeasurement.Kg:
                    return pluralForm ? "Kilograms" : "Kilogram";
                case UnitOfMeasurement.Ml:
                    return pluralForm ? "Millilitres" : "Millilitre";
                case UnitOfMeasurement.L:
                    return pluralForm ? "Litres" : "Litre";
                default:
                    throw new ArgumentException("Invalid unit of measurement.");
            }
        }
    }
}