using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.KeyReader
{

    class WasdReader : IKeyReader
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
                    case ConsoleKey.W:
                        return Destination.MoveUp;
                    case ConsoleKey.S:
                        return Destination.MoveDown;
                    case ConsoleKey.A:
                        return Destination.MoveLeft;
                    case ConsoleKey.D:
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