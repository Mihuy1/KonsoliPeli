using System.Media;

namespace Peli
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<Unit> player_army = new List<Unit>();
            List<Unit> enemy_army = new List<Unit>();

            Random random = new Random();

            Unit humanWarrior = new Unit("Human Warrior", random.Next(8, 15), 60, 60, false, 1);
            Unit humanArcher = new Unit("Human Archer", random.Next(10, 20), 50, 50, false, 2);
            Unit humanMage = new Unit("Human Mage", random.Next(5, 10), 30, 30, false, 3);

            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(9, 15), 60, 60, false, 4);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(10, 20), 50, 50, false, 5);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(5, 10), 30, 30, false, 6);

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

            bool humanW = false, humanA = false, humanM = false;

            string enemyHealth = "";

            while (true)
            {
                numberEnemy = 1;
                numberPlayer = 1;

                if (count > 2)
                {
                    CheckIfEveryoneAttacked();
                    Console.Clear();
                }

                if (CheckIfWon())
                {
                    break;
                }

                CheckIfEveryoneAttacked();

                CheckIfAlive();

                PrintBase();
                PrintArmies();

                // Valitaan kuka hyökkää vihollista
                Console.ForegroundColor = ConsoleColor.White;
                 attacker = Console.ReadKey().KeyChar;
                AsciiToInteger(attacker);

                if (attacker > humanMage.id)
                {
                    Console.SetCursorPosition(1, 9);
                    Console.Write("Incorrect id!");
                    attacker = Console.ReadKey().KeyChar;
                }

                ChooseWhoWillAttack(player_army[attacker-1]);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Valitaan vihollinen
                Console.SetCursorPosition(1, 8);
                Console.WriteLine("Who to attack: ");

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

                FightEnemy(attackerUnit, enemy_army[target - 4]);

                FightPlayer();

                count++;

            }

            void FightEnemy(Unit attacker, Unit target)
            {
                if (attacker.attacked == false)
                {
                    target.hp -= attacker.dmg;

                    Console.SetCursorPosition(1, number1);
                    Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
                    number1++;
                    attacker.attacked = true;
                }
            } // Hyökkää vihollista

            void ChooseWhoWillAttack(Unit unit)
            {
                if (unit.attacked == false)
                {
                    Console.SetCursorPosition(1, unit.id);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(unit.id + "." + unit.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                } else
                {
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(unit.name + " already attacked");

                    attacker = Console.ReadKey().KeyChar;

                    AsciiToInteger(attacker);

                    Unit unit2 = player_army[attacker - 1];

                    Console.SetCursorPosition(1, unit.id + 1);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(unit2.id + "." + unit2.name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            } // Valitsee kuka hyökkää

            void ChooseEnemy(Unit unit)
            {
                //Unit unit = enemy_army[i - 4];

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
                Console.WriteLine(enemy.name + " attacks " + player.name + ", dealing " + enemy.dmg + " damage.");
                number1++;
            } // Taistellaan pelaaja vastaan

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
            } // Tarkisetaan onko pelaaja/vihollinen voittanut

            void CheckIfAlive()
            {
                for (int i = 0; i < player_army.Count; i++)
                {
                    if (player_army[i].hp <= 0)
                    {
                        player_army.RemoveAt(i);
                        Console.Clear();
                    }
                }

                for (int i = 0; i < enemy_army.Count; i++)
                {
                    if (enemy_army[i].hp <= 0)
                    {
                        enemy_army.RemoveAt(i);
                        Console.Clear();
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
                    numberPlayer++;
                }

                foreach (Unit unit in enemy_army)
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
                    numberEnemy++;
                }

            } // Printtaa pelaajan- ja vihollisen armeijan

            void PressAnyKeyToStart()
            {
                int i = 9;
                Console.SetCursorPosition(0, i);
                Console.WriteLine("Press any key to start fight....");
                Console.ReadKey();
                Console.SetCursorPosition(0, i + 1);
                Console.WriteLine("        ");
                i++;

            } // Odottaa kun pelaaja painaa jotain nappia jotta taistelu alkaisi ja pistää sen oikeseen paikkaan.

            void CheckIfEveryoneAttacked()
            {
                foreach(Unit unit in player_army)
                {
                    if (unit.attacked == true)
                        unit.attacked = false;
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
        }

        private static void PlaySound_GameOver()
        {
            SoundPlayer my_wave_file = new SoundPlayer("Sounds/GameOver.wav");
            my_wave_file.PlaySync();
        }
    }
}