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

            var instance = new Battle();

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

            int number1 = 13;

            while (true)
            {
                int number = 1;

                if (CheckIfWon())
                {
                    break;
                }

                Console.SetCursorPosition(15, 0);
                Console.WriteLine("[------------ Status ------------]");

                foreach (Unit unit in player_army)
                {
                    Console.WriteLine(unit.id + "." + unit.name);
                }

                foreach (Unit unit in enemy_army)
                {
                    Console.SetCursorPosition(20, number);
                    Console.WriteLine(unit.id + "." + unit.name);
                    number++;
                }

                Console.ForegroundColor = ConsoleColor.White;
                int attacker = Convert.ToInt32(Console.ReadLine());

                Console.SetCursorPosition(15, 7);
                Console.WriteLine("[------------ Message ------------]");

                if (attacker > humanMage.id)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect id!");
                    attacker = Convert.ToInt32(Console.ReadLine());
                }

                ChooseWhoWillAttack(attacker);

                //////////////////////////////////////////////////////////

                // Valitaan vihollinen
                Console.WriteLine("Choose who to attack: ");

                int target = Convert.ToInt32(Console.ReadLine());


                if (target > skeletonMage.id)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect id!");
                    target = Convert.ToInt32(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.White;

                var attackerUnit = player_army[attacker - 1];

                if (target == skeletonWarrior.id)
                {
                    FightEnemy(attackerUnit, skeletonWarrior);
                }
                else if (target == skeletonArcher.id)
                {
                    FightEnemy(attackerUnit, skeletonArcher);
                }
                else if (target == skeletonMage.id)
                {
                    FightEnemy(attackerUnit, skeletonMage);
                }

                // Hyökätään pelaajaa
                FightPlayer();

            }

            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;

                Console.SetCursorPosition(15, 12);
                Console.WriteLine("------------ History ------------");

                Console.SetCursorPosition(1, number1);
                Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
                number1++;
            }

            void ChooseWhoWillAttack(int i)
            {
                if (i == humanWarrior.id)
                {
                    Console.Write("You chose: ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(humanWarrior.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == humanArcher.id)
                {
                    Console.WriteLine("You chose: ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(humanArcher.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == humanMage.id)
                {
                    Console.WriteLine("You chose: " );
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(humanMage.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            void FightPlayer()
            {
                int playerIndex = random.Next(player_army.Count);
                int enemyIndex = random.Next(enemy_army.Count);

                Unit enemy = enemy_army[enemyIndex];
                Unit player = player_army[playerIndex];

                player.hp -= enemy.hp;
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