using System;
using System.Globalization;
using System.Security.Policy;

using Minesweeper.Storage;

namespace Minesweeper.Views
{

    class SettingsView
    {

        public void GetSettings(ISettings settings)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition((settings.FieldSize/2)*3 - 5,1);
            Console.WriteLine($"MINESWEEPER\n");
            Console.ResetColor();

            Console.WriteLine($"Game settings:\n");
            Console.WriteLine($"Current field size = {settings.FieldSize}\n");
            Console.WriteLine($"Current game difficulty = {settings.DifficultyLevel}\n");
            Console.WriteLine($"Current game controls = {settings.ControlKeys}\n");
            Console.WriteLine($"Press Enter to skip or Space to modify settings >\n");

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Spacebar)
                {
                    Console.Write($"Enter game field size (9 -20) : ");
                    int size;

                    do
                    {
                        int.TryParse(Console.ReadLine(), out size);
                        settings.FieldSize = size;

                    } while (settings.FieldSize != size);

                    Console.WriteLine("\n");
                    Console.Write($"Enter game difficulty (1 to 10) : ");
                    int diff;

                    do
                    {
                        int.TryParse(Console.ReadLine(), out diff);
                        settings.DifficultyLevel = diff;

                    } while (settings.DifficultyLevel != diff);

                    Console.WriteLine("\n");
                    Console.Write($"Choose game controls (1 to Arrows, 2 for WASD) :  ");

                    Controls result;

                    do
                    {
                        //result = Enum.TryParse<Controls>(Console.ReadLine(), out Controls keysResult);
                        Enum.TryParse(Console.ReadLine(), out result);

                    } while (!Enum.IsDefined(typeof(Controls), result));

                    settings.ControlKeys = result;

                    return;

                }
                else if (key == ConsoleKey.Enter)
                {
                    return;
                }
            }

        }

    }

}