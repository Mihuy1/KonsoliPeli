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
        public int humanMageHP;
        public int humanMageDMG;

        public string skeletonWarrior;
        public int skeletonWarriorHP;
        public int skeletonWarriorDMG;

        public string skeletonArcher;
        public int skeletonArcherHP;
        public int skeletonArcherDMG;

        public string skeletonMage;
        public int skeletonMageHP;
        public int skeletonMageDMG;

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

            humanWarrior = "Human Warrior";
            humanArcher = "Human Archer";
            humanMage = "Human Mage";

            skeletonWarrior = "Skeleton Warrior";
            skeletonArcher = "Skeleton Archer";
            skeletonMage = "Skeleton Mage";

            humanWarriorHP = 100;
            humanArcherHP = 60;
            humanMageHP = 50;


            skeletonWarriorHP = 100;
            skeletonArcherHP = 60;
            skeletonMageHP = 50;

            Console.WriteLine("Player's army: ");
            Console.WriteLine(humanWarrior + "\n" + humanArcher + "\n" + humanMage);

            Console.WriteLine("AI's army: ");
            Console.WriteLine(skeletonWarrior + "\n" + skeletonArcher + "\n" + skeletonMage);

            Console.WriteLine("To start press enter...");
            Console.ReadLine();

            Damage();

        }

        public void Damage(bool firstPlayerAttacked = false, bool secondPlayerAttacked = false)
        {

            while (humanWarriorHP >= 0 && humanArcherHP >= 0 && humanMageHP >= 0 && skeletonWarriorHP >= 0 && skeletonArcherHP >= 0
                && skeletonMageHP >= 0)
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

                        Console.WriteLine(humanWarrior + " attacked " + skeletonWarrior + " and dealt " + humanWarriorDMG + " of damage");
                        Console.WriteLine(humanWarrior + " has " + humanWarriorHP + " health and " + skeletonWarrior + " has " + skeletonWarriorHP + " health");

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
