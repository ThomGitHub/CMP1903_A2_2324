using System.Collections;
using System.Net;

internal class Game
{
    public int SevensOut(string player1, string player2)
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
                                return player1Score;
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                return player2Score;
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
                                return player1Score;
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                return player2Score;
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
                        return 0; 
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
                                return player1Score;
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                return player2Score;
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
                                return player1Score;
                            }
                            else
                            {
                                Console.WriteLine($"{player2} is the winner; {player1Score}-{player2Score}.");
                                return player2Score;
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
                        return 0;
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

    public int ThreeOrMore(string player1, string player2)
    {
        int turnCounter = 0;
        int player1Score = 0; 
        int player2Score = 0; 
        List<int> rolls = []; 
        Die die = new(); 

        while (player1Score >= 20 || player2Score >= 20)
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
                        break; 
                    default: 
                        break; 
                }
            }
            else
            {
                Console.WriteLine($"It is {player2}'s turn!"); 
                switch (player2)
                {
                    case "COMP":
                        break; 
                    default:
                        break; 
                }
            }
        }

        if (player1Score > player2Score)
        {
            Console.WriteLine($"{player1} wins! {player1Score}-{player2Score}.");
            return player1Score;
        }
        else if (player2Score > player1Score)
        {
            Console.WriteLine($"{player2} wins! {player1Score}-{player2Score}.");
            return player2Score;
        }
        else
        {
            Console.WriteLine($"A draw! {player1Score}-{player2Score}.");
            return 0; 
        }
    }
}