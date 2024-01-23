using System;

namespace AbsoluteDifference // Do not change the namespace name
{
    public class Program // Do not change the class name
    {
        public int Difference(int[] values) // Do not change the method signature
        {
            int sum = 0;
            int n = values.Length;

            for (int i = 0; i < n / 2; i++)
            {
                int absoluteDifference = Math.Abs(values[i] - values[n - 1 - i]);
                sum += absoluteDifference;
            }

            return sum;
        }

        public string ValidateInput(int input) // Do not change the method signature
        {
            return input > 0 ? "passed" : "is an invalid value";
        }

        public string CheckSize(int arraySize) // Do not change the method signature
        {
            return arraySize % 2 == 0 && arraySize > 0 ? "valid size" : "is an invalid size";
        }

        public static void Main(string[] args) // Do not change the method signature
{
    Program program = new Program();

    Console.WriteLine("Enter the number of values");

    if (int.TryParse(Console.ReadLine(), out int arraySize))
    {
        string sizeValidationResult = program.CheckSize(arraySize);

        if (sizeValidationResult == "valid size")
        {
            Console.WriteLine("Enter the numbers");
            int[] values = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int inputValue))
                {
                    values[i] = inputValue;
                }
                else
                {
                    Console.WriteLine($"{inputValue} is an invalid value");
                    return;
                }
            }

            int sum = program.Difference(values);
            Console.WriteLine(sum);
        }
        else
        {
            Console.WriteLine($"{arraySize} {sizeValidationResult}");
        }
    }
    else
    {
        Console.WriteLine("Invalid input for array size");
    }
}
    }
}