using System;
using System.IO;

class AoC_Day1a
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Only accepting 1 argument that is the input file. Exiting...");
            return;
        }

        string[] lines = File.ReadAllLines(args[0]);

        int most_food = 0;
        int current_food = 0;

        foreach (string line in lines)
        {
            if (line == "")
            {
                if (most_food < current_food)
                {
                    most_food = current_food;
                }
                current_food = 0;
            }
            else
            {
                int food = Convert.ToInt32(line);
                current_food += food;
            }
        }

        Console.WriteLine("The most food is " + most_food);
    }
}