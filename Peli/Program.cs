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

            const int HUMANWARRIOR = 1;
            const int SKELETONWARRIOR = 2;

            Unit humanWarrior = new Unit("Human Warrior", 5, 10);
            Unit skeletonWarrior = new Unit("Skeleton Warrior", 5, 15);

            player_army.Add(humanWarrior);
            enemy_army.Add(skeletonWarrior);


            while (true)
            {
                if (humanWarrior.hp <= 0)
                {
                    Console.WriteLine(skeletonWarrior.name + " won!");
                    break;
                }
                else if (skeletonWarrior.hp <= 0)
                {
                    Console.WriteLine(humanWarrior.name + " won!");
                    break;
                }

                Console.WriteLine("Choose character: " + "\n" + "1: " + "Human Warrior");
                int valinta = Convert.ToInt32(Console.ReadLine());
                

                if (valinta == HUMANWARRIOR)
                {
                    Console.WriteLine("You chose: " + humanWarrior.name);;
                }


                FightEnemy();

                Console.WriteLine("Press Enter to Continue....");
                Console.ReadLine();


                FightPlayer(); 
                
             
            }

            void FightEnemy()
            {
                skeletonWarrior.hp -= humanWarrior.dmg;
                Console.WriteLine(humanWarrior.name + " attacked " + skeletonWarrior.name + " and dealt " + humanWarrior.dmg + "\nnow " +
                skeletonWarrior.name + " has " + skeletonWarrior.hp + " hp");
            }

            void FightPlayer()
            {
                humanWarrior.hp -= skeletonWarrior.dmg;
                Console.WriteLine(skeletonWarrior.name + " attacked " + humanWarrior.name + "\nNow " + humanWarrior.name + " has "
                + humanWarrior.hp + " health");
            }
        }

    }
}