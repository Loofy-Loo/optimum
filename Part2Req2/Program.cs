using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "Fibonacci.txt";
        int[] ListOfNumber = GetFibonacci(15);

        File.WriteAllText(filePath, string.Join(", ", ListOfNumber));

        Console.WriteLine("File Fibonacci.txt created");
    }

    static int[] GetFibonacci(int count)
    {
        int[] sequence = new int[count];
        sequence[0] = 0;
        sequence[1] = 1;

        for (int i = 2; i < count; i++)
        {
            sequence[i] = sequence[i - 1] + sequence[i - 2];
        }

        return sequence;
    }
}