namespace Peli
{
    public class Unit
    {
        private const int HUMANWARRIOR = 1;
        private const int HUMANARCHER = 2;
        private const int HUMANMAGE = 3;

        private const int SKELETONWARRIOR = 4;
        private const int SKELETONARCHER = 5;
        private const int SKELETONMAGE = 6;

        /*
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
        public int skeletonMageDMG;*/

        public string name;
        public int dmg;
        public int hp;
        public int id;

        public Unit(string name, int dmg, int health, int id)
        {
            this.name = name;
            this.dmg = dmg;
            this.hp = health;
            this.id = id;
        }

        public void Fight()
        {

            /*humanWarrior = "Human Warrior";
            humanArcher = "Human Archer";
            humanMage = "Human Mage";

            skeletonWarrior = "Skeleton Warrior";
            skeletonArcher = "Skeleton Archer";
            skeletonMage = "Skeleton Mage";*/

            /*humanWarriorHP = 100;
            humanArcherHP = 60;
            humanMageHP = 50;*/

            /*
            skeletonWarriorHP = 100;
            skeletonArcherHP = 60;
            skeletonMageHP = 50;*/

            // List armies
            /*
            Console.WriteLine("Player's army: ");
            Console.WriteLine("1: " + humanWarrior + "\n" + "2: " + humanArcher + "\n" + "3: " + humanMage);

            Console.WriteLine("AI's army: ");
            Console.WriteLine("4: " + skeletonWarrior + "\n" + "5: " + skeletonArcher + "\n" + "6: " + skeletonMage);*/

           // Damage();

        }
        /*
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
                    Console.WriteLine("Choose character: " + "(1-3)");
                    int player = Convert.ToInt32(Console.ReadLine());
                    string chosenPlayer = null;
                    int chosenPlayerDMG;

                    // Make the integer equal to the chosen player
                    if (player == HUMANWARRIOR && humanWarriorHP > 0)
                    {
                        chosenPlayer = humanWarrior;
                        chosenPlayerDMG = humanWarriorDMG;
                    }

                    else if (player == HUMANARCHER && humanArcherHP > 0)
                    {
                        chosenPlayer = humanArcher;
                        chosenPlayerDMG = humanArcherDMG;
                        player = humanArcherHP;
                    }

                    else if (player == HUMANMAGE && humanMageHP > 0)
                    {
                        chosenPlayer = humanMage;
                        chosenPlayerDMG = humanMageDMG;
                        player = humanMageHP;
                    }
                    
                    // Let player choose which target to attack & who attacks

                    Console.WriteLine("Choose target: " + "(4-6)");
                    int target = Convert.ToInt32(Console.ReadLine());
                    string chosenTarget = null;

                    if (target == SKELETONWARRIOR && skeletonWarriorHP > 0)
                    {

                        target = skeletonWarriorHP; // Target is skeleton warrior
                        chosenTarget = skeletonWarrior;
                    } 

                    else if (target == SKELETONARCHER && skeletonArcherHP > 0)
                    {
                        target = skeletonArcherHP; // target is skeleton archer
                        chosenTarget = skeletonArcher;
                    } 
                    
                    else if (target == SKELETONMAGE && skeletonMageHP > 0)
                    {
                        target = skeletonMageHP; // target is skeleton mage
                        chosenTarget = skeletonMage;
                    }


                    // Chosen character attacks enemy

                    for (int i = 0; i < 1; i++)
                    {
                        if (player <= 0)
                        {
                            Console.WriteLine(chosenPlayer + " died!");
                        }

                        chosenPlayerDMG = rand.Next(15, 35); // Set random damage for chosen character

                        target -= chosenPlayerDMG; // AI takes damage from player
                        firstPlayerAttacked = true; // Player's army has attacked
                        secondPlayerAttacked = false; // AI's army hasn't attacked yet

                        // Print dealth damage & health here:
                        Console.WriteLine(chosenPlayer + " dealt " + chosenPlayerDMG + " damage" + " to " + chosenTarget);
                        Console.WriteLine(chosenTarget + " now has " + target + " health");

                        // To continue user has to press a key.
                        Console.WriteLine("Press Enter to continue....");

                        Console.WriteLine("Hwarrior: " + humanWarriorHP + " Harcher: " + humanArcherHP + " Hmage " + humanMageHP + "\n" + " Swarrior: " + skeletonWarriorHP
                            + " Sarcher: " + skeletonArcherHP + "Smage: " + skeletonMageHP);

                        Console.ReadLine();
                    }
                }




                // AI's turn /////////////////////////////////

                else if (secondPlayerAttacked == false)
                {
                    // Choose randomly which player character to attack and who will attack
                    Console.WriteLine("AI's turn");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine(); // Wait for input to continue

                    int AIChosenCharacter = rand.Next(4, 6); // Random AI character
                    int AIHP = 0; // HP of the character that was randomly chosen
                    int AIDMG; // Damage of the character that was randomly chosen
                    string AICharacter = ""; // Name of the character


                    
                    if (AIChosenCharacter == SKELETONWARRIOR && skeletonWarriorHP > 0)
                    {
                        AIHP = skeletonWarriorHP;
                        AICharacter = skeletonWarrior;
                        AIDMG = skeletonWarriorDMG;
                        Console.WriteLine("AI chose " + AICharacter);
                    } 
                    
                    else if (AIChosenCharacter == SKELETONARCHER && skeletonArcherHP > 0)
                    {
                        AIHP = skeletonArcherHP;
                        AICharacter = skeletonArcher;
                        AIDMG = skeletonArcherDMG;
                        Console.WriteLine("AI chose " + AICharacter);
                    } 
                    
                    else if (AIChosenCharacter == SKELETONMAGE && skeletonMageHP > 0)
                    {
                        AIHP = skeletonMageHP;
                        AICharacter = skeletonMage;
                        AIDMG = skeletonMageDMG;
                        Console.WriteLine("AI chose" + AICharacter);
                    }


                    int AITargetHP = rand.Next(1, 3); // Randomly choose which character to attack
                    string AITarget; // string of the chosen player character

                    // Now make the integer and string equal to the chosen player character
                    if (AITargetHP == HUMANWARRIOR)
                    {
                        AITargetHP = humanWarriorHP;
                        AITarget = humanWarrior;
                    } else if (AITargetHP == HUMANARCHER)
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
                        AIDMG = rand.Next(50, 60); // set random damage

                        AITargetHP -= AIDMG; // First player takes damage from second player.
                        secondPlayerAttacked = true;
                        firstPlayerAttacked = false;

                        Console.WriteLine(AICharacter + " dealt " + AIDMG + " damage" + " to " + AITarget);
                        Console.WriteLine(AITarget + " now has " + AITargetHP + " health");
        */

                    }/*
                }
            }*/
        }
    //}
//}
