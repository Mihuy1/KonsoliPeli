using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection.Emit;

namespace Peli
{
    public static class StartWindow
    {
        public static void Start()
        {
            string title = "Humans vs Skeletons";
            
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press any button to start game!");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
