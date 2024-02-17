using TurnBasedBattle;

Random random = new Random();
Unit player = new Unit("Player", 100, 12, 8);
Unit enemy = new Unit("Enemy Bandit", 75, 15, 3);



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

if(player.IsDead)
    Console.WriteLine("You lost :(");
else
    Console.WriteLine("You won!!!");
