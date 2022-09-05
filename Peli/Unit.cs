using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peli
{
    public class Unit
    {
        public string playerName;
        public string playerName2;
        public int damage;
        public int damage2;
        public int health;
        public int health2;

        public Unit(string playerName, string playerName2, int damage, int damage2, int health, int health2)
        {
            this.playerName = playerName;
            this.playerName2 = playerName2;
            this.damage = damage;
            this.damage2 = damage2;
            this.health = health;
            this.health2 = health2;
        }

        public void Fight()
        {
            Random random = new Random();

            playerName = "Human Warrior";
            playerName2 = "Skeleton Warrior";
            health = random.Next(25, 100);
            health2 = random.Next(25, 100);

            Damage();
            
        }

        public void Damage(bool firstPlayerAttacked = false, bool secondPlayerAttacked = false)
        {
            while(health > 0 || health2 > 0)
            {
                Random rand = new Random();

                if (firstPlayerAttacked == false)
                {
                    for (int i = 0; i < health; i++)
                    {
                        damage = rand.Next(5, 20);

                        health -= damage2;
                        firstPlayerAttacked = true;
                        secondPlayerAttacked = false;

                        Console.WriteLine(playerName + " attacked " + playerName2 + " and dealt " + damage + " of damage");
                        Console.WriteLine(playerName +" has" + health + " health and " + playerName2 + " has" + health2 + " health");;
                    }
                }

                if (secondPlayerAttacked == false)
                {
                    for (int i = 0; i < health;i++)
                    {
                        damage2 = rand.Next(5, 20);

                        health2 -= damage;
                        secondPlayerAttacked = true;
                        firstPlayerAttacked = false;

                        Console.WriteLine(playerName2 + " attacker " + playerName + " and dealth" + damage + " of damage");
                        Console.WriteLine(playerName + " has" + health + " health and " + playerName2 + " has" + health2 + " health");
                    }
                }
            }
        }
    }
}
