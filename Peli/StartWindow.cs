using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    internal class StartWindow
    {
        public StartWindow()
        {

        }

        public void Start()
        {
            string title = "Humans vs Skeletons";

            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);
        }
    }
}
