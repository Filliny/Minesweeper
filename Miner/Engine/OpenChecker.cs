using Minesweeper.Entities;
using Minesweeper.Storage;
using System.Collections.Generic;

namespace Minesweeper.Engine
{

    class OpenChecker
    {

        public ISettings Settings { get; set; }

        public OpenChecker(ISettings settings)
        {
            Settings = settings;

        }

        public bool Check(IField field, ICell currentCell)

        {

            if (!currentCell.Opened && !currentCell.HaveMine)
            {
                currentCell.Opened = true;

                var surrounded = GetSurround(field, currentCell);

                //surrounded = surrounded.Where(m => m.HaveMine == false).ToList<Cell>();

                foreach (var cell in surrounded) //count mines
                {
                    if (cell.HaveMine)
                    {
                        currentCell.MinesBeside++;
                    }

                }

                foreach (var cell in surrounded) //open cells
                {
                    if (cell.HaveMine)
                    {
                        return false;
                    }

                    Check(field, cell);

                }

                //currentCell.MinesBeside = bombs;

            }
            else if (currentCell.HaveMine)
            {
                foreach (var cell in field.FieldCells)
                {
                    cell.Opened = true;
                }

                return true;
            }

            return false;

        }

        public List<ICell> GetSurround(IField field, ICell currentCell)
        {
            List<ICell> result = new List<ICell>(); //collecting surround

            int size = Settings.FieldSize - 1;

            //top cells
            //left
            if (currentCell.PositionX > 0)
            {
                result.Add(
                    field.FieldCells[currentCell.PositionY * Settings.FieldSize + currentCell.PositionX - 1]);
            }

            //right
            if (currentCell.PositionX < size)
            {
                result.Add(
                    field.FieldCells[currentCell.PositionY * Settings.FieldSize + currentCell.PositionX + 1]);
            }

            //bottom
            if (currentCell.PositionY < size)
            {
                result.Add(
                    field.FieldCells[(currentCell.PositionY + 1) * Settings.FieldSize + currentCell.PositionX]);
            }

            //top
            if (currentCell.PositionY > 0)
            {
                result.Add(
                    field.FieldCells[(currentCell.PositionY - 1) * Settings.FieldSize + currentCell.PositionX]);
            }

            //corner cells
            //left top
            if (currentCell.PositionX > 0 && currentCell.PositionY > 0)
            {
                result.Add(
                    field.FieldCells[(currentCell.PositionY - 1) * Settings.FieldSize + currentCell.PositionX - 1]);
            }

            //right bottom
            if (currentCell.PositionX < size && currentCell.PositionY < size)
            {
                result.Add(
                    field.FieldCells[(currentCell.PositionY + 1) * Settings.FieldSize + currentCell.PositionX + 1]);
            }

            //left bottom
            if (currentCell.PositionX > 0 && currentCell.PositionY < size)
            {
                result.Add(
                    field.FieldCells[(currentCell.PositionY + 1) * Settings.FieldSize + currentCell.PositionX - 1]);
            }

            //right top
            if (currentCell.PositionX < size && currentCell.PositionY > 0)
            {
                result.Add(
                    field.FieldCells[(currentCell.PositionY - 1) * Settings.FieldSize + currentCell.PositionX + 1]);
            }

            return result;
        }

    }

}