using TurnBasedBattle;

Random random = new Random();
Unit player = new Unit("Player", 100, 15, 8);
Unit enemy = new Unit("Enemy Bandit", 75, 10, 5);

while(!player.IsDead && !enemy.IsDead)
{
    Console.WriteLine(player.UnitName + " HP = " + player.Hp + ".");
    Console.WriteLine(enemy.UnitName + " HP = " + enemy.Hp + ".");
    Console.WriteLine(player.UnitName + "'s turn! What will you do?");
    string choice = Console.ReadLine();

    if(choice == "attack")
        player.Attack(enemy);
    else
        player.Heal();

    if(!enemy.IsDead)
    {
        Console.WriteLine(player.UnitName + " HP = " + player.Hp + ".");
        Console.WriteLine(enemy.UnitName + " HP = " + enemy.Hp + ".");

        Console.WriteLine(enemy.UnitName + "'s turn!");

        int rand = random.Next(0, 2);

        if (rand == 0)
            enemy.Attack(player);
        else
            enemy.Heal();
    }
}
