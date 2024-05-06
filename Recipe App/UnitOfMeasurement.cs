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
        public static string UnitsToNameS(Units UoM)
        {
            switch(UoM)
            {
                case Units.None:
                    return null;  
                case Units.Tsp:
                    return "tea spoon";   
                case Units.Tbsp:
                    return "table spoon";  
                case Units.Cup:
                    return "cup";   
                case Units.G:
                    return "gram"; 
                case Units.Kg:
                    return "kilogram";
                case Units.Ml:
                    return "millilitre";    
                case Units.L:
                    return "litre";
            }
            return null;
        }

        public static string UnitsToNameM(Units UoM)
        {
            switch (UoM)
            {
                case Units.None:
                    return null;
                case Units.Tsp:
                    return "tea spoons";
                case Units.Tbsp:
                    return "table spoons";
                case Units.Cup:
                    return "cups";
                case Units.G:
                    return "grams";
                case Units.Kg:
                    return "kilograms";
                case Units.Ml:
                    return "millilitres";
                case Units.L:
                    return "litres";
            }
            return null;
        }
    }
}