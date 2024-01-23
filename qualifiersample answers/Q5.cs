// 5. Wings APP
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static Dictionary<string, int> BirdDetails = new Dictionary<string, int>();

    public static void AddBirdDetails(string[] bird)
    {
        foreach (var b in bird)
        {
            var details = b.Split(':');
            BirdDetails[details[0]] = Convert.ToInt32(details[1]);
        }
    }

    public static int FindTheBirdCount(string birdName)
    {
        if (BirdDetails.ContainsKey(birdName))
        {
            return BirdDetails[birdName];
        }
        else
        {
            Console.WriteLine("No birds are available");
            return -1;
        }
    }

    public static List<string> FindTheHighestCountOfBird()
    {
        var maxCount = BirdDetails.Values.Max();
        return BirdDetails.Where(x => x.Value == maxCount).Select(x => x.Key).ToList();
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Bird Details");
            Console.WriteLine("2. View Number of Birds By Bird Name");
            Console.WriteLine("3. View Birds With Highest Count");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter the choice");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the number of entries");
                    var entries = Convert.ToInt32(Console.ReadLine());
                    var birds = new string[entries];
                    for (int i = 0; i < entries; i++)
                    {
                        birds[i] = Console.ReadLine();
                    }
                    AddBirdDetails(birds);
                    break;
                case 2:
                    Console.WriteLine("Enter the bird name to get the number of birds");
                    var birdName = Console.ReadLine();
                    var count = FindTheBirdCount(birdName);
                    if (count != -1)
                    {
                        Console.WriteLine("Number of Birds : " + count);
                    }
                    break;
                case 3:
                    var highestCountBirds = FindTheHighestCountOfBird();
                    Console.WriteLine("Bird names with the highest count are:");
                    foreach (var bird in highestCountBirds)
                    {
                        Console.WriteLine(bird);
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank you.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}