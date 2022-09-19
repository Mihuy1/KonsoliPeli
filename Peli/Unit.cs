﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            // List armies
            Console.WriteLine("Player's army: ");
            Console.WriteLine("1: " + humanWarrior + "\n" + "2: " + humanArcher + "\n" + "3: " + humanMage);

            Console.WriteLine("AI's army: ");
            Console.WriteLine("1: " + skeletonWarrior + "\n" + "2: " + skeletonArcher + "\n" + "3: " + skeletonMage);

            // Press enter to start game...
            Console.WriteLine("To start press enter...");
            Console.ReadLine();

            Damage();

        }

        public void Damage(bool firstPlayerAttacked = false, bool secondPlayerAttacked = false)
        {

            int playerArmy = humanWarriorHP + humanArcherHP + humanMageHP;
            int aiArmy = skeletonWarriorHP + skeletonArcherHP + skeletonMageHP;

            while (playerArmy >= 0 && aiArmy >= 0)
            {
                Random rand = new Random();


                if (firstPlayerAttacked == false)
                {
                    Console.WriteLine("Give number to choose: ");
                    int player = Convert.ToInt32(Console.ReadLine());
                    string chosenPlayer;
                    int chosenPlayerDMG;

                    if (player == 1)
                    {
                        chosenPlayer = humanWarrior;
                        chosenPlayerDMG = humanWarriorDMG;
                        player = humanWarriorHP;
                    }
                    else if (player == 2)
                    {
                        chosenPlayer = humanArcher;
                        chosenPlayerDMG = humanArcherDMG;
                        player = humanArcherHP;
                    }
                    else
                    {
                        chosenPlayer = humanMage;
                        chosenPlayerDMG = humanMageDMG;
                        player = humanMageHP;
                    }

                    Console.WriteLine("Choose target: ");
                    int target = Convert.ToInt32(Console.ReadLine());
                    string chosenTarget;

                    if (target == 1 && skeletonWarriorHP > 0)
                    {
                        target = skeletonWarriorHP;
                        chosenTarget = skeletonWarrior;
                    } else if (target == 2 && skeletonArcherHP > 0)
                    {
                        target = skeletonArcherHP;
                        chosenTarget = skeletonArcher;
                    } else if (target == 3 && skeletonMageHP > 0)
                    {
                        target = skeletonMageHP;
                        chosenTarget = skeletonMage;
                    }

                    for (int i = 0; i < 1; i++)
                    {
                        if (player <= 0)
                        {
                            Console.WriteLine(chosenPlayer + " died!");
                        }

                        chosenPlayerDMG = rand.Next(5, 20); // Set random damage for chosen character

                        target -= chosenPlayerDMG; // AI takes damage from player
                        firstPlayerAttacked = true; // Player's army has attacked
                        secondPlayerAttacked = false; // AI's army hasn't attacked yet

                        // Print dealth damage & health here:

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
