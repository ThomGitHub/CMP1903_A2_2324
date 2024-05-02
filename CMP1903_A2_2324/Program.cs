internal class Program
{
    private static void Main(string[] args)
    {
        Game instanceGame = new();
        string player1; 
        string player2;

        while (true)
        {
            int? score = 0;
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
                string? userInput = Console.ReadLine(); 
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
                userInput = Console.ReadLine(); 
                if (userInput.Length == 4)
                {
                    player2 = userInput.ToUpper();
                    (score, winner) = instanceGame.ThreeOrMore(player1, player2);
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
                string? userInput = Console.ReadLine(); 
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
                userInput = Console.ReadLine(); 
                if (userInput.Length == 4)
                {
                    player2 = userInput.ToUpper();
                    (score, winner) = instanceGame.ThreeOrMore(player1, player2);
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
                break;
            }
            else if (userSelection == "4")
            {
                break;
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