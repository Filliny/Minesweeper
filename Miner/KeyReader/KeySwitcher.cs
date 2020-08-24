using Minesweeper.Storage;

namespace Minesweeper.KeyReader
{

    class KeySwitcher
    {

        public IKeyReader SwitchKeyboard(ISettings settings)
        {
            if (settings.ControlKeys == Controls.WASD)
                return new WasdReader();

            return new ArrowsReader();

        }

    }

}