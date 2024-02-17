using System;

namespace TurnBasedBattle
{
    internal class Unit
    {
        private string unitName;
        private int maxHp;
        private int currentHp;
        private int attackPower;
        private int healPower;
        private Random random;

        public int Hp { get { return currentHp; } }
        public string UnitName { get { return unitName; } }
        public bool IsDead { get { return currentHp <= 0; } }

        public Unit(string unitName, int maxHp, int attackPower, int healPower)
        {
            this.unitName = unitName;
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.random = new Random();
        }

        public void Attack(Unit unitToAttack)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int randDamage = (int)(attackPower * rng);
            Console.WriteLine(unitName + " attacks " + unitToAttack.unitName + " and deals " + randDamage + " damage!");
            unitToAttack.TakeDamage(randDamage);
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            
            if(IsDead)
                Console.WriteLine(unitName + " has been defeated!");
        }

        public void Heal()
        {
            if(currentHp + healPower > maxHp)
                currentHp = maxHp;
            else
                currentHp += healPower;
            Console.WriteLine(unitName + " heals " + healPower + " HP.");
        }
    }
}
