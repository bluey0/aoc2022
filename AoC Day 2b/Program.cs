using System;
using System.IO;

class AoC_Day2a
{
    private static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Only accepting 1 argument that is the input file. Exiting...");
            return;
        }

        string[] lines = File.ReadAllLines(args[0]);

        int total_score = 0;

        foreach (string line in lines)
        {
            // get first character of line
            string enemy = line.Substring(0, 1);
            string your = line.Substring(line.Length - 1, 1);

            total_score += (ReturnRoundScore(your) + ReturnShapeResultScore(enemy, your));
        }

        Console.WriteLine("Total score is " + total_score);
    }

    private static int ReturnRoundScore(string shape)
    {
        if (shape == "X") // lose
        {
            return 0;
        }
        else if (shape == "Y") // draw
        {
            return 3;
        }
        else // win
        {
            return 6;
        }
    }

    // @todo
    /*
    private static int ReturnRoundScore(string enemy, string your)
    {
        string match_result = ReturnRoundResult(enemy, your);
        if (match_result == "win")
        {
            return 6;
        }
        else if (match_result == "draw")
        {
            return 3;
        }
        else
        {
            return 0; // failsafe
        }
    }
    */

    private static int ReturnShapeResultScore(string enemy, string roundResult)
    {
        // @todo rewrite
        // 1 for rock, 2 for paper, 3 for scissors
        int[] lose = {3, 1, 2};
        int[] draw = {1, 2, 3};
        int[] win = {2, 3, 1};

        int enemyShape = 0;
        if (enemy == "A")
        {
            enemyShape = 0;
        }
        else if (enemy == "B")
        {
            enemyShape = 1;
        }
        else
        {
            enemyShape = 2;
        }

        if (roundResult == "X") // lose
        {
            return lose[enemyShape];
        }
        else if (roundResult == "Y") // draw
        {
            return draw[enemyShape];
        }
        else
        {
            return win[enemyShape];
        }
    }
}
