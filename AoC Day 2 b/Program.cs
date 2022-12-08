using System;
using System.IO;

class AoC_Day1b
{
    private struct ListCopy
    {
        public int Index;
        public int Value;
    }

    private static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Only accepting 1 argument that is the input file. Exiting...");
            return;
        }

        string[] lines = File.ReadAllLines(args[0]);

        int[] most_food = {0, 0, 0};
        int current_food = 0;

        foreach (string line in lines)
        {
            if (line == "")
            {
                UpdateMostFood(most_food, current_food);
                current_food = 0;
            }
            else
            {
                int food = Convert.ToInt32(line);
                current_food += food;
            }
        }

        Console.WriteLine("The sum of top 3 food is " + (most_food[0] + most_food[1] + most_food[2]));
    }

    // find the lowest element in array and replace if current higher
    // else remove it and find the next lowest...
    private static void UpdateMostFood(int[] most_food, int current_food)
    {
        List<ListCopy> most_food_copy = new List<ListCopy>();
        for (int i = 0; i < most_food.Length; i++)
        {
            ListCopy temp = new ListCopy();
            temp.Index = i;
            temp.Value = most_food[i];
            most_food_copy.Add(temp);
        }
        while (true)
        {
            if (most_food_copy.Count == 0)
            {
                break;
            }
            else
            {
                (int smallest_index, int list_index) indices = FindSmallestElementListCopy(most_food_copy);
                if (current_food > most_food[indices.smallest_index])
                {
                    most_food[indices.smallest_index] = current_food;
                    break;
                }
                else
                {
                    most_food_copy.RemoveAt(indices.list_index);
                }
            }
        }
    }

    // finds the smallest element in an ListCopy List
    private static (int arrayIndex, int listIndex) FindSmallestElementListCopy(List<ListCopy> list)
    {
        int smallest = list[0].Value;
        int smallest_index = 0;
        int list_index = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Value < smallest)
            {
                smallest = list[i].Value;
                smallest_index = list[i].Index;
                list_index = i;
            }
        }

        return (smallest_index, list_index);
    }
}
