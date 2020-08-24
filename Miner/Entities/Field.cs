using System.Collections.Generic;

namespace Minesweeper.Entities
{

    internal interface IField
    {

        int ActiveIndex { get; set; }
        List<ICell> FieldCells { get; set; }

    }

    class Field : IField
    {

        public int ActiveIndex { get; set; }
        public List<ICell> FieldCells { get; set; }

        public Field()
        {
            FieldCells = new List<ICell>();

        }

    }

}