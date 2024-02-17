using System.Security.Cryptography.X509Certificates;
using TurnBasedBattle;

Random random = new Random();

Unit player = new Unit("Player", 100, 12, 8);
Unit bandit = new Unit("Footpad Bandit", 80, 12, 4);
Unit mage = new Unit("Novice Mage", 100, 12, 20);
Unit hunter = new Unit("Bounty Hunter", 120, 15, 8);
Unit assassin = new Unit("Travelling Assassin", 140, 21, 16);

List<Unit> enemies = new List<Unit>();
enemies.Add(bandit);
enemies.Add(mage);
enemies.Add(hunter);
enemies.Add(assassin);

Console.WriteLine("Welcome to battle-game!");
Thread.Sleep(2000);
Console.WriteLine("In this world, you're a common villager on an adventure.");
Thread.Sleep(2000);
Console.WriteLine("Fight the obstacles in your way to quench your thirst for glory.\n");
Thread.Sleep(2000);

for(int e = 0; e < enemies.Count; e++)
{
    if(!player.IsDead)
    {
        Unit enemy = enemies[e];
        if(e == 0)
            Console.WriteLine("Your first opponent will be the " + enemy.UName + "!\n");
        else if(e < enemies.Count - 1)
        {
            Console.WriteLine("\nYour next opponent will be the " + enemy.UName + "!\n");
            Thread.Sleep(2000);
            Console.WriteLine("Before fighting your next opponent, would you like to upgrade hp, attacking, or healing?");
            string upgrade = Console.ReadLine();

            Console.WriteLine();

            if(upgrade == "hp")
                player.UpgradeMaxHp();
            else if(upgrade == "attacking")
                player.UpgradeAttackPower();
            else if(upgrade == "healing")
                player.UpgradeHealPower();
            else
            {
                bool validUpgrade = false;
                while(!validUpgrade)
                {
                    Console.WriteLine("Please enter either 'hp', 'attacking', or 'healing'. What would you like to upgrade?");
                    upgrade = Console.ReadLine();
                    Console.WriteLine();
                    if(upgrade == "hp" || upgrade == "attacking" || upgrade == "healing")
                        validUpgrade = true;
                }

                if(upgrade == "hp")
                    player.UpgradeMaxHp();
                else if(upgrade == "attacking")
                    player.UpgradeAttackPower();
                else
                    player.UpgradeHealPower();
            }

            player.FullHeal();
        }
        else
        {
            Console.WriteLine("\nYour last opponent will be the " + enemy.UName + "!\n");
            Thread.Sleep(2000);
            Console.WriteLine("Before fighting your final opponent you will get two upgrades.");
            Console.WriteLine("What would you like to upgrade first? hp, attacking, or healing?");
            string upgrade1 = Console.ReadLine();

            Console.WriteLine();

            if(upgrade1 == "hp")
                player.UpgradeMaxHp();
            else if(upgrade1 == "attacking")
                player.UpgradeAttackPower();
            else if(upgrade1 == "healing")
                player.UpgradeHealPower();
            else
            {
                bool validUpgrade = false;
                while(!validUpgrade)
                {
                    Console.WriteLine("Please enter either 'hp', 'attacking', or 'healing'. What would you like to upgrade?");
                    upgrade1 = Console.ReadLine();
                    Console.WriteLine();
                    if(upgrade1 == "hp" || upgrade1 == "attacking" || upgrade1 == "healing")
                        validUpgrade = true;
                }

                if(upgrade1 == "hp")
                    player.UpgradeMaxHp();
                else if(upgrade1 == "attacking")
                    player.UpgradeAttackPower();
                else
                    player.UpgradeHealPower();
            }

            Console.WriteLine("What would you like to upgrade next? hp, attacking, or healing?");
            string upgrade2 = Console.ReadLine();

            Console.WriteLine();

            if(upgrade2 == "hp")
                player.UpgradeMaxHp();
            else if(upgrade2 == "attacking")
                player.UpgradeAttackPower();
            else if(upgrade2 == "healing")
                player.UpgradeHealPower();
            else
            {
                bool validUpgrade = false;
                while(!validUpgrade)
                {
                    Console.WriteLine("Please enter either 'hp', 'attacking', or 'healing'. What would you like to upgrade?");
                    upgrade2 = Console.ReadLine();
                    Console.WriteLine();
                    if(upgrade2 == "hp" || upgrade2 == "attacking" || upgrade2 == "healing")
                        validUpgrade = true;
                }

                if(upgrade2 == "hp")
                    player.UpgradeMaxHp();
                else if(upgrade2 == "attacking")
                    player.UpgradeAttackPower();
                else
                    player.UpgradeHealPower();
            }

            player.FullHeal();
        }
        Thread.Sleep(2000);

        while(!player.IsDead && !enemy.IsDead)
        {
            Console.WriteLine(player.UName + " HP = " + player.CurHp + ".");
            Console.WriteLine(enemy.UName + " HP = " + enemy.CurHp + ".");
            Console.WriteLine(player.UName + "'s turn! Will you attack or heal?");
            string choice = Console.ReadLine();

            Console.WriteLine();

            if(choice == "attack")
                player.Attack(enemy);
            else if(choice == "heal")
                player.Heal();
            else
            {
                bool validTurn = false;
                while(!validTurn)
                {
                    Console.WriteLine("That move is invalid! Please enter either 'attack' or 'heal'. What would you like to do?");
                    choice = Console.ReadLine();
                    Console.WriteLine();
                    if(choice == "attack" || choice == "heal")
                        validTurn = true;
                }

                if(choice == "attack")
                    player.Attack(enemy);
                else if(choice == "heal")
                    player.Heal();
            }

            if(!enemy.IsDead)
            {
                Console.WriteLine();

                Console.WriteLine(player.UName + " HP = " + player.CurHp + ".");
                Console.WriteLine(enemy.UName + " HP = " + enemy.CurHp + ".");
                Console.WriteLine("Waiting for " + enemy.UName + " to make a move...");
                Thread.Sleep(3000);

                Console.WriteLine();

                int rand = random.Next(0, 3);

                if (rand == 0 || rand == 1 || enemy.CurHp == enemy.MaxHp)
                    enemy.Attack(player);
                else
                    enemy.Heal();
                
                Console.WriteLine();
            }
        }
    }
}

if(player.IsDead)
    Console.WriteLine("\nYou lost :(");
else
    Console.WriteLine("\nYou won!!!");
