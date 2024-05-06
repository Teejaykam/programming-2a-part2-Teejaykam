using System;

namespace Recipe_App
{
    internal enum Units
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

    internal class UnitOfMeasurement
    {
        public static string UnitsToName(Units UoM, bool pluralForm)
        {
            switch (UoM)
            {
                case Units.None:
                    return null;
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
            }
            return null;
        }
    }
}