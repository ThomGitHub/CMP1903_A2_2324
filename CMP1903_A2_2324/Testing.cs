using System.Diagnostics;

internal class Testing
{
    private static SevensOut testSevens = new();
    private static ThreeOrMore testThrees = new();
    private static Die die = new();

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
            if (userSelection == "1")
            {
                SevensOutSum(); 
            }
            else if (userSelection == "2")
            {
                SevensOutEnd();
            }
            else if (userSelection == "3")
            {
                ThreeOrMoreScoring();
            }
            else if (userSelection == "4")
            {
                ThreeOrMoreTotal();
            }
            else if (userSelection == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine(@"The only valid inputs are '1', '2', '3', '4' & '5'.
    Ensure that you have not added punctuation, and have not given an erroneous input.");
            continue;
            }
        }
    }

    private static void SevensOutSum()
    {
        List<int> rolls = []; 

        for (int i = 0; i < 2; i++)
        {
            die.Roll();
            rolls.Add(die.Value); 
        }

        Console.WriteLine("You rolled: ");
        foreach (int roll in rolls)
        {
            Console.WriteLine(roll);
        }
        Console.WriteLine("Your total is: " + rolls.Sum());
        Debug.Assert(rolls.Sum() >= 2 || rolls.Sum() <= 12, "Sum is out of bounds.");
    }

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

                if (total == 7)
                {
                    Console.WriteLine("Seven rolled. Application ending.");
                    break; 
                }

                Debug.Assert(total != 7, "Application has reached seven without ending.");
        }
    }

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

            switch (ThreeOrMore.ThreeOrMoreCheck(rolls))
            {
                case 3:
                    Console.WriteLine("Three-of-a-kind rolled. Plus three points.");
                    score += 3; 
                    break;
                default:
                    continue;
            }
            Console.WriteLine("The score is: " + score);
            Debug.Assert(score == 3, "Application has ended without reaching three.");
            break; 
        }
    }

    private static void ThreeOrMoreTotal()
    {
        int score = 0;

        while (score < 20)
        {
            List<int> rolls = [];

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
                case 4:
                    Console.WriteLine("Four-of-a-kind rolled. Plus six points.");
                    score += 6;
                    break;
                case 5:
                    Console.WriteLine("Five-of-a-kind rolled. Plus twelve points.");
                    score += 12;
                    break;
                default:
                    continue;
            }

            Console.WriteLine("The score is: " + score);
        }
        Console.WriteLine("Score has reached 20 or greater. Application ending."); 
        Debug.Assert(score >= 20, "Application has ended without reaching 20.");
    }
}