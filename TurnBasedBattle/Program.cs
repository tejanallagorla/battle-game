using TurnBasedBattle;

Random random = new Random();
Unit player = new Unit("Player", 100, 12, 8);
Unit enemy = new Unit("Footpad Bandit", 75, 15, 3);

Console.WriteLine("Welcome to battle-game!");
Thread.Sleep(2000);
Console.WriteLine("In this world, you're a common villager on an adventure.");
Thread.Sleep(2000);
Console.WriteLine("Fight the obstacles in your way to quench your thirst for glory.\n");
Thread.Sleep(2000);
Console.WriteLine("Your first opponent will be the " + enemy.UName + "!\n");
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

if(player.IsDead)
    Console.WriteLine("You lost :(");
else
    Console.WriteLine("You won!!!");
