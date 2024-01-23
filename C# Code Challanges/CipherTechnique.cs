using System;

namespace CipherTechnique
{
    public class Program
    {
        // Do not change the method signature
        public string CipherTechnique(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "no hidden message";

            char[] inputArray = input.ToCharArray();
            bool hasLetter = false;

            for (int i = 0; i < inputArray.Length; i++)
            {
                char character = inputArray[i];

                // Check if the character is a letter
                if (char.IsLetter(character))
                {
                    hasLetter = true;
                    char decryptedChar = (char)(character - 7);
                    if (char.IsLower(character) && decryptedChar < 'a')
                        decryptedChar = (char)(decryptedChar + 26);
                    else if (char.IsUpper(character) && decryptedChar < 'A')
                        decryptedChar = (char)(decryptedChar + 26);

                    inputArray[i] = decryptedChar;
                }
                // If the character is not a letter, do nothing
            }

            return hasLetter ? new string(inputArray) : "no hidden message";
        }

        // Do not change the method signature
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the encrypted text:");
            string encryptedText = Console.ReadLine();

            // Create an instance of the Program class to call the non-static method
            Program program = new Program();
            string decryptedText = program.CipherTechnique(encryptedText);

            Console.WriteLine(decryptedText);
        }
    }
}
