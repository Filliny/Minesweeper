using System;

namespace Minesweeper.Storage
{

    public enum Controls
    {

        Arrows = 1,
        WASD

    }


    internal interface ISettings
    {
        Controls ControlKeys { get; set; }
        string ExitMsg { get; set; }
        string YesNoMsg { get; set; }
        string LooseMsg { get; set; }
        string ExitNewMsg { get; set; }
        string WinMsg { get; set; }
        int FieldSize { get; set; }
        int DifficultyLevel { get; set; }
        ConsoleColor CellColor { get; set; }
        ConsoleColor SelectedColor { get; set; }
        ConsoleColor FlagColor { get; set; }

    }

    class Settings : ISettings
    {
        //Hardcoded now - can be implemented json saving 
        private int _difficulty = 3;
        private int _fieldSize = 9;

        public Controls ControlKeys { get; set; } = Controls.Arrows;
        public string ExitMsg { get; set; } = "Do You Want Exit Game ?";
        public string YesNoMsg { get; set; } = "Y or N ?";
        public string LooseMsg { get; set; } = "BOOM! You loose!";
        public string ExitNewMsg { get; set; } = "Do u wanna exit? Y for exit - N for new game";
        public string WinMsg { get; set; } = "Woohoo!! You Win!!";
        public int FieldSize 
        {
            get => _fieldSize;
            set
            {
                if (value >= 9 && value <= 20)
                {
                    _fieldSize = value;
                }
            }
        } 
        public int DifficultyLevel {
            get => _difficulty;
            set
            {
                if (value > 0 && value <= 10)
                {
                    _difficulty = value;
                }
            }
        } 

        public ConsoleColor CellColor { get; set; } = ConsoleColor.DarkYellow;
        public ConsoleColor SelectedColor { get; set; } = ConsoleColor.Blue;
        public ConsoleColor FlagColor { get; set; } = ConsoleColor.Red;

        
    }
}
