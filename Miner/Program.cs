using Minesweeper.Engine;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
              //Use console raster fonts 16x12 for better UX )
              GameEngine engine = new GameEngine();
              engine.Run();
        }
    }
}
