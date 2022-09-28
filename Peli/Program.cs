using System;
using System.Collections.Generic;
using System.Linq;
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

            const int HUMANWARRIOR = 1;
            const int HUMANARCHER = 2;
            const int HUMANMAGE = 3;

            const int SKELETONWARRIOR = 4;
            const int SKELETONARCHER = 5;
            const int SKELETONMAGE = 6;

            Unit humanWarrior = new Unit("Human Warrior", random.Next(8,15), 45);
            Unit humanArcher = new Unit("Human Archer", random.Next(10,20), 25);
            Unit humanMage = new Unit("Human Mage", random.Next(5,10),24);

            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(9,15), 45);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(10, 20), 25);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(5,10), 24);

            player_army.Add(humanWarrior);
            player_army.Add(humanArcher);
            player_army.Add(humanMage);
            
            enemy_army.Add(skeletonWarrior);
            enemy_army.Add(skeletonArcher);
            enemy_army.Add(skeletonMage);


            while (true)
            {
                int number = 1;
                int number2 = 4;

                string chooseCharacter = "";
                string chooseEnemy = "";

                if (CheckIfWon() == true)
                {
                    break;
                }


                Console.WriteLine("Choose Character");

                Console.ForegroundColor = ConsoleColor.Green;

                foreach (Unit unit in player_army)
                {
                    chooseCharacter += number + "." + unit.name + "\n";
                    number++;
                }

                Console.WriteLine(chooseCharacter);
                Console.ForegroundColor= ConsoleColor.White;

                int attacker = Convert.ToInt32(Console.ReadLine());
                
                // Valitaan kuka hyökkää
                if (attacker == HUMANWARRIOR)
                {
                    if (CheckIfAlive(humanWarrior))
                    {
                        Console.WriteLine("You chose: " + humanWarrior.name);

                    } 

                } else if (attacker == HUMANARCHER)
                {
                    if (CheckIfAlive(humanArcher) == true)
                    {
                        Console.WriteLine("You chose: " + humanArcher.name);
                    } 

                } else if (attacker == HUMANMAGE)
                {
                    if (CheckIfAlive(humanMage) == true)
                    {
                        Console.WriteLine("You chose: " + humanMage.name);
                    }

                    if (CheckIfAlive(humanMage) == false)
                    {
                        Console.WriteLine("Press Enter to choose character again");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }

                // Valitaan vihollinen
                Console.WriteLine("Choose which one to attack: ");

                Console.ForegroundColor = ConsoleColor.DarkRed;

                foreach (Unit unit in enemy_army)
                {
                    chooseEnemy += number2 + "." + unit.name + "\n";
                    number2++;
                }

                Console.WriteLine(chooseEnemy);
                Console.ForegroundColor = ConsoleColor.White;

                int target = Convert.ToInt32(Console.ReadLine());

                var attackerUnit = player_army[attacker - 1];
                if (target == SKELETONWARRIOR)
                {
                    Console.WriteLine("You chose: " + skeletonWarrior.name);

                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonWarrior);

                    Console.WriteLine(attackerUnit.name + " attacked " + skeletonWarrior.name + " and dealt " + attackerUnit.dmg
                    + "\n" + skeletonWarrior.name + " now has " + skeletonWarrior.hp + " health");

                    CheckIfAliveEnemy(skeletonWarrior); // Check if hp is equal to or lower than 0

                } 
                else if (target == SKELETONARCHER)
                {
                    Console.WriteLine("You chose: " + skeletonArcher.name);

                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonArcher);

                    Console.WriteLine(attackerUnit.name + " attacked " + skeletonArcher.name + " and dealt " + attackerUnit.dmg 
                    + "\n" + skeletonArcher.name + " now has " + skeletonArcher.hp + " health");

                    CheckIfAliveEnemy(skeletonArcher); // Check if hp is equal to or lower than 0
                } 
                else if (target == SKELETONMAGE)
                {
                    Console.WriteLine("You chose: " + skeletonMage.name);

                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonMage);

                    Console.WriteLine(attackerUnit.name + " attacked " + skeletonMage.name + " and dealt " + attackerUnit.dmg 
                    + "\n" + skeletonMage.name + " now has " + skeletonMage.hp + " health");

                    CheckIfAliveEnemy(skeletonMage); // Check if hp is equal to or lower than 0
                }

                PressEnterToContinue();

                // Hyökätään pelaajaa
                FightPlayer();

                PressEnterToContinue();


            }

            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;
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

            bool CheckIfAlive(Unit unit)
            {

                if (unit.hp <= 0)
                {
                    player_army.Remove(unit);
                    Console.WriteLine(unit.name + " died!");
                    
                    return false;
                }

                return true;

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

            void PressEnterToContinue()
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

            bool CheckIfWon()
            {
                if (player_army.Count == 0)
                {
                    Console.WriteLine("Enemy won!");
                    return true;
                } else if (enemy_army.Count == 0)
                {
                    Console.WriteLine("Player won!");
                    return true;
                }

                return false;
            }
        }

    }
}