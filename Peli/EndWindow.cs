﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    public static class EndWindow
    {
        public static void PlayerWon()
        {
            string playerWon = "Player Won!";

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - playerWon.Length) / 2, Console.CursorTop);
            Console.WriteLine(playerWon);
        }

        public static void EnemyWon()
        {
            string enemyWon = "Player Lost!";

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - enemyWon.Length) / 2, Console.CursorTop);
            Console.WriteLine(enemyWon);
        }
    }
}
