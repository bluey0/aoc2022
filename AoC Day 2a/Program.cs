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

            total_score += (ReturnShapeScore(your) + ReturnRoundScore(enemy, your));
        }

        Console.WriteLine("Total score is " + total_score);
    }

    private static int ReturnShapeScore(string shape)
    {
        if (shape == "X") // rock
        {
            return 1;
        }
        else if (shape == "Y") // paper
        {
            return 2;
        }
        else if (shape == "Z") // scissors
        {
            return 3;
        }
        else
        {
            return 0; // invalid shape
        }
    }

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

    private static string ReturnRoundResult(string enemy, string your)
    {
        string[] enemy_rock = {"draw", "win", "lose"};
        string[] enemy_paper = {"lose", "draw", "win"};
        string[] enemy_scissors = {"win", "lose", "draw"};

        int ReturnResult(string your) // match your move/shape to the arr
        {
            if (your == "X")
            {
                return 0;
            }
            else if (your == "Y")
            {
                return 1;
            }
            if (your == "Z")
            {
                return 2;
            }
            else
            {
                return 0; // failsafe
            }
        }

        // maybe could simplify...
        if (enemy == "A") // rock
        {
            return enemy_rock[ReturnResult(your)];
        }
        if (enemy == "B") // paper
        {
            return enemy_paper[ReturnResult(your)];
        }
        if (enemy == "C") // scissors
        {
            return enemy_scissors[ReturnResult(your)];
        }
        else
        {
            return "lose"; // failsafe
        }
    }
}
