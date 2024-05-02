using System.Data.Common;
using System.Runtime.CompilerServices;

internal class Statistics
{
    private static int _sevensOutHighScore;
    public static int SevensOutHighscore
    {
        get { return _sevensOutHighScore; }
        set { _sevensOutHighScore = value; }
    }

    private static int _threeOrMoreHighscore;
    public static int ThreeOrMoreHighscore
    {
        get { return _threeOrMoreHighscore; }
        set { _threeOrMoreHighscore = value; }
    }

    private static string? _threeOrMoreHighscorer;
    public static string? ThreeOrMoreHighscorer
    {
        get { return _threeOrMoreHighscorer; }
        set { _threeOrMoreHighscorer = value; }
    }
    
    private static string? _sevensOutHighscorer;
    public static string? SevensOutHighscorer
    {
        get { return _sevensOutHighscorer; }
        set { _sevensOutHighscorer = value; } 
    }

    public static void PrintStatistics()
    {
        Console.WriteLine(@$"Statistics
==================
Seven's Out Highscore: {SevensOutHighscore}, by {SevensOutHighscorer}
Three or More Highscore: {ThreeOrMoreHighscore}, by {ThreeOrMoreHighscorer}
No. of Seven's Out Games Played: {Game.SevensOutPlayed}
No. of Three Or More Games Played: {Game.ThreeOrMorePlayed}
No. of Full Sets Scored: {Game.FiveOfAKindsScored}
==================
Press enter to return to the main menu
==================");  
        
    Console.ReadLine();
    }

    public static void CalculateHighscore(int? score, string? winner, string game)
    {
        int? highScore = 0;
        string? highScorer = null; 

        switch (game)
        {
            case "SevensOut":
                highScore = SevensOutHighscore;
                highScorer = SevensOutHighscorer;
                break;
            case "ThreeOrMore":
                highScore = ThreeOrMoreHighscore; 
                highScorer = ThreeOrMoreHighscorer;
                break;
        }

        if (score > highScore)
        {
            highScore = score;
            highScorer = winner;
        }

        switch (game)
        {
            case "SevensOut":
                SevensOutHighscore = (int)highScore;
                SevensOutHighscorer = highScorer;
                break;
            case "ThreeOrMore":
                ThreeOrMoreHighscore = (int)highScore;
                ThreeOrMoreHighscorer = highScorer;
                break;
        }
    }
}
