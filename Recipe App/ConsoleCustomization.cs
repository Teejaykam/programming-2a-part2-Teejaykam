﻿using System;
using System.Collections.Generic;

namespace Recipe_App
{
    internal static class ConsoleCustomization
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
            if (ColorMap.TryGetValue(color, out consoleColor))
            {
                return true;
            }
            else
            {
                // Print a message indicating the invalid color, or handle it silently
                Console.WriteLine($"Invalid color: {color}. Defaulting to ConsoleColor.White.");
                consoleColor = ConsoleColor.White; // Set a default color, or any appropriate fallback
                return false;
            }
        }

        /// <summary>
        /// Mapping of custom Colours enum to ConsoleColor for console color setting.
        /// </summary>
        private static readonly Dictionary<Colours, ConsoleColor> ColorMap = new Dictionary<Colours, ConsoleColor>
        {
            { ConsoleCustomization.Colours.Red, ConsoleColor.Red },
            { ConsoleCustomization.Colours.Green, ConsoleColor.Green },
            { ConsoleCustomization.Colours.Blue, ConsoleColor.Blue },
            { ConsoleCustomization.Colours.Yellow, ConsoleColor.Yellow },
            { ConsoleCustomization.Colours.Cyan, ConsoleColor.Cyan },
            { ConsoleCustomization.Colours.White, ConsoleColor.White },
            { ConsoleCustomization.Colours.Black, ConsoleColor.Black }
        };
    }
}