using System.Collections;
using System.Net;

abstract class Game
{
    private int _sevensOutPlayed;
    public int SevensOutPlayed
    {
        get { return _sevensOutPlayed; }
        set { _sevensOutPlayed = value; } 
    }

    private int _threeOrMorePlayed;
    public int ThreeOrMorePlayed
    {
        get { return _threeOrMorePlayed; }
        set { _threeOrMorePlayed = value; } 
    }

    private int _fiveOfAKindsScored;
    public int FiveOfAKindsScored
    {
        get { return _fiveOfAKindsScored; }
        set { _fiveOfAKindsScored = value; }
    }

    public abstract (int? score, string? winner) GameFunctionality(string player1, string player2);
} 

internal class SevensOut : Game
{
    public override (int? score, string? winner) GameFunctionality(string player1, string player2)
    {
        int turnCounter = 0;
        List<int> player1Total = [];
        List<int> player2Total = []; 
        Die die1 = new();
        Die die2 = new(); 

        Console.WriteLine(@"You have chosen to play Seven's Out!
Each player rolls two dice, adding up their totals, until one rolls seven."); 

    while (true)
    {
        if (turnCounter / 2.0 == 0)
        {
            Console.WriteLine($"\nIt is {player1}'s turn!");
            switch (player1)
            {
                case "COMP":
                    die1.Roll(); 
                    die2.Roll();
                    int total = die1.Value + die2.Value;
                    switch (total)
                    {
                        case 7:
                            Console.WriteLine($"A 7! Game over.");
                            int player1Score = player1Total.Sum();
                            int player2Score = player2Total.Sum();
                            if (player1Score > player2Score)
                            {
                                Console.WriteLine($"{player1} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1; 
                                return (player1Score, player1);
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1; 
                                return (player2Score, player2);
                            }
                        default:
                            Console.WriteLine($"The computer rolled a {total}.");
                            player1Total.Add(total); 
                            break;
                    }
                    turnCounter++;
                    break; 
                default: 
                    Console.WriteLine("Enter 'R' to roll, or 'E' to exit.");
                    string? userInput = Console.ReadLine(); 
                    if (userInput == "R")
                    {
                        die1.Roll(); 
                        die2.Roll();
                        total = die1.Value + die2.Value;
                        switch (total)
                        {
                        case 7:
                            Console.WriteLine($"A 7! Game over.");
                            int player1Score = player1Total.Sum();
                            int player2Score = player2Total.Sum();
                            if (player1Score > player2Score)
                            {
                                Console.WriteLine($"{player1} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1; 
                                return (player1Score, player1);
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1; 
                                return (player2Score, player2);
                            }
                        default:
                            Console.WriteLine($"{player1} rolled a {total}.");
                            player1Total.Add(total); 
                            break;
                        }
                        turnCounter++;
                    }
                    else if (userInput == "E")
                    {
                        return (null, null); 
                    }
                    else
                    {
                        Console.WriteLine("The only valid options are 'R' or 'E'.");
                        continue;
                    }
                break;  
            }
        }
        else
        {
            Console.WriteLine($"\nIt is {player2}'s turn!"); 
            switch (player2)
            {
                case "COMP":
                    die1.Roll(); 
                    die2.Roll();
                    int total = die1.Value + die2.Value;
                    switch (total)
                    {
                        case 7:
                            Console.WriteLine($"A 7! Game over.");
                            int player1Score = player1Total.Sum();
                            int player2Score = player2Total.Sum();
                            if (player1Score > player2Score)
                            {
                                Console.WriteLine($"{player1} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1;
                                return (player1Score, player1);
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed +=1 ; 
                                return (player2Score, player2);
                            }
                        default:
                            Console.WriteLine($"The computer rolled a {total}.");
                            player2Total.Add(total); 
                            break;
                    }
                    turnCounter--; 
                    break; 
                default: 
                    Console.WriteLine("Enter 'R' to roll, or 'E' to exit.");
                    string? userInput = Console.ReadLine(); 
                    if (userInput == "R")
                    {
                        die1.Roll(); 
                        die2.Roll();
                        total = die1.Value + die2.Value;
                        switch (total)
                    {
                        case 7:
                            Console.WriteLine($"A 7! Game over.");
                            int player1Score = player1Total.Sum();
                            int player2Score = player2Total.Sum();
                            if (player1Score > player2Score)
                            {
                                Console.WriteLine($"{player1} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1;
                                return (player1Score, player1); 
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                SevensOutPlayed += 1;
                                return (player2Score, player2);
                            }
                        default:
                            Console.WriteLine($"{player2} rolled a {total}.");
                            player2Total.Add(total); 
                            break;
                    }
                        turnCounter--; 
                    }
                    else if (userInput == "E")
                    {
                        return (null, null);
                    }
                    else
                    {
                        Console.WriteLine("The only valid options are 'R' or 'E'.");
                        continue;
                    }
                    break;  
                }
            }
        }
    }
}

internal class ThreeOrMore : Game
{
    public override (int? score, string? winner) GameFunctionality(string player1, string player2)
    {
        int turnCounter = 0;
        int player1Score = 0; 
        int player2Score = 0; 
        List<int> rolls = []; 
        Die die = new(); 

        Console.WriteLine(@"You have chosen to play Three Or More!
Each player rolls five dice, looking for three of a kind or more, scoring points as they go.");

        while (player1Score < 20 && player2Score < 20)
        {
            rolls = [];
            bool threeOrMoreAchieved = false;

            while (threeOrMoreAchieved == false)
            {
                if (turnCounter / 2.0 == 0)
                {
                    Console.WriteLine($"It is {player1}'s turn!"); 
                    switch (player1)
                    {
                        case "COMP":
                            for (int i = 0; i < 5; i++)
                            {
                                die.Roll();
                                rolls.Add(die.Value);
                            }

                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine("2-1"); 
                                    List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                    List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                    if (matchingDice.Count >= 2)
                                    {
                                        rolls.RemoveAll(x => matchingDice.Contains(x));
                                        for (int i = 0; i < 2; i++)
                                        {
                                            die.Roll();
                                            rolls.Add(die.Value);
                                        }
                                    }

                                    List<int> newRolls = [];
                                    for (int i = 0; i < nonMatchingDice.Count; i++)
                                    {
                                        die.Roll();
                                        newRolls.Add(die.Value);
                                    }

                                    rolls.RemoveAll(x => nonMatchingDice.Contains(x));
                                    rolls.AddRange(newRolls);
                                    continue; 
                                case 3:
                                    Console.WriteLine("3-1"); 
                                    player1Score += 3;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                case 4:
                                    Console.WriteLine("4-1"); 
                                    player1Score += 6;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                case 5:
                                    Console.WriteLine("5-1"); 
                                    player1Score += 12;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                default:
                                    Console.WriteLine("1-1"); 
                                    for (int i = 0; i < 5; i++)
                                    {
                                        die.Roll();
                                        rolls.Add(die.Value);
                                    }
                                    continue;
                            }
                            break; 
                        default: 
                            Console.WriteLine("Continue? R to roll the dice, E to exit.");
                            string? userInput = Console.ReadLine();
                            if (userInput == "R")
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    die.Roll();
                                    rolls.Add(die.Value);
                                }
                            }
                            else if (userInput == "E")
                            {
                                return (null, null);
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection! The options are 'R' and 'E'."); 
                                continue; 
                            }

                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine(@"
                                    You have rolled 2-of-a-kind; press 1 to re-roll non-matching die, press 2 to re-roll all."); 
                                    string? userSelection = Console.ReadLine();
                                    if (userSelection == "1")
                                    {
                                        List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                        List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                        if (matchingDice.Count >= 2)
                                        {
                                            rolls.RemoveAll(x => matchingDice.Contains(x));
                                            for (int i = 0; i < 2; i++)
                                            {
                                                die.Roll();
                                                rolls.Add(die.Value);
                                            }
                                        }

                                        List<int> newRolls = [];
                                        for (int i = 0; i < nonMatchingDice.Count; i++)
                                        {
                                            die.Roll();
                                            newRolls.Add(die.Value);
                                        }

                                        rolls.RemoveAll(x => nonMatchingDice.Contains(x));
                                        rolls.AddRange(newRolls);
                                    }
                                    else if (userSelection == "2")
                                    {
                                        for (int i = 0; i < 5; i++)
                                        {
                                        die.Roll();
                                        rolls.Add(die.Value);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid selection or no. Skipping turn.");
                                        turnCounter++;
                                    }
                                    continue; 
                                case 3:
                                    Console.WriteLine("You rolled three of a kind! Plus three points."); 
                                    player1Score += 3;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                case 4:
                                    Console.WriteLine("You rolled four-of-a-kind! Plus six points."); 
                                    player1Score += 6;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                case 5:
                                    Console.WriteLine("Full house! Plus twelve points."); 
                                    player1Score += 12;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    FiveOfAKindsScored += 1;
                                    break;
                                default:
                                    Console.WriteLine("One-of-a-kind. Re-rolling all dice."); 
                                    for (int i = 0; i < 5; i++)
                                    {
                                        die.Roll();
                                        rolls.Add(die.Value);
                                    }
                                    continue;
                            }
                            break; 
                    }
                }
                else
                {
                    Console.WriteLine($"It is {player2}'s turn!"); 
                    switch (player2)
                    {
                        case "COMP": 
                        for (int i = 0; i < 5; i++)
                            {
                                die.Roll();
                                rolls.Add(die.Value);
                            }

                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine(@"
                                    You have rolled 2-of-a-kind; press 1 to re-roll non-matching die, press 2 to re-roll all.");  
                                    List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                    List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                    if (matchingDice.Count >= 2)
                                    {
                                        rolls.RemoveAll(x => matchingDice.Contains(x));
                                        for (int i = 0; i < 2; i++)
                                        {
                                            die.Roll();
                                            rolls.Add(die.Value);
                                        }
                                    }

                                    List<int> newRolls = [];
                                    for (int i = 0; i < nonMatchingDice.Count; i++)
                                    {
                                        die.Roll();
                                        newRolls.Add(die.Value);
                                    }

                                    rolls.RemoveAll(x => nonMatchingDice.Contains(x));
                                    rolls.AddRange(newRolls);
                                    continue; 
                                case 3:
                                    Console.WriteLine("You rolled three-of-a-kind! Plus three points."); 
                                    player2Score += 3;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                case 4:
                                    Console.WriteLine("You rolled four-of-a-kind! Plus six points."); 
                                    player2Score += 6;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                case 5:
                                    Console.WriteLine("Full house! Plus twelve points.");
                                    player2Score += 12;
                                    threeOrMoreAchieved = true; 
                                    FiveOfAKindsScored += 1;
                                    turnCounter--; 
                                    break;
                                default:
                                    Console.WriteLine("One-of-a-kind! Re-rolling all dice."); 
                                    for (int i = 0; i < 5; i++)
                                    {
                                        die.Roll();
                                        rolls.Add(die.Value);
                                    }
                                    continue;
                            }
                            break;   
                        default:
                            Console.WriteLine("Continue? R to roll the dice, E to exit.");
                            string? userInput = Console.ReadLine();
                            if (userInput == "R")
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    die.Roll();
                                    rolls.Add(die.Value);
                                }
                            }
                            else if (userInput == "E")
                            {
                                return (null, null);
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection! The options are 'R' and 'E'."); 
                                continue; 
                            }

                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine(@"You have rolled 2-of-a-kind; 
press 1 to re-roll non-matching die, press 2 to re-roll all."); 
                                    string? userSelection = Console.ReadLine();
                                    if (userSelection == "1")
                                    {
                                        List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                        List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                        if (matchingDice.Count >= 2)
                                        {
                                            rolls.RemoveAll(x => matchingDice.Contains(x));
                                            for (int i = 0; i < 2; i++)
                                            {
                                                die.Roll();
                                                rolls.Add(die.Value);
                                            }
                                        }

                                        List<int> newRolls = [];
                                        for (int i = 0; i < nonMatchingDice.Count; i++)
                                        {
                                            die.Roll();
                                            newRolls.Add(die.Value);
                                        }

                                        rolls.RemoveAll(x => nonMatchingDice.Contains(x));
                                        rolls.AddRange(newRolls);
                                    }
                                    else if (userSelection == "2")
                                    {
                                        for (int i = 0; i < 5; i++)
                                        {
                                        die.Roll();
                                        rolls.Add(die.Value);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid selection or no. Skipping turn.");
                                        turnCounter--;
                                    }
                                    continue; 
                                case 3:
                                    Console.WriteLine("3-2"); 
                                    player2Score += 3;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                case 4:
                                    Console.WriteLine("4-2"); 
                                    player2Score += 6;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                case 5:
                                    Console.WriteLine("5-2"); 
                                    player2Score += 12;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                default:
                                    Console.WriteLine("1-2"); 
                                    for (int i = 0; i < 5; i++)
                                    {
                                        die.Roll();
                                        rolls.Add(die.Value);
                                    }
                                    continue;
                            }
                            break;
                        }
                    }
                }
            }

        if (player1Score > player2Score)
        {
            Console.WriteLine($"{player1} wins! {player1Score}-{player2Score}.");
            ThreeOrMorePlayed += 1;
            return (player1Score, player1);
        }
        else if (player2Score > player1Score)
        {
            Console.WriteLine($"{player2} wins! {player1Score}-{player2Score}.");
            ThreeOrMorePlayed += 1;
            return (player2Score, player2);
            
        }
        else
        {
            Console.WriteLine($"A draw! {player1Score}-{player2Score}.");
            return (null, null); 
        }
    }

    private int ThreeOrMoreCheck(List<int> rolls)
    {
        List<int> setsRolled = [];
        int setRolled; 

        foreach (int roll in rolls)
        {
            setRolled = rolls.Count(x => x == roll);
            setsRolled.Add(setRolled); 
        }

        int highestSet = setsRolled[0]; 

        foreach (int set in setsRolled)
        {
            if (set > highestSet)
            {
                highestSet = set;
            }
        }

        return highestSet; 
    }
}