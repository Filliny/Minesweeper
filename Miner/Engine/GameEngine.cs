using System;
using Minesweeper.Entities;
using Minesweeper.KeyReader;
using Minesweeper.Storage;
using Minesweeper.Views;

namespace Minesweeper.Engine
{

    class GameEngine
    {

        public void Run()
        {
            Settings settings = new Settings();

            FieldFiller filler = new FieldFiller();
            WinChecker winChecker = new WinChecker();
            SettingsView settingsView = new SettingsView();
            KeySwitcher switcher = new KeySwitcher();

            while (true)
            {
                settingsView.GetSettings(settings);

                IField field = new Field();

                Console.SetWindowSize(settings.FieldSize * 3, settings.FieldSize * 3 + 5);

                filler.Randomize(settings, field);

                FieldPrinter printer = new FieldPrinter(settings, field);
                CellPrinter cellPrinter = new CellPrinter(settings, field);
                OpenChecker checker = new OpenChecker(settings);
                MessageView message = new MessageView(settings);
                FieldNavigator navigator = new FieldNavigator(settings);
                IKeyReader keyReader = switcher.SwitchKeyboard(settings);

                bool gameRun = true;

                while (gameRun)
                {
                    //printer.Print();
                    Control action = navigator.Navigate(keyReader, field, cellPrinter);

                    if (action == Control.Exit)
                    {

                        if (message.ShowMessage(settings.ExitMsg, settings.YesNoMsg))
                        {
                            return;
                        }
                    }
                    else if (action == Control.Open)
                    {

                        bool result = checker.Check(field, field.FieldCells[field.ActiveIndex]);

                        if (result) //Boom!
                        {
                            printer.Print();

                            if (message.ShowMessage(settings.LooseMsg, settings.ExitNewMsg))
                            {

                                return;
                            }
                            else
                            {
                                gameRun = false;
                            }

                        }

                        if (winChecker.Check(field)) //Win!
                        {
                            printer.Print();

                            if (message.ShowMessage(settings.WinMsg, settings.ExitNewMsg))
                            {
                                return;
                            }
                            else
                            {
                                gameRun = false;
                            }
                        }
                    }
                    else if (action == Control.Flag)
                    {
                        if (winChecker.Check(field)) //Win!
                        {
                            printer.Print();

                            if (message.ShowMessage(settings.WinMsg, settings.ExitNewMsg))
                            {
                                return;
                            }
                            else
                            {
                                gameRun = false;
                            }
                        }
                    }

                }
            }

        }

    }

    //27 hrs

}