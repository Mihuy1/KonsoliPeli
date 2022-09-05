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

            damage = random.Next(1, 25);
            damage2 = random.Next(1, 25);

            health = random.Next(25, 100);
            health2 = random.Next(25, 100);

            Console.WriteLine(playerName + " has " + health + " of health and " + damage + " of damage");
            Console.WriteLine(playerName2 + " has" + health2 + " of health and " + damage + " of damage");

            Console.WriteLine("Battle begins! " + playerName + " against " + playerName2);
            
        }

        public void Damage(bool firstPlayerAttacked = false, bool secondPlayerAttacked = false)
        {
            while(health > 0 || health2 > 0)
            {
                if (firstPlayerAttacked == false)
                {
                    for (int i = 0; i < health; i++)
                    {
                        health -= damage2;
                        firstPlayerAttacked = true;
                        secondPlayerAttacked = false;

                    }
                }

                if (secondPlayerAttacked == false)
                {
                    for (int i = 0; i < health;i++)
                    {
                        health2 -= damage;
                        secondPlayerAttacked = true;
                        firstPlayerAttacked = false;
                    }
                }
            }
        }
    }
}
