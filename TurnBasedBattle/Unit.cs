using System;
using System.Threading;

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

        public string UName { get { return unitName; } }
        public int CurHp { get { return currentHp; } }
        public int MaxHp { get { return maxHp; } }
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
            int rng = random.Next(0, 5);
            int newDamage = attackPower;
            if(rng == 2)
            {
                int critBonus = random.Next(3, 6);
                newDamage += critBonus;
                Console.WriteLine(unitName + " lands a critical hit on " + unitToAttack.unitName + "! The attack deals " + newDamage + " damage!");
            }
            else
                Console.WriteLine(unitName + " attacks " + unitToAttack.unitName + " and deals " + newDamage + " damage!");
            unitToAttack.TakeDamage(newDamage);
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            
            if(IsDead)
                Console.WriteLine("\n" + unitName + " has been defeated!");
        }

        public void Heal()
        {
            if(currentHp + healPower > maxHp)
                currentHp = maxHp;
            else
                currentHp += healPower;
            Console.WriteLine(unitName + " heals " + healPower + " HP.");
        }

        public void UpgradeMaxHp()
        {
            maxHp += 25;
            Console.WriteLine(unitName + "'s max HP has been increased by 25!");
        }

        public void UpgradeAttackPower()
        {
            attackPower += 3;
            Console.WriteLine(unitName + "'s attack power has been increased by 3!");
        }

        public void UpgradeHealPower()
        {
            healPower += 4;
            Console.WriteLine(unitName + "'s heal power has been increased by 4!");
        }

        public void FullHeal()
        {
            currentHp = maxHp;
            Console.WriteLine(unitName + "'s HP has been fully restored!\n");
        }
    }
}
