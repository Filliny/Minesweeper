using Minesweeper.Entities;

namespace Minesweeper.Engine
{

    class WinChecker
    {

        public bool Check(IField field)
        {
            int opened = 0;
            int free = 0;
            int flagged = 0;
            int bombs = 0;

            foreach (var cell in field.FieldCells)
            {
                if (cell.Opened)
                    opened++;

                if (!cell.HaveMine)
                    free++;

                if (cell.Flagged)
                    flagged++;

                if (cell.HaveMine)
                    bombs++;
            }

            if (opened == free && flagged == bombs)
            {
                foreach (var cell in field.FieldCells)
                {
                    cell.Opened = true;
                }

                return true;
            }

            return false;
        }

    }

}