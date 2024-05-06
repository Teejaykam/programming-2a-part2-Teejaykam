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

    internal static class ConsoleCustomization
    {
        /// <summary>
        /// Sets the console color based on the provided parameters.
        /// </summary>
        /// <param name="text">The text to print.</param>
        /// <param name="bgColor">The background color.</param>
        /// <param name="fgColor">The foreground color.</param>
        /// <param name="newLine">Whether to print the text on a new line.</param>
        /// <param name="reset">Whether to reset the console color after printing.</param>
        public static void SetColor(string text, Colours bgColor, Colours fgColor, bool newLine, bool reset)
        {
            if (TryGetConsoleColor(bgColor, out ConsoleColor bgConsoleColor))
            {
                Console.BackgroundColor = bgConsoleColor;
            }
            else
            {
                Console.ResetColor();
            }

            if (TryGetConsoleColor(fgColor, out ConsoleColor fgConsoleColor))
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

        /// <summary>
        /// Tries to get the corresponding ConsoleColor for a specified Colours enum value.
        /// </summary>
        /// <param name="color">The Colours enum value for which to get the ConsoleColor.</param>
        /// <param name="consoleColor">The ConsoleColor corresponding to the Colours enum value, if found.</param>
        /// <returns>True if the ConsoleColor was successfully retrieved, false otherwise.</returns>
        private static bool TryGetConsoleColor(Colours color, out ConsoleColor consoleColor)
        {
            return ColorMap.TryGetValue(color, out consoleColor);
        }

        /// <summary>
        /// Mapping of custom Colours enum to ConsoleColor for console color setting.
        /// </summary>
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
    }
}