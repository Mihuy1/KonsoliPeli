using System;
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

                    // Let the player choose which character attacks and then which enemy it will attack
                    Console.WriteLine("Give number to choose: ");
                    int player = Convert.ToInt32(Console.ReadLine());
                    string chosenPlayer;
                    int chosenPlayerDMG;

                    // Make the integer equal to the chosen player
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
                    string chosenTarget = "s";

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
                        Console.WriteLine(chosenPlayer + " dealt" + chosenPlayerDMG + " damage");
                        Console.WriteLine(chosenTarget + " now has " + target + " health");

                        // To continue user has to press a key.
                        Console.WriteLine("Press Enter to continue....");

                        Console.ReadLine();
                    }
                }

                else if (secondPlayerAttacked == false)
                {
                    // Choose randomly which player character to attack and who will attack
                    Console.WriteLine("AI's turn");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine(); // Wait for input to continue

                    int AIHP = rand.Next(1, 3); // virhe!!!!!!!!!!!!!
                    int AIDMG;
                    string AICharacter;

                    if (AIHP == 1)
                    {
                        AIHP = skeletonWarriorHP;
                        AICharacter = skeletonWarrior;
                        AIDMG = skeletonWarriorDMG;
                        Console.WriteLine("AI chose " + AICharacter);
                    } else if (AIHP == 2)
                    {
                        AIHP = skeletonArcherHP;
                        AICharacter = skeletonArcher;
                        AIDMG = skeletonArcherDMG;
                        Console.WriteLine("AI chose" + AICharacter);
                    } else
                    {
                        AIHP = skeletonMageHP;
                        AICharacter = skeletonMage;
                        AIDMG = skeletonMageDMG;
                    }

                    int AITargetHP = rand.Next(1, 3); // Randomly choose which character to attack
                    string AITarget; // string of the chosen player character

                    // Now make the integer and string equal to the chosen player character
                    if (AITargetHP == 1)
                    {
                        AITargetHP = humanWarriorHP;
                        AITarget = humanWarrior;
                    } else if (AITargetHP == 2)
                    {
                        AITargetHP = humanArcherHP;
                        AITarget = humanArcher;
                    } else
                    {
                        AITargetHP = humanMageHP;
                        AITarget = humanMage;
                    }

                    if (AIHP <= 0)
                    {
                        Console.WriteLine(AICharacter + " died");
                    }

                    for (int i = 0; i < 1;i++)
                    {
                        AIDMG = rand.Next(5, 20); // set random damage

                        AITargetHP -= AIDMG; // First player takes damage from second player.
                        secondPlayerAttacked = true;
                        firstPlayerAttacked = false;

                        Console.WriteLine(AICharacter + " dealt " + AIDMG + " damage");
                        Console.WriteLine(AITarget + " now has " + AITargetHP + " health");

                        Console.WriteLine("Press Enter to continue....");

                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
