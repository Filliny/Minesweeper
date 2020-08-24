using Minesweeper.Entities;
using Minesweeper.Storage;

using System;

namespace Minesweeper.Engine
{

    internal interface IFieldPrinter
    {
        void Print();

        void Print(ICell currentCell, ICell previousCell);
    }

    class FieldPrinter : IFieldPrinter
    {

        public FieldPrinter()
        {
            
        }

        public ISettings Settings { get; set; }

        public IField FieldToPrint { get; set; }

        public FieldPrinter(ISettings settings, IField field)
        {
            Settings = settings;

            FieldToPrint = field;
        }

        public virtual void Print(ICell currentCell, ICell previousCell)
        {
            throw new NotImplementedException();
        }

        public virtual void Print()
        {

            Console.Clear();

            foreach (ICell cell in FieldToPrint.FieldCells)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (cell.Active)
                        {

                            if (x == 1 && y == 1)
                            {
                                PrintState(cell);
                            }
                            else
                            {
                                Console.BackgroundColor = Settings.SelectedColor;
                                Console.SetCursorPosition(cell.PositionX * 3 + x, cell.PositionY * 3 + y);
                                Console.Write(" ");
                            }

                        }
                        else if (!cell.Opened)
                        {
                            if (x == 1 && y == 1)
                            {
                                PrintState(cell); //show flag or bombs count
                            }
                            else
                            {
                                Console.BackgroundColor = Settings.CellColor;
                                int cellX = (cell.PositionX * 3) + x;
                                int cellY = ((cell.PositionY * 3) + y);
                                Console.SetCursorPosition(cellX, cellY);
                                Console.Write(" ");
                            }

                        }
                        else
                        {
                            if (x == 1 && y == 1)
                            {
                                PrintState(cell); //show flag or bombs count
                            }
                        }
                    }
                }
            }

            Console.ResetColor();


            if (FieldToPrint.ActiveIndex == 0 ) // hide message after first move
                PrintMessage();
        }

        protected void PrintState(ICell cell)
        {
            Console.ResetColor();
            Console.SetCursorPosition(cell.PositionX * 3 + 1, cell.PositionY * 3 + 1);

            if (cell.Opened && cell.MinesBeside != 0)
            {
                Console.ForegroundColor = (ConsoleColor) cell.MinesBeside + 7;
                Console.Write(cell.MinesBeside);

            }
            else if (cell.Opened && cell.HaveMine)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("M");
            }
            else if (cell.Flagged)
            {
                Console.ForegroundColor = Settings.FlagColor;
                Console.Write("P");
            }
            // else if(!cell.Opened && cell.MinesBeside != 0)   //Maybe not necessary
            //
            // {
            //     Console.Write(cell.MinesBeside);
            // }
            else
            {
                Console.BackgroundColor = Settings.CellColor;
                Console.Write(" ");
                
            }

            Console.ResetColor();

        }

        private void PrintMessage()
        {
            Console.SetCursorPosition(0,
                Settings.FieldSize * 3 + 1);
            Console.Write($"Use {Settings.ControlKeys} for navigation,\n " +
                          "Space for flag cell, Enter to open.");
        }

    }

}