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

            Unit humanWarrior = new Unit("Human Warrior", random.Next(5,10), 15);
            Unit humanArcher = new Unit("Human Archer", random.Next(5,10), 10);
            Unit humanMage = new Unit("Human Mage", random.Next(5,10),10);

            Unit skeletonWarrior = new Unit("Skeleton Warrior", random.Next(5,10), 15);
            Unit skeletonArcher = new Unit("Skeleton Archer", random.Next(5, 10), 10);
            Unit skeletonMage = new Unit("Skeleton Mage", random.Next(6,10), 10);

            player_army.Add(humanWarrior);
            player_army.Add(humanArcher);
            player_army.Add(humanMage);
            
            enemy_army.Add(skeletonWarrior);
            enemy_army.Add(skeletonArcher);
            enemy_army.Add(skeletonMage);

            string chooseCharacter = "Choose character: " + "\n" + "1: " + humanWarrior.name + "\n2: "
            + humanArcher.name + "\n3: " + humanMage.name;

            string chooseEnemy = "Choose which enemy to attack:\n4: " + skeletonWarrior.name 
            + "\n5: " + skeletonArcher.name + "\n6: " + skeletonMage.name;


            while (true)
            {

                Console.WriteLine(chooseCharacter);
                int attacker = Convert.ToInt32(Console.ReadLine());
                
                // Valitaan koka hyökkää
                if (attacker == HUMANWARRIOR)
                {
                    Console.WriteLine("You chose: " + humanWarrior.name);
                    CheckIfAlive(humanWarrior);

                } else if (attacker == HUMANARCHER)
                {
                    Console.WriteLine("You chose: " + humanArcher.name);
                    CheckIfAlive(humanArcher);

                } else if (attacker == HUMANMAGE)
                {
                    Console.WriteLine("You chose: " + humanMage.name);
                    CheckIfAlive(humanMage);
                }

                // Valitaan vihollinen
                Console.WriteLine("Choose which enemy to attack:\n4: " + skeletonWarrior.name + "\n5: " + skeletonArcher.name + "\n6: " + skeletonMage.name);
                int target = Convert.ToInt32(Console.ReadLine());

                var attackerUnit = player_army[attacker - 1];
                if (target == SKELETONWARRIOR)
                {
                    Console.WriteLine("You chose: " + skeletonWarrior.name);
                    FightEnemy(attackerUnit, skeletonWarrior);
                    Console.WriteLine(attackerUnit.name + " attacked " + skeletonWarrior.name + " and dealt " + attackerUnit.dmg
                    + "\n" + skeletonWarrior.name + " now has " + skeletonWarrior.hp + " health");

                    CheckIfAliveEnemy(skeletonWarrior);

                } 
                else if (target == SKELETONARCHER)
                {
                    Console.WriteLine("You chose: " + skeletonArcher.name);
                    FightEnemy(attackerUnit, skeletonArcher);
                    Console.WriteLine(attackerUnit.name + " attacked " + skeletonArcher.name + " and dealt " + attackerUnit.dmg 
                    + "\n" + skeletonArcher.name + " now has " + skeletonArcher.hp + " health");

                    CheckIfAliveEnemy(skeletonArcher);
                } 
                else if (target == SKELETONMAGE)
                {
                    Console.WriteLine("You chose: " + skeletonMage.name);
                    // Hyökätään vihollista
                    FightEnemy(attackerUnit, skeletonMage);
                    Console.WriteLine(attackerUnit.name + " attacked " + skeletonMage.name + " and dealt " + attackerUnit.dmg 
                    + "\n" + skeletonMage.name + " now has " + skeletonMage.hp + " health");
                    CheckIfAliveEnemy(skeletonMage);
                }

                

                Console.WriteLine("Press Enter to Continue....");
                Console.ReadLine();

                // Hyökätään pelaajaa
                FightPlayer();

                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();


            }

            void FightEnemy(Unit attacker, Unit target)
            {
                target.hp -= attacker.dmg;
            }

            void FightPlayer()
            {
                int index = random.Next(player_army.Count);

                if (index == 0)
                {
                    humanWarrior.hp -= skeletonWarrior.dmg;
                    Console.WriteLine(skeletonWarrior.name + " attacked " + humanWarrior.name + " and dealt " + skeletonWarrior.dmg + "\n" + humanWarrior.name + " has "
                        + humanWarrior.hp + " health");

                } else if (index == 1)
                {
                    humanArcher.hp -= skeletonArcher.dmg;
                    Console.WriteLine(skeletonArcher.name + " attacked " + humanArcher.name + " and dealt " + skeletonArcher.dmg + "\n" + humanArcher.name + " has "
                        + humanArcher.hp + " health");

                } else if (index == 2)
                {
                    humanMage.hp -= skeletonMage.dmg;

                    Console.WriteLine(skeletonMage.name + " attacked " + humanMage.name + " and dealt " + skeletonMage.dmg + "\n" + humanMage.name + " has "
                        + humanMage.hp + " health");
                }
            }

            void CheckIfAlive(Unit unit)
            {
                
                if (unit.hp <= 0)
                {
                    player_army.Remove(unit);
                    Console.WriteLine(unit.name + " died!");
                }

            }

            void CheckIfAliveEnemy(Unit unit)
            {
                if (unit.hp <= 0)
                {
                    enemy_army.Remove(unit);
                    Console.WriteLine(unit + " died");
                }
            }
        }

    }
}