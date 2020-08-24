using System.ComponentModel.Design;

namespace Minesweeper.Entities
{

    internal interface ICell
    {

        int PositionX { get; set; }
        int PositionY { get; set; }
        bool HaveMine { get; set; }
        int MinesBeside { get; set; }
        bool Active { get; set; }
        bool Flagged { get; set; }
        bool Opened { get; set; }

    }

    class Cell : ICell
    {

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool HaveMine { get; set; }
        public int MinesBeside { get; set; }
        public bool Active { get; set; }
        public bool Flagged { get; set; }
        public bool Opened { get; set; }

        public Cell(int x, int y, bool haveMine = false)
        {
            PositionX = x;
            PositionY = y;
            HaveMine  = haveMine;

        }

    }

}