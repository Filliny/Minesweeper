using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Minesweeper.Storage;

namespace Minesweeper.Views
{
    class MessageView
    {

        public ISettings Settings { get; set; }

        public MessageView(ISettings settings)
        {
            Settings = settings;
        }

        public bool ShowMessage(string message, string question)
        {
            string answer;

            do
            {
                Console.SetCursorPosition(4,
                    Settings.FieldSize * 3 + 1);
                Console.Write(message);

                Console.SetCursorPosition(4,
                    (Settings.FieldSize * 3 ) + 2);
                Console.Write(question);

                answer = Console.ReadLine()?.ToUpper();

            } while (!answer.Equals("Y") && !answer.Equals("N"));

            if (answer.Equals("Y"))
            {
                return true;
            }

            return false;


        }
    }
}
