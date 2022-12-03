﻿using System.Diagnostics;
using System.Media;
using System.Security.Cryptography;
using System.Windows.Input;

namespace Peli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartWindow.Start();

            Console.WriteLine("Press any button to start game!");
            Console.ReadKey();

            List<Unit> player_army = new List<Unit>();
            List<Unit> enemy_army = new List<Unit>();

            List<int> warrior = new List<int>();
            List<int> archer = new List<int>();
            List<int> mage = new List<int>();

            List<int> eWarrior = new List<int>();
            List<int> eArcher = new List<int>();
            List<int> eMage = new List<int>();

            Random random = new Random();

            Unit humanWarrior = new Unit("Human Warrior", random.Next(8, 15), 60, 60, false, 1);
            Unit humanArcher = new Unit("Human Archer", random.Next(10, 20), 50, 50, false, 2);
            Unit humanMage = new Unit("Human Mage", random.Next(5, 10), 30, 30, false, 3);
            
            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(9, 15), 60, 60, false, 4);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(10, 20), 50, 50, false, 5);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(5, 10), 5, 5, false, 6);

            player_army.Add(humanWarrior);
            player_army.Add(humanArcher);
            player_army.Add(humanMage);

            enemy_army.Add(skeletonWarrior);
            enemy_army.Add(skeletonArcher);
            enemy_army.Add(skeletonMage);

            int number1 = 13;
            int numberEnemy = 1;
            int numberPlayer = 1;
            int target;
            int attacker;
            int count = 0;

            string enemyHealth = "";
            bool player = false;
            bool enemy = false;

            while (true)
            {

                numberEnemy = 1;
                numberPlayer = 1;

                warrior.Add(humanWarrior.hp);
                archer.Add(humanArcher.hp);
                mage.Add(humanMage.hp);
                eWarrior.Add(skeletonWarrior.hp);
                eArcher.Add(skeletonArcher.hp);
                eMage.Add(skeletonMage.hp);

                CheckIfEveryoneAttacked();

                if (CheckIfWon())
                {
                    Console.WriteLine("Joku voitti");

                    if (player)
                        EndWindow.PlayerWon();
                    else if (enemy)
                        EndWindow.EnemyWon();
                }

                CheckIfEveryoneAttacked();

                CheckIfAlive();

                PrintBase();
                PrintArmies();

                // Valitaan kuka hyökkää vihollista
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, 8);
                Console.WriteLine("Who will attack: ");
                Console.SetCursorPosition(18, 8);
                attacker = Console.ReadKey().KeyChar;
                AsciiToInteger(attacker);

                if (attacker > humanMage.id)
                {
                    Console.SetCursorPosition(1, 9);
                    Console.Write("Incorrect id!");
                    attacker = Console.ReadKey().KeyChar;
                }

                ChooseWhoWillAttack(player_army[attacker - 1]);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Valitaan vihollinen
                Console.SetCursorPosition(1, 9);
                Console.WriteLine("Who to attack: ");

                Console.SetCursorPosition(16, 9);
                target = Console.ReadKey().KeyChar;

                AsciiToInteger(target);
                ChooseEnemy(enemy_army[target - 4]);

                PressAnyKeyToStart();

                if (target > skeletonMage.id)
                {
                    Console.WriteLine("Incorrect id!");
                    target = Console.ReadKey().KeyChar;
                }

                Console.ForegroundColor = ConsoleColor.White;

                var attackerUnit = player_army[attacker - 1];

                FightEnemy(attackerUnit, enemy_army[target - 4]);;

                FightPlayer();

                Console.SetCursorPosition(18, 8);
                Console.WriteLine("  ");

                Console.SetCursorPosition(16, 9);
                Console.Write("  ");

                count++;

                if (count > 3)
                    count = 0;

                //if (warrior.Count >= 0)
                //{
                    Console.SetCursorPosition(0, number1 + 1);
                    Console.WriteLine("To Undo press: ctrl + z");

                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Modifiers.HasFlag(ConsoleModifiers.Control) && info.Key == ConsoleKey.Z)
                    {
                        Undo();
                    }
                    else
                    {
                        continue;
                    }
                //}
            }

            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;

                Console.SetCursorPosition(1, number1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
                Console.ForegroundColor = ConsoleColor.White;
                number1++;
                attacker.attacked = true;
            } // Hyökkää vihollista

            void ChooseWhoWillAttack(Unit unit)
            {
                if (unit.attacked == false)
                {
                    Console.SetCursorPosition(1, unit.id);

                    if (unit == humanWarrior)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(unit.id + "." + unit.name);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }

                    if (unit == humanArcher)
                    {
                        
                         if (humanWarrior.hp <= 0)
                        {
                            Console.SetCursorPosition(1, 1);
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(unit.id + "." + unit.name);
                            Console.BackgroundColor = ConsoleColor.Black;
                        } else
                        {
                            Console.SetCursorPosition(1, 2);
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(unit.id + "." + unit.name);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                    }

                    if (unit == humanMage)
                    {
                        if (humanArcher.hp <= 0 || humanWarrior.hp <= 0)
                        {
                            Console.SetCursorPosition(1, 2);
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(unit.id + "." + unit.name);
                            Console.BackgroundColor = ConsoleColor.Black;
                        } else
                        {
                            Console.SetCursorPosition(1, 3);
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(unit.id + "." + unit.name);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                } else
                {
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(unit.name + " already attacked");

                    Console.SetCursorPosition(8, 16);
                    attacker = Console.ReadKey().KeyChar;

                    AsciiToInteger(attacker);

                    ChooseWhoWillAttack(player_army[attacker - 1]);

                }
            } // Valitsee kuka hyökkää

            void ChooseEnemy(Unit unit)
            {
                Console.SetCursorPosition(24, unit.id - 3);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(unit.id + "." + unit.name);
                Console.BackgroundColor = ConsoleColor.Black;
            } // Valitaan ketä hyökätään

            void FightPlayer()
            {
                int playerIndex = random.Next(player_army.Count);
                int enemyIndex = random.Next(enemy_army.Count);

                Unit player = player_army[playerIndex];
                Unit enemy = enemy_army[enemyIndex];

                player.hp -= enemy.dmg;

                Console.SetCursorPosition(1, number1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.name + " attacks " + player.name + ", dealing " + enemy.dmg + " damage.");
                Console.ForegroundColor = ConsoleColor.White;
                number1++;
            } // Taistellaan pelaaja vastaan

            bool CheckIfWon()
            {

                if (player_army.Count == 0)
                {
                    Console.WriteLine("Enemy won!");

                    SoundPlayer my_wave_file = new SoundPlayer("Sounds/GameOver.wav");
                    my_wave_file.PlaySync();

                    enemy = true;
                    return true;

                }
                else if (enemy_army.Count == 0)
                {
                    Console.WriteLine("Player won!");
                    player = true;
                    return true;
                }

                return false;
            } // Tarkisetaan onko pelaaja/vihollinen voittanut

            void CheckIfAlive()
            {
                for (int i = 0; i < player_army.Count; i++)
                {
                    if (player_army[i].hp <= 0)
                    {
                        //player_army.RemoveAt(i);
                        Console.SetCursorPosition(1, player_army[i-1].id);
                        Console.WriteLine("Dead");
                        Console.Clear();
                    }
                }

                for (int i = 0; i < enemy_army.Count; i++)
                {
                    if (enemy_army[i].hp <= 0)
                    {
                        //enemy_army.RemoveAt(i);
                        Console.Clear();
                        Console.SetCursorPosition(24, i + 1);
                        Console.WriteLine("Dead");
                    }
                }
            } // Tarkistetaan jos joku on kuollut = siivotaan konsoli

            void PrintBase()
            {

                Console.SetCursorPosition(15, 0);
                Console.WriteLine("[------------ Status ------------]");

                Console.SetCursorPosition(15, 7);
                Console.WriteLine("[------------ Message ------------]");

                Console.SetCursorPosition(15, 12);
                Console.WriteLine("------------ History ------------");
            } // Printtaa Status, Message, History

            void PrintArmies()
            {
                foreach (Unit unit in player_army)
                {
                    if (unit.hp > 0)
                    {
                        Console.SetCursorPosition(1, numberPlayer);
                        Console.Write(unit.id + "." + unit.name);

                        if (unit.hp == unit.maxHealth)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("(" + unit.hp + "/" + unit.maxHealth + ")");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (unit.hp <= unit.maxHealth)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(" + unit.hp + "/" + unit.maxHealth + ")");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (unit.hp == unit.hp / 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + unit.hp + "/" + unit.maxHealth + ")");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (unit.hp == 10)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("(" + unit.hp + "/" + unit.maxHealth + ")");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    numberPlayer++;
                }

                foreach (Unit unit in enemy_army)
                {
                    if (unit.hp > 0)
                    {
                        Console.SetCursorPosition(24, numberEnemy);
                        Console.WriteLine(unit.id + "." + unit.name);

                        if (unit.hp == unit.maxHealth)
                        {
                            enemyHealth = "(full health)";

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(43, numberEnemy);

                            Console.WriteLine(enemyHealth);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (unit.hp <= unit.maxHealth)
                        {
                            enemyHealth = "(damaged)    ";

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(43, numberEnemy);

                            Console.WriteLine(enemyHealth);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (unit.hp < 10)
                        {
                            enemyHealth = "(barely alive  )";

                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.SetCursorPosition(43, numberEnemy);

                            Console.WriteLine(enemyHealth);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    numberEnemy++;
                }

            } // Printtaa pelaajan- ja vihollisen armeijan

            void PressAnyKeyToStart()
            {
                int i = 10;
                Console.SetCursorPosition(0, i);
                Console.WriteLine("Press any key to start fight....");
                Console.ReadKey();
                Console.SetCursorPosition(0, i + 1);
                Console.WriteLine("        ");
                i++;

                if (i > 11)
                {
                    Console.SetCursorPosition(5, 15);
                }
            } // Odottaa kun pelaaja painaa jotain nappia jotta taistelu alkaisi ja pistää sen oikeseen paikkaan.

            void CheckIfEveryoneAttacked()
            {
                int i = 0;
               foreach (Unit unit in player_army)
                {
                    if (unit.attacked == true)
                        i++;
                }

               foreach (Unit unit in player_army)
                {
                    if (i == player_army.Count)
                    {
                        unit.attacked = false;
                    }
                }

               if (player_army.Count == 1)
                {
                    foreach (Unit unit in player_army)
                    {
                        unit.attacked = false;
                    }
                }
            } // Tarkistaa jos kaikki on hyökänny = pistetään booleanit takaisin falseen

            void AsciiToInteger(int i)
            {
                // Pelaaja
                if (i == 49)
                    attacker = 1;
                else if (i == 50)
                    attacker = 2;
                else if (i == 51)
                    attacker = 3;

                // Vihollinen
                else if (i == 52)
                    target = 4;
                else if (i == 53)
                    target = 5;
                else if (i == 54)
                    target = 6;
            } // Converttaa asciista oikeisiin numeroihin.

            void Undo()
            {
                if (warrior.Count > 0)
                {
                    humanWarrior.hp = warrior[warrior.Count - 1];
                    humanArcher.hp = archer[archer.Count - 1];
                    humanMage.hp = mage[mage.Count - 1];

                    skeletonWarrior.hp = eWarrior[eWarrior.Count - 1];
                    skeletonArcher.hp = eArcher[eArcher.Count - 1];
                    skeletonMage.hp = eMage[eMage.Count - 1];
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