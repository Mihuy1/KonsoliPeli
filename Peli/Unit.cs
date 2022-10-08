namespace Peli
{
    public class Unit
    {

        public string name;
        public int dmg;
        public int hp;
        public int id;
        public int maxHealth;

        public Unit(string name, int dmg, int health, int maxHealth, int id)
        {
            this.name = name;
            this.dmg = dmg;
            this.hp = health;
            this.maxHealth = maxHealth;
            this.id = id;
        }
    }
}

   