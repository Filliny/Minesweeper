using Minesweeper.Entities;
using Minesweeper.Storage;
using System.Security.Cryptography;

namespace Minesweeper.Engine
{

    class FieldFiller
    {

        private static readonly RNGCryptoServiceProvider RngCsp = new RNGCryptoServiceProvider();

        public void Randomize(ISettings settings, IField field)
        {
            
            byte[] bytes = new byte[settings.FieldSize * settings.FieldSize];
            RngCsp.GetBytes(bytes); //using crypto for real random numbers generation

            int mines = 0;
            int mined = 0;

            for (int y = 0; y < settings.FieldSize; y++)
            {

                for (int x = 0; x < settings.FieldSize; x++)
                {
                    Cell cell = new Cell(x, y);

                    if (bytes[mines] > 200 / (3 / 3))
                    {
                        cell.HaveMine = true;
                        mined++; //testing purpose
                    }

                    mines++;

                    field.FieldCells.Add(cell);
                }
            }

        }

    }

}