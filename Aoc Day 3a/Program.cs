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
            char item = FindMatchingItems(line);
            if (item != '\0')
            {
                total_score += ReturnItemScore(item);
            }
        }


        Console.WriteLine("Total score is " + total_score);
    }

    private static char FindMatchingItems(string line)
    {
        string first_part = line.Substring(0, line.Length/2);
        string second_part = line.Substring(line.Length/2, line.Length/2);

        for (int i = 0; i < first_part.Length; i++)
        {
            char current_char = first_part[i];

            for (int j = 0; j < second_part.Length; j++)
            {
                if (current_char == second_part[j])
                {
                    return current_char;
                }
            }
        }

        return '\0';
    }

    private static int ReturnItemScore(char item)
    {
        if (Char.IsLower(item))
        {
            return (int)item - 96;
        }
        else
        {
            return (int)item - 65 + 27; // align with 0 according to ascii, then add 27 for priority
        }
    }
}
