using System.Diagnostics;

internal class Testing
{
    // Instantiates objects that are used throughout the class, such as separate SevensOut and ThreeOrMore objects, plus a die object.
    private static SevensOut testSevens = new();
    private static ThreeOrMore testThrees = new();
    private static Die die = new();

    // Method that prints out a menu for the different testing options.
    public static void TestingMenu()
    {
        while (true)
        {
            Console.WriteLine(@"Testing
==================
1: Sevens Out, total sum
2: Sevens Out, stops on a 7
3: Three Or More, scores set and added correctly
4: Three Or More, ends when total >= 20
5: Exit
==================");
            string userSelection = Console.ReadLine()!; 
            if (userSelection == "1") // If the user wishes to test the total sum calculations for Sevens Out.
            {
                SevensOutSum(); 
            }
            else if (userSelection == "2") // If the user wishes to test the ending logic for Sevens Out.
            {
                SevensOutEnd();
            }
            else if (userSelection == "3") // If the user wishes to test the scoring calculations for Three Or More.
            {
                ThreeOrMoreScoring();
            }
            else if (userSelection == "4") // If the user wishes to test the ending logic for Three Or More.
            {
                ThreeOrMoreTotal();
            }
            else if (userSelection == "5") // If the user wishes to exit from the main menu.
            {
                break; // Breaks method and return to main menu.
            }
            else // If the user does not provide a valid input.
            {
                Console.WriteLine(@"The only valid inputs are '1', '2', '3', '4' & '5'.
    Ensure that you have not added punctuation, and have not given an erroneous input.");
            continue; // Resets the loop, reprints the menu and re-prompts the user.
            }
        }
    }

    // Method that replicates the logic behind SevenOuts and debugs it using Assert.
    private static void SevensOutSum()
    {
        // Initialises a list to store the rolls within.
        List<int> rolls = []; 

        // Rolls two dice using the same logic as the RollMultipleDice method from the Game class.
        for (int i = 0; i < 2; i++)
        {
            die.Roll();
            rolls.Add(die.Value); 
        }

        // Prints each of the user's roll so they can see all of them and do their own addition.
        Console.WriteLine("You rolled: ");
        foreach (int roll in rolls)
        {
            Console.WriteLine(roll); 
        }
        Console.WriteLine("Your total is: " + rolls.Sum()); // Prints the sum of the user's rolls so they can check if it's added correctly.
        Debug.Assert(rolls.Sum() >= 2 || rolls.Sum() <= 12, "Sum is out of bounds."); // Uses assert to make sure it is within the limits of 2 and 12.
    }

    // Method that replicates the logic used to end Sevens Out and checks it using Assert.
    private static void SevensOutEnd()
    {
        while (true)
        {
            List<int> rolls = [];
            int total = 0; 

                for (int i = 0; i < 2; i++)
                {
                    die.Roll();
                    rolls.Add(die.Value);
                    total += die.Value; 
                }

                Console.WriteLine("You rolled: ");
                foreach (int roll in rolls)
                {
                    Console.WriteLine(roll);
                }
                Console.WriteLine("Your total is: " + total);

                if (total == 7) // If the total of the two dice rolled is 7.
                {
                    Console.WriteLine("Seven rolled. Application ending.");
                    break; // End the application.
                }

                Debug.Assert(total != 7, "Application has reached seven without ending."); 
                // Uses Assert to ensure the application doesn't continue after reaching seven.
        }
    }

    // Method that replicates the scoring logic of Three Or More, using it's ThreeOrMoreCheck method and debug.Assert to debug.
    private static void ThreeOrMoreScoring()
    {
        while (true)
        {
            List<int> rolls = [];
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                die.Roll();
                rolls.Add(die.Value);
            }

            Console.WriteLine("You rolled: ");
            foreach (int roll in rolls)
            {
                Console.WriteLine(roll);
            }

            // Uses ThreeOrMore's ThreeOrMoreCheck method to check for the highest set within the rolls.
            switch (ThreeOrMore.ThreeOrMoreCheck(rolls))
            {
                case 3: // Only checks for three-of-a-kind.
                    Console.WriteLine("Three-of-a-kind rolled. Plus three points.");
                    score += 3; // Increases score by three for achieving three-of-a-kind.
                    break;
                default: // If the user rolls anything but three-of-a-kind.
                    continue; // Resets the loop and re-rolls the dice.
            }
            Console.WriteLine("The score is: " + score); // Prints the score to the user so they can check.
            Debug.Assert(score == 3, "Application has ended without reaching three."); 
            // Ensures that the user has scored 3 points (i.e., rolled three-of-a-kind) before the application ends.
            break; // Breaks the loop and exits the method.
        }
    }

    // Method that replicates the ending conditions of ThreeOrMore and uses debug.Assert() to ensure it ends correctly.
    private static void ThreeOrMoreTotal()
    {
        int score = 0;

        while (score < 20) // While the score is less than 20.
        {
            List<int> rolls = []; // Initialises and resets the list of rolls at the beginning of each loop.

            for (int i = 0; i < 5; i++)
            {
                die.Roll();
                rolls.Add(die.Value);
            }

            Console.WriteLine("You rolled: ");
            foreach (int roll in rolls)
            {
                Console.WriteLine(roll);
            }

            switch (ThreeOrMore.ThreeOrMoreCheck(rolls))
            {
                case 3:
                    Console.WriteLine("Three-of-a-kind rolled. Plus three points.");
                    score += 3; 
                    break;
                case 4: // If the user gets four-of-a-kind.
                    Console.WriteLine("Four-of-a-kind rolled. Plus six points.");
                    score += 6; // Adds 6 to the score.
                    break;
                case 5: // If the user gets a full set.
                    Console.WriteLine("Five-of-a-kind rolled. Plus twelve points.");
                    score += 12; // Adds 12 to the score/
                    break;
                default: // If the user gets two-of-a-kind or no matching dice.
                    continue; // Resets the loop and re-rolls all the dice.
            }

            Console.WriteLine("The score is: " + score);
        }
        Console.WriteLine("Score has reached 20 or greater. Application ending."); 
        Debug.Assert(score >= 20, "Application has ended without reaching 20.");
        // Uses Assert to make sure that the score is greater than (or equal to) 20 before the application ends.
    }
}