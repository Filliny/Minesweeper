using System;

namespace Minesweeper.KeyReader
{

    enum Destination
    {

        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        Select,
        Flag,
        Esc

    }

    internal interface IKeyReader
    {

        Destination GetDestination();

    }

    class ArrowsReader : IKeyReader
    {

        public Destination GetDestination()
        {

            while (true)
            {
                Console.SetCursorPosition(0, 4);
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Write(" ");

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        return Destination.MoveUp;
                    case ConsoleKey.DownArrow:
                        return Destination.MoveDown;
                    case ConsoleKey.LeftArrow:
                        return Destination.MoveLeft;
                    case ConsoleKey.RightArrow:
                        return Destination.MoveRight;
                    case ConsoleKey.Enter:
                        return Destination.Select;
                    case ConsoleKey.Escape:
                        return Destination.Esc;
                    case ConsoleKey.Spacebar:
                        return Destination.Flag;
                }
            }
        }

    }

}