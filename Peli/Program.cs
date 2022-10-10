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

            Unit humanWarrior = new Unit("Human Warrior", random.Next(8, 15), 80, 80, 1);
            Unit humanArcher = new Unit("Human Archer", random.Next(10, 20), 50, 50, 2);
            Unit humanMage = new Unit("Human Mage", random.Next(5, 10), 30, 30, 3);

            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(9, 15), 80, 80, 4);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(10, 20), 50, 50, 5);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(5, 10), 30, 30, 6);

            player_army.Add(humanWarrior);
            player_army.Add(humanArcher);
            player_army.Add(humanMage);

            enemy_army.Add(skeletonWarrior);
            enemy_army.Add(skeletonArcher);
            enemy_army.Add(skeletonMage);

            int number1 = 13;
            int numberEnemy = 1;
            int numberPlayer = 1;

            string enemyHealth = "";

            while (true)
            {
                numberEnemy = 1;
                numberPlayer = 1;

                if (CheckIfWon())
                {
                    break;
                }

                CheckIfAlive();

                // Listaa "Status", "Message" , "History"
                PrintBase();

                // Listaa pelaajan tiimin ja vihollisen tiimin
                PrintArmies();

                Console.ForegroundColor = ConsoleColor.White;
                int attacker = Convert.ToInt32(Console.ReadLine());

                if (attacker > humanMage.id)
                {
                    Console.SetCursorPosition(1, 9);
                    Console.WriteLine("Incorrect id!");
                    attacker = Convert.ToInt32(Console.ReadLine());
                }

                ChooseWhoWillAttack(attacker);

                //////////////////////////////////////////////////////////

                // Valitaan vihollinen
                Console.SetCursorPosition(1, 8);
                Console.Write("Who to attack: ");

                int target = Convert.ToInt32(Console.ReadLine());
                
                ChooseEnemy(target);
                PressAnyKey();

                if (target > skeletonMage.id)
                {
                    Console.WriteLine("Incorrect id!");
                    target = Convert.ToInt32(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.White;

                var attackerUnit = player_army[attacker - 1];

                FightEnemy(attackerUnit, enemy_army[target - 4]); // Hyökkää vihollista

                FightPlayer(); // Hyökkää pelaajaa
            }

            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;

                Console.SetCursorPosition(1, number1);
                Console.WriteLine(attacker.name + " attacks " + target.name + ", dealing " + attacker.dmg + " damage.");
                number1++;
            }

            void ChooseWhoWillAttack(int i)
            {
                Console.SetCursorPosition(1, i);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(player_army[i - 1].id + "." + player_army[i - 1].name);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            void ChooseEnemy(int i)
            {
                Console.SetCursorPosition(24, i - 3);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(enemy_army[i - 4].id + "." + enemy_army[i - 4].name);
                Console.BackgroundColor = ConsoleColor.Black;
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
            }

            void PrintBase()
            {

                Console.SetCursorPosition(15, 0);
                Console.WriteLine("[------------ Status ------------]");

                Console.SetCursorPosition(15, 7);
                Console.WriteLine("[------------ Message ------------]");

                Console.SetCursorPosition(15, 12);
                Console.WriteLine("------------ History ------------");
            }

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

            }

            void PressAnyKey()
            {
                int i = 9;
                Console.SetCursorPosition(1, i);
                Console.WriteLine("Press any key to start fight....");
                Console.ReadKey();
                i++;

            }
        }

        private static void PlaySound_GameOver()
        {
            SoundPlayer my_wave_file = new SoundPlayer("Sounds/GameOver.wav");
            my_wave_file.PlaySync();
        }
    }
}