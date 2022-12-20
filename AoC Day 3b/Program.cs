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

        /*
        foreach (string line in lines)
        {
            char item = FindMatchingItems(line);
            if (item != '\0')
            {
                total_score += ReturnItemScore(item);
            }
        }
        */
        for (int i = 0; i < lines.Length; i += 3)
        {
            char item = FindMatchingItems(lines[i], lines[i+1], lines[i+2]);
            if (item != '\0')
            {
                total_score += ReturnItemScore(item);
            }
        }

        Console.WriteLine("Total score is " + total_score);
    }

    private static char FindMatchingItems(string line1, string line2, string line3)
    {
        for (int i = 0; i < line1.Length; i++)
        {
            char current_char = line1[i];
            if (FindCharInLine(current_char, line2) && FindCharInLine(current_char, line3))
            {
                return current_char;
            }
        }

        return '\0'; // no matching chars, return null char

        bool FindCharInLine(char character, string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (character == line[i])
                {
                    return true;
                }
            }

            return false;
        }
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
