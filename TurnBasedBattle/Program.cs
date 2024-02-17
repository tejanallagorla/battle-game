using TurnBasedBattle;

Random random = new Random();
Unit player = new Unit("Player", 100, 15, 8);
Unit enemy = new Unit("Enemy Bandit", 75, 12, 6);

while(!player.IsDead && !enemy.IsDead)
{
    Console.WriteLine(player.UName + " HP = " + player.CurHp + ".");
    Console.WriteLine(enemy.UName + " HP = " + enemy.CurHp + ".");
    Console.WriteLine(player.UName + "'s turn! Will you attack or heal?");
    string choice = Console.ReadLine();

    Console.WriteLine("\n");

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
        Console.WriteLine("\n");

        Console.WriteLine(player.UName + " HP = " + player.CurHp + ".");
        Console.WriteLine(enemy.UName + " HP = " + enemy.CurHp + ".");
        Console.WriteLine("Waiting for " + enemy.UName + " to make a move...");
        Thread.Sleep(3000);

        Console.WriteLine("\n");

        int rand = random.Next(0, 2);

        if (rand == 0 || enemy.CurHp == enemy.MaxHp)
            enemy.Attack(player);
        else
            enemy.Heal();
    }
}
