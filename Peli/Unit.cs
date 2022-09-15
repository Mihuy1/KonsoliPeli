using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Peli
{
    public class Unit
    {
        public string humanWarrior;
        public int humanWarriorHP;
        public int humanWarriorDMG;

        public string humanArcher;
        public int humanArcherHP;
        public int humanArcherDMG;

        public string humanMage;
        public string humanMageHP;
        public string humanMageDMG;

        public string skeletonWarrior;
        public int skeletonWarriorHP;
        public int skeletonWarriorDMG;

        public Unit(string humanWarrior, string skeletonWarrior, int humanWarriorDMG, int skeletonWarriorHP, int humanWarriorHP, int skeletonWarriorDMG)
        {
            this.humanWarrior = humanWarrior;
            this.skeletonWarrior = skeletonWarrior;
            this.humanWarriorDMG = humanWarriorDMG;
            this.skeletonWarriorDMG = skeletonWarriorDMG;
            this.humanWarriorHP = humanWarriorHP;
            this.skeletonWarriorHP = skeletonWarriorHP;
        }

        public void Fight()
        {
            Random random = new Random();

            humanWarrior = "Human Warrior";
            skeletonWarrior = "Skeleton Warrior";
            humanWarriorHP = random.Next(50, 100);
            skeletonWarriorHP = random.Next(50, 100);

            Console.WriteLine(humanWarrior + " has " + humanWarriorHP + " health" + " and " + humanWarriorDMG + " damage");
            Console.WriteLine(skeletonWarrior + " has " + skeletonWarriorHP + " health" + " and " + humanWarriorDMG + " damage");

            Console.WriteLine("To start press enter...");
            Console.ReadLine();

            Console.WriteLine("Test");

            Damage();

        }

        public void Damage(bool firstPlayerAttacked = false, bool secondPlayerAttacked = false)
        {

            while (humanWarriorHP >= 0 && skeletonWarriorHP >= 0)
            {
                Random rand = new Random();


                if (firstPlayerAttacked == false)
                {

                    for (int i = 0; i < 1; i++)
                    {
                        if (humanWarriorHP <= 0)
                        {
                            Console.WriteLine(humanWarrior + " died!");
                        }

                        humanWarriorDMG = rand.Next(5, 20); // Set random damage

                        skeletonWarriorHP -= humanWarriorDMG; // Second player takes damage from first player.
                        firstPlayerAttacked = true;
                        secondPlayerAttacked = false;

                        Console.WriteLine(humanWarrior+ " attacked " + skeletonWarrior + " and dealt " + humanWarriorDMG + " of damage");
                        Console.WriteLine(humanWarrior + " has " + humanWarriorHP + " health and " + skeletonWarrior + " has" + skeletonWarriorHP + " health");

                        // To continue user has to press a key.
                        Console.WriteLine("Press Enter to continue....");

                        Console.ReadLine();
                    }
                }

                else if (secondPlayerAttacked == false)
                {

                    if (skeletonWarriorHP <= 0)
                    {
                        Console.WriteLine(skeletonWarrior + " died");
                    }

                    for (int i = 0; i < 1;i++)
                    {
                        skeletonWarriorDMG = rand.Next(5, 20); // set random damage

                        humanWarriorHP -= skeletonWarriorDMG; // First player takes damage from second player.
                        secondPlayerAttacked = true;
                        firstPlayerAttacked = false;

                        Console.WriteLine(skeletonWarrior + " attacked " + humanWarrior + " and dealt " + skeletonWarriorDMG + " of damage");
                        Console.WriteLine(skeletonWarrior + " has " + skeletonWarriorHP + " health and " + humanWarrior + " has " + humanWarriorHP + " health");

                        Console.WriteLine("Press Enter to continue....");

                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
