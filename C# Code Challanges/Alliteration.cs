using System;

namespace Alliteration
{
    public class Program
    {
        public int CountOfTheLetter(char letter, string input)
        {
            string[] words = input.Split(' ');
            int count = 0;

            foreach (string word in words)
            {
                if (word.Length > 0 && char.ToLower(word[0]) == char.ToLower(letter))
                {
                    count++;
                }
            }

            return count < 3 ? 0 : 2 * (count - 2);
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Enter the letter");
            char letter = Console.ReadLine()[0];
            Console.WriteLine("Enter the sentence");
            string sentence = Console.ReadLine();
            int score = program.CountOfTheLetter(letter, sentence);
            Console.WriteLine($"You got a score of {score}");
        }
    }
}