using Minesweeper.Entities;
using Minesweeper.Storage;

using System;

namespace Minesweeper.Engine
{

    class CellPrinter : FieldPrinter
    {

        public CellPrinter(ISettings settings, IField field)
        {
            Settings = settings;

            FieldToPrint = field;
        }

        public override void Print(ICell currentCell, ICell previousCell)
        {

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (currentCell.Active)
                    {

                        if (x == 1 && y == 1)
                        {
                            PrintState(currentCell);
                        }
                        else
                        {
                            Console.BackgroundColor = Settings.SelectedColor;
                            Console.SetCursorPosition(currentCell.PositionX * 3 + x, currentCell.PositionY * 3 + y);
                            Console.Write(" ");
                        }

                    }
                    else if (!currentCell.Opened)
                    {
                        if (x == 1 && y == 1)
                        {
                            PrintState(currentCell); //show flag or bombs count
                        }
                        else
                        {
                            Console.BackgroundColor = Settings.CellColor;
                            int cellX = (currentCell.PositionX * 3) + x;
                            int cellY = ((currentCell.PositionY * 3) + y);
                            Console.SetCursorPosition(cellX, cellY);
                            Console.Write(" ");
                        }

                    }
                    else
                    {
                        if (x == 1 && y == 1)
                        {
                            PrintState(currentCell); //show flag or bombs count
                        }
                    }
                }
            }

            Console.ResetColor();

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (previousCell.Opened)
                    {

                        if (x == 1 && y == 1)
                        {
                            PrintState(previousCell);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(previousCell.PositionX * 3 + x, previousCell.PositionY * 3 + y);
                            Console.Write(" ");
                        }

                    }
                    else if (!previousCell.Opened)
                    {
                        if (x == 1 && y == 1)
                        {
                            PrintState(previousCell); //show flag or bombs count
                        }
                        else
                        {
                            Console.BackgroundColor = Settings.CellColor;
                            int cellX = (previousCell.PositionX * 3) + x;
                            int cellY = ((previousCell.PositionY * 3) + y);
                            Console.SetCursorPosition(cellX, cellY);
                            Console.Write(" ");
                        }

                    }
                    else
                    {
                        if (x == 1 && y == 1)
                        {
                            PrintState(previousCell); //show flag or bombs count
                        }
                    }
                }
            }

            Console.ResetColor();

        }

    }

}