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
        public int damage;
        public int health;

        public Unit(string playerName, int damage, int health)
        {
            this.playerName = playerName;
            this.damage = damage;
            this.health = health;
        }
    }
}
