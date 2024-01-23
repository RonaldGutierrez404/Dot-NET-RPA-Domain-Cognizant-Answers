using System;
using System.Linq;
 
namespace AnagramSentence
{
    public class Program
    {
        public String CheckForAnagram(String Word1, String Word2)
        {
            // Check for non-alphabetic characters in Word1
            if (!Word1.All(char.IsLetter))
                return $"{Word1} contains characters other than alphabets";
 
            // Check for non-alphabetic characters in Word2
            if (!Word2.All(char.IsLetter))
                return $"{Word2} contains characters other than alphabets";
 
            // Convert the words to lowercase for case-insensitive comparison
            string lowerWord1 = Word1.ToLower();
            string lowerWord2 = Word2.ToLower();
 
            // Check if the words are anagrams
            if (string.Concat(lowerWord1.OrderBy(c => c)) == string.Concat(lowerWord2.OrderBy(c => c)))
                return $"{Word1} and {Word2} contains the same characters";
            else
                return $"{Word1} and {Word2} contains different characters";
        }
 
        public static void Main(string[] args)
        {
            Program program = new Program();
 
            Console.WriteLine("Enter the word 1");
            string word1 = Console.ReadLine();
 
            Console.WriteLine("Enter the word 2");
            string word2 = Console.ReadLine();
 
            // Call the CheckForAnagram method and display the result
            string result = program.CheckForAnagram(word1, word2);
            Console.WriteLine(result);
        }
    }
}