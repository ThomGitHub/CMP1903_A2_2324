using System.Collections;
using System.Net;

abstract class Game
{
    private static int _sevensOutPlayed;
    public static int SevensOutPlayed
    {
        get { return _sevensOutPlayed; }
        set { _sevensOutPlayed = value; } 
    }

    private static int _threeOrMorePlayed;
    public static int ThreeOrMorePlayed
    {
        get { return _threeOrMorePlayed; }
        set { _threeOrMorePlayed = value; } 
    }

    private static int _fiveOfAKindsScored;
    public static int FiveOfAKindsScored
    {
        get { return _fiveOfAKindsScored; }
        set { _fiveOfAKindsScored = value; }
    }


    virtual protected List<int> RollMultipleDice(int numberOfDice)
    {
        Die die = new(); 
        List<int> rolls = []; 

        for (int i = 0; i < numberOfDice; i++)
        {
            die.Roll();
            rolls.Add(die.Value); 
        }

        return rolls; 
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
                    List<int> rolls = RollMultipleDice(2); 
                    int total = rolls.Sum(); 
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
                        rolls = RollMultipleDice(2); 
                        total = rolls.Sum(); 
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
                    List<int> rolls = RollMultipleDice(2); 
                    int total = rolls.Sum(); 
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
                        rolls = RollMultipleDice(2); 
                        total = rolls.Sum(); 
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

        Console.WriteLine(@"You have chosen to play Three Or More!
Each player rolls five dice, looking for three of a kind or more, scoring points as they go.");

        while (player1Score < 20 && player2Score < 20)
        {
            List<int> rolls = [];
            bool threeOrMoreAchieved = false;


            if (turnCounter / 2.0 == 0)
            {
                Console.WriteLine($"It is {player1}'s turn!"); 
                switch (player1)
                {
                    case "COMP":
                        rolls = RollMultipleDice(5); 
                        
                        while (threeOrMoreAchieved == false)
                        {
                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine(@"The computer rolled 2-of-a-kind! Re-rolling the non-matching dice."); 
                                    List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                    List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                    List<int> newRolls = RollMultipleDice(nonMatchingDice.Count); 

                                    foreach (int nonMatchingDie in nonMatchingDice)
                                    {
                                        rolls.RemoveAll(x => x == nonMatchingDie);
                                    }
                                    rolls.AddRange(newRolls);
                                    break;
                                case 3:
                                    Console.WriteLine("The computer rolled three-of-a-kind! Plus three points."); 
                                    player1Score += 3;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                case 4:
                                    Console.WriteLine("The computer rolled four-of-a-kind! Plus six points."); 
                                    player1Score += 6;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    break;
                                case 5:
                                    Console.WriteLine("The computer rolled a full set! Plus twelve points."); 
                                    player1Score += 12;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++;
                                    FiveOfAKindsScored++; 
                                    break;
                                default:
                                    Console.WriteLine("The computer rolled no matching dice. Re-rolling all dice."); 
                                    rolls = RollMultipleDice(5); 
                                    break;
                            }
                        }
                        break; 
                    default: 
                        Console.WriteLine("Continue? R to roll the dice, E to exit.");
                        string? userInput = Console.ReadLine();
                        if (userInput == "R")
                        {
                            rolls = RollMultipleDice(5); 
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
                        while (threeOrMoreAchieved == false)
                        {
                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine("You rolled 2-of-a-kind; press 1 to re-roll non-matching die, press 2 to re-roll all."); 
                                    string? userSelection = Console.ReadLine();
                                    if (userSelection == "1")
                                    {
                                        List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                        List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                        List<int> newRolls = RollMultipleDice(nonMatchingDice.Count); 

                                        foreach (int nonMatchingDie in nonMatchingDice)
                                        {
                                            rolls.RemoveAll(x => x == nonMatchingDie);
                                        }

                                        rolls.AddRange(newRolls);
                                    }
                                    else if (userSelection == "2")
                                    {
                                        rolls = RollMultipleDice(5); 
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid selection or no selection. Skipping turn.");
                                        turnCounter++;
                                    }
                                    break; 
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
                                    Console.WriteLine("Full set! Plus twelve points."); 
                                    player1Score += 12;
                                    threeOrMoreAchieved = true; 
                                    turnCounter++; 
                                    FiveOfAKindsScored++;
                                    break;
                                default:
                                    Console.WriteLine("No matching dice. Re-rolling all dice."); 
                                    rolls = RollMultipleDice(5); 
                                    break;
                            }
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
                        rolls = RollMultipleDice(5); 
                        while (threeOrMoreAchieved == false)
                        {
                            switch (ThreeOrMoreCheck(rolls))
                            {
                                case 2:
                                    Console.WriteLine("The computer rolled 2-of-a-kind; re-rolling non-matching dice.");  
                                    List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                    List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                    List<int> newRolls = RollMultipleDice(nonMatchingDice.Count); 

                                    foreach (int nonMatchingDie in nonMatchingDice)
                                    {
                                        rolls.RemoveAll(x => x == nonMatchingDie);
                                    }
                                    rolls.AddRange(newRolls);
                                    break; 
                                case 3:
                                    Console.WriteLine("The computer rolled three-of-a-kind! Plus three points."); 
                                    player2Score += 3;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                case 4:
                                    Console.WriteLine("The computer rolled four-of-a-kind! Plus six points."); 
                                    player2Score += 6;
                                    threeOrMoreAchieved = true; 
                                    turnCounter--; 
                                    break;
                                case 5:
                                    Console.WriteLine("The computer rolled a full set! Plus twelve points.");
                                    player2Score += 12;
                                    threeOrMoreAchieved = true; 
                                    FiveOfAKindsScored++;
                                    turnCounter--; 
                                    break;
                                default:
                                    Console.WriteLine("The computer rolled no matching dice. Re-rolling all dice."); 
                                    rolls = RollMultipleDice(5); 
                                    break;
                            }
                        }
                        break;   
                    default:
                        Console.WriteLine("Continue? R to roll the dice, E to exit.");
                        string? userInput = Console.ReadLine();
                        if (userInput == "R")
                        {
                            rolls = RollMultipleDice(5); 
                        }
                        else if (userInput == "E")
                        {
                            return (null, null);
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection! The options are 'R' and 'E'."); 
                            break; 
                        }

                    while (threeOrMoreAchieved == false)
                    {
                        switch (ThreeOrMoreCheck(rolls))
                        {
                            case 2:
                                Console.WriteLine("You rolled 2-of-a-kind; press 1 to re-roll non-matching die, press 2 to re-roll all."); 
                                string? userSelection = Console.ReadLine();
                                if (userSelection == "1")
                                {
                                    List<int> nonMatchingDice = rolls.GroupBy(x => x).Where(g => g.Count() < 2).SelectMany(g => g).ToList();
                                    List<int> matchingDice = rolls.GroupBy(x => x).Where(g => g.Count() >= 2).SelectMany(g => g).ToList();

                                    List<int> newRolls = RollMultipleDice(nonMatchingDice.Count); 

                                    foreach (int nonMatchingDie in nonMatchingDice)
                                    {
                                        rolls.RemoveAll(x => x == nonMatchingDie);
                                    }
                                    rolls.AddRange(newRolls);
                                }
                                else if (userSelection == "2")
                                {
                                    rolls = RollMultipleDice(5); 
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection or no selection. Skipping turn.");
                                    turnCounter--;
                                }
                                break; 
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
                                Console.WriteLine("Full set! Plus 12 points."); 
                                player2Score += 12;
                                threeOrMoreAchieved = true; 
                                turnCounter--;
                                FiveOfAKindsScored++;
                                break;
                            default:
                                Console.WriteLine("No matching dice. Re-rolling all dice."); 
                                rolls = RollMultipleDice(5); 
                                break;
                        }
                    }
                    break;
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