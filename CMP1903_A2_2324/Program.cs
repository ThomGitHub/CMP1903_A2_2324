using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        string player1; 
        string player2;

        while (true)
        {
            int? score;
            string? winner; 

            Console.WriteLine(@"Menu
==================
1: Sevens Out
2: Three Or More
3: Statistics
4: Testing
5: Exit
=================="); 
            string? userSelection = Console.ReadLine();

            if (userSelection == "1")
            {
                Console.WriteLine(@"Please enter player 1's name.
This should be four characters long and allows symbols, 'COMP' to play against a computer."); 
                string userInput = Console.ReadLine()!; 
                if (userInput.Length == 4)
                {
                    player1 = userInput.ToUpper();
                }
                else
                {
                    Console.WriteLine(@"An invalid name selection has been made.
Please ensure the name selected is four characters exactly, with no punctuation."); 
                    continue; 
                }

                Console.WriteLine(@"Please enter player 2's name.
This should be four characters long and allows symbols, 'COMP' to play against a computer."); 
                userInput = Console.ReadLine()!; 
                if (userInput.Length == 4)
                {
                    player2 = userInput.ToUpper();
                    SevensOut gameInstance = new();
                    (score, winner) = gameInstance.GameFunctionality(player1, player2);
                    Statistics.CalculateHighscore(score, winner, "SevensOut");
                }
                else
                {
                    Console.WriteLine(@"An invalid name selection has been made.
                    Please ensure the name selected is four characters exactly, with no punctuation."); 
                    continue; 
                }
            }
            else if (userSelection == "2")
            {
                Console.WriteLine(@"Please enter player 1's name.
This should be four characters long and allows, 'COMP' to play against a computer."); 
                string? userInput = Console.ReadLine()!; 
                if (userInput.Length == 4)
                {
                    player1 = userInput.ToUpper();
                }
                else
                {
                    Console.WriteLine(@"An invalid name selection has been made.
                    Please ensure the name selected is four characters exactly, with no punctuation."); 
                    continue; 
                }

                Console.WriteLine(@"Please enter player 2's name.
This should be four characters long and allows symbols, 'COMP' to play against a computer."); 
                userInput = Console.ReadLine()!; 
                if (userInput.Length == 4)
                {
                    player2 = userInput.ToUpper();
                    ThreeOrMore gameInstance = new();
                    (score, winner) = gameInstance.GameFunctionality(player1, player2);
                    Statistics.CalculateHighscore(score, winner, "ThreeOrMore");
                }
                else
                {
                    Console.WriteLine(@"An invalid name selection has been made.
                    Please ensure the name selected is four characters exactly, with no punctuation."); 
                    continue; 
                }
            }
            else if (userSelection == "3")
            {
                Statistics.PrintStatistics(); 
            }
            else if (userSelection == "4")
            {
                Testing.TestingMenu();
            }
            else if (userSelection == "5")
            {
                break; 
            }
            else
            {
                Console.WriteLine(@"The only valid selections are '1', '2', '3' & '4'.
Please ensure you have not used any punctuation, or selected an invalid option.");
                continue; 
            }
        }
    }
}