﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Security;
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

            Unit humanWarrior = new Unit("Human Warrior", random.Next(8, 15), 80, 80, 1);
            Unit humanArcher = new Unit("Human Archer", random.Next(10, 20), 50, 50, 2);
            Unit humanMage = new Unit("Human Mage", random.Next(5, 10), 30, 30, 3);

            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(9, 15), 80, 80, 4);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(10, 20), 50, 50, 5);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(5, 10), 30, 20, 6);

            player_army.Add(humanWarrior);
            player_army.Add(humanArcher);
            player_army.Add(humanMage);

            enemy_army.Add(skeletonWarrior);
            enemy_army.Add(skeletonArcher);
            enemy_army.Add(skeletonMage);

            int number1 = 13;
            int number2 = 8;
            int numberEnemy = 1;

            string enemyHealth = "";

            while (true)
            {
                numberEnemy = 1;
                int numberPlayer = 1;

                Console.SetCursorPosition(15, 0);
                Console.WriteLine("[------------ Status ------------]");

                Console.SetCursorPosition(15, 7);
                Console.WriteLine("[------------ Message ------------]");

                Console.SetCursorPosition(15, 12);
                Console.WriteLine("------------ History ------------");

                if (CheckIfWon())
                {
                    break;
                }

                CheckIfAlive();

                foreach (Unit unit in player_army)
                {
                    Console.SetCursorPosition(1, numberPlayer);
                    Console.WriteLine(unit.id + "." + unit.name + "(" + unit.hp + "/" + unit.maxHealth + ")");
                    numberPlayer++;
                }

                foreach (Unit unit in enemy_army)
                {
                    Console.SetCursorPosition(23, numberEnemy);
                    Console.WriteLine(unit.id + "." + unit.name);
                    CheckHealthEnemy(unit);
                    numberEnemy++;
                }

                Console.ForegroundColor = ConsoleColor.White;
                int attacker = Convert.ToInt32(Console.ReadLine());

                if (attacker > humanMage.id)
                {
                    Console.WriteLine("Incorrect id!");
                    attacker = Convert.ToInt32(Console.ReadLine());
                }

                ChooseWhoWillAttack(attacker);

                //////////////////////////////////////////////////////////

                // Valitaan vihollinen
                Console.SetCursorPosition(1, 8);
                Console.Write("Who to attack: ");

                int target = Convert.ToInt32(Console.ReadLine());

                if (target > skeletonMage.id)
                {
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

                FightPlayer();
            }

            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;

                //Console.SetCursorPosition(15, 12);
                //Console.WriteLine("------------ History ------------");

                Console.SetCursorPosition(1, number1);
                Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
                number1++;
            }

            void ChooseWhoWillAttack(int i)
            {
                if (i == humanWarrior.id)
                {
                    Console.SetCursorPosition(1, 1);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(humanWarrior.id + "." + humanWarrior.name);
                    number2++;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == humanArcher.id)
                {
                    Console.SetCursorPosition(1, 2);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(humanArcher.id + "." + humanArcher.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (i == humanMage.id)
                {
                    Console.SetCursorPosition(1, 3);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(humanMage.id + "." + humanMage.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            void FightPlayer()
            {
                int playerIndex = random.Next(player_army.Count);
                int enemyIndex = random.Next(enemy_army.Count);

                Unit enemy = enemy_army[enemyIndex];
                Unit player = player_army[playerIndex];

                player.hp -= enemy.dmg;

                Console.SetCursorPosition(1, number1);
                Console.WriteLine(enemy.name + " attacks " + player.name + ", dealing " + enemy.dmg + " damage.");
                number1++;
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

            void CheckHealthEnemy(Unit unit)
            {
                int pos = numberEnemy;

                if (unit.hp == unit.maxHealth)
                {
                    enemyHealth = "(full health)";

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(42, pos);

                    Console.WriteLine(enemyHealth);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else if (unit.hp <= unit.maxHealth)
                {
                    enemyHealth = "(damaged)    ";

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(42, pos);

                    Console.WriteLine(enemyHealth);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else if (unit.hp < unit.hp/2)
                {
                    enemyHealth = "(barely alive      )";

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(42, pos);

                    Console.WriteLine(enemyHealth);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            void CheckIfAlive()
            {
                for (int i = 0; i < player_army.Count; i++)
                {
                    if (player_army[i].hp <= 0)
                    {
                        player_army.RemoveAt(i);
                    }
                }

                for (int i = 0; i < enemy_army.Count; i++)
                {
                    if (enemy_army[i].hp <= 0)
                    {
                        enemy_army.RemoveAt(i);
                    }
                }
            }
        }

        private static void PlaySound_GameOver()
        {
            SoundPlayer my_wave_file = new SoundPlayer("Sounds/GameOver.wav");
            my_wave_file.PlaySync();
        }
    }
}