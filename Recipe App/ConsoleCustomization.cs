using System;
using System.Collections.Generic;

namespace Recipe_App
{
    public enum Colours
    {
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        White,
        Black
    }

    internal class ConsoleCustomization
    {
        private static readonly Dictionary<Colours, ConsoleColor> ColorMap = new Dictionary<Colours, ConsoleColor>
        {
            { Colours.Red, ConsoleColor.Red },
            { Colours.Green, ConsoleColor.Green },
            { Colours.Blue, ConsoleColor.Blue },
            { Colours.Yellow, ConsoleColor.Yellow },
            { Colours.Cyan, ConsoleColor.Cyan },
            { Colours.White, ConsoleColor.White },
            { Colours.Black, ConsoleColor.Black }
        };

        public static void SetColor(string text, Colours bgColor, Colours fgColor, bool newLine, bool reset)
        {
            ConsoleColor bgConsoleColor;
            if (ColorMap.TryGetValue(bgColor, out bgConsoleColor))
            {
                Console.BackgroundColor = bgConsoleColor;
            }
            else
            {
                Console.ResetColor();
            }

            ConsoleColor fgConsoleColor;
            if (ColorMap.TryGetValue(fgColor, out fgConsoleColor))
            {
                Console.ForegroundColor = fgConsoleColor;
            }
            else
            {
                Console.ResetColor();
            }

            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }

            if (reset)
            {
                Console.ResetColor();
            }
        }
    }
} 