using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{


     public class Battle
    {
        List<Unit> player_army = new List<Unit>();
        List<Unit> enemy_army = new List<Unit>();

        int number1;

        public void FightEnemy(Unit attacker, Unit target)
        {
            target.hp -= attacker.dmg;

            Console.SetCursorPosition(15, 12);
            Console.WriteLine("------------ History ------------");

            Console.SetCursorPosition(1, number1);
            Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
            number1++;
        }

    }
}
