using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Peli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Unit> player_army = new List<Unit>();
            List<Unit> enemy_army = new List<Unit>();

            Random random = new Random();

            Unit humanWarrior = new Unit("Human Warrior", random.Next(8, 15), 45, 1);
            Unit humanArcher = new Unit("Human Archer", random.Next(10, 20), 25, 2);
            Unit humanMage = new Unit("Human Mage", random.Next(5, 10), 24, 3);

            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(9, 15), 45, 4);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(10, 20), 25, 5);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(5, 10), 24, 6);

            player_army.Add(humanWarrior);
            player_army.Add(humanArcher);
            player_army.Add(humanMage);

            enemy_army.Add(skeletonWarrior);
            enemy_army.Add(skeletonArcher);
            enemy_army.Add(skeletonMage);


            while (true)
            {
                string chooseCharacter = "";
                string chooseEnemy = "";

                if (CheckIfWon() == true)
                {
                    break;
                }


                Console.SetCursorPosition(15, 0);
                Console.WriteLine("[---------- Status ----------]");

                foreach (Unit unit in player_army)
                {
                    chooseCharacter += unit.id + "." + unit.name + "\n";
                }

                foreach (Unit unit in enemy_army)
                {
                    chooseEnemy += unit.id + "." + unit.name + "\n";
                }
                Console.SetCursorPosition(0, 1);
                Console.Write(chooseCharacter);
                Console.Write(chooseEnemy);

                Console.ForegroundColor = ConsoleColor.White;
                int attacker = Convert.ToInt32(Console.ReadLine());

                if (attacker > humanMage.id)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect id!");

                    Console.WriteLine(chooseCharacter);
                    attacker = Convert.ToInt32(Console.ReadLine());
                }

                ChooseWhoWillAttack(attacker);

                //////////////////////////////////////////////////////////


                // Valitaan vihollinen
                Console.WriteLine("Choose which one to attack: ");

                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine(chooseEnemy);

                int target = Convert.ToInt32(Console.ReadLine());

                if (target > skeletonMage.id)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect id!");
                    Console.WriteLine(chooseEnemy);
                    target = Convert.ToInt32(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.White;

                var attackerUnit = player_army[attacker - 1];

                if (target == skeletonWarrior.id)
                {
                    Console.WriteLine("You chose: " + skeletonWarrior.name);

                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonWarrior);

                }
                else if (target == skeletonArcher.id)
                {
                    Console.WriteLine("You chose: " + skeletonArcher.name);

                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonArcher);
                }
                else if (target == skeletonMage.id)
                {
                    Console.WriteLine("You chose: " + skeletonMage.name);

                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonMage);
                }

                // Hyökätään pelaajaa
                FightPlayer();

                Console.WriteLine("Press a key to continue....");
                Console.ReadKey();
                Console.Clear();
            }




            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;

                Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
            }

            void ChooseWhoWillAttack(int i)
            {
                if (i == humanWarrior.id)
                {
                    Console.WriteLine("You chose: " + humanWarrior.name);
                }
                else if (i == humanArcher.id)
                {
                    Console.WriteLine("You chose: " + humanArcher.name);
                }
                else if (i == humanMage.id)
                {
                    Console.WriteLine("You chose: " + humanMage.name);
                }
            }

            void FightPlayer()
            {
                int playerIndex = random.Next(player_army.Count);
                int enemyIndex = random.Next(enemy_army.Count);

                Unit enemy = enemy_army[enemyIndex];
                Unit player = player_army[playerIndex];

                player.hp -= enemy.hp;

                Console.WriteLine(enemy.name + " attacked " + player.name + " and dealt " + enemy.dmg + " damage");
            }

            bool CheckIfAliveEnemy(Unit unit)
            {
                if (unit.hp <= 0)
                {
                    enemy_army.Remove(unit);
                    Console.WriteLine(unit.name + " died");
                    return true;
                }

                return false;
            }

            bool CheckIfWon()
            {
                if (player_army.Count == 0)
                {
                    Console.WriteLine("Enemy won!");
                    SoundPlayer my_wave_file = new SoundPlayer("Sounds/GameOver.wav");
                    my_wave_file.PlaySync();
                    return true;

                }
                else if (enemy_army.Count == 0)
                {
                    Console.WriteLine("Player won!");
                    return true;
                }

                return false;
            }
        }

        private static void PlaySound_GameOver()
        {
            SoundPlayer my_wave_file = new SoundPlayer("Sounds/GameOver.wav");
            my_wave_file.PlaySync();
        }
    }
}