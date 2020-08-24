using Minesweeper.Engine;
using Minesweeper.Entities;
using Minesweeper.Storage;

namespace Minesweeper.KeyReader
{

    public enum Control
    {

        Open,
        Flag,
        Exit

    }

    class FieldNavigator
    {
        private ICell previousCell { get; set; }
        private ICell currentCell { get; set; }
        public ISettings Settings { get; set; }

        public FieldNavigator(ISettings settings)
        {
            Settings = settings;
        }

        public Control Navigate(IKeyReader reader, IField field, IFieldPrinter printer)
        {

            field.FieldCells[field.ActiveIndex].Active = true;
            int indexX = field.FieldCells[field.ActiveIndex].PositionX;
            int indexY = field.FieldCells[field.ActiveIndex].PositionY;
            printer.Print();

            while (true)
            {
                Destination destination = reader.GetDestination();

                if (destination == Destination.MoveDown)
                {
                    if (indexY < Settings.FieldSize - 1)
                    {
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = false;
                        previousCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                        indexY++;
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = true;
                        currentCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                    }
                }

                if (destination == Destination.MoveUp)
                {
                    if (indexY > 0)
                    {
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = false;
                        previousCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                        indexY--;
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = true;
                        currentCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                    }
                }

                if (destination == Destination.MoveRight)
                {
                    if (indexX < Settings.FieldSize - 1)
                    {
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = false;
                        previousCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                        indexX++;
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = true;
                        currentCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                    }
                }

                if (destination == Destination.MoveLeft)
                {
                    if (indexX > 0)
                    {
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = false;
                        previousCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                        indexX--;
                        field.FieldCells[indexY * Settings.FieldSize + indexX].Active = true;
                        currentCell = field.FieldCells[indexY * Settings.FieldSize + indexX];
                    }
                }

                if (destination == Destination.Esc)
                {
                    return Control.Exit;
                }

                if (destination == Destination.Select)
                {
                    field.ActiveIndex = indexY * Settings.FieldSize + indexX;

                    return Control.Open;
                }

                if (destination == Destination.Flag)
                {
                    field.ActiveIndex = indexY * Settings.FieldSize + indexX;

                    field.FieldCells[field.ActiveIndex].Flagged = field.FieldCells[field.ActiveIndex].Flagged == false;

                    return Control.Flag;
                }

                printer.Print(currentCell,previousCell);
            }

        }

    }

}