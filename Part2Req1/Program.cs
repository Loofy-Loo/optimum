using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int Start = 1;

        Console.Write("Enter an integer: ");
        int End = int.Parse(Console.ReadLine());

        Calculate(Start, End);
    }

    static void Calculate(int Start, int End)
    {
        List<int> numbers = new List<int>();
        int totalSum = 0;

        for (int num = Start; num <= End; num++)
        {
            if (num % 3 == 0 || num % 5 == 0)
            {
                numbers.Add(num);
                totalSum += num;
            }
        }

        var ListOfNum = string.Join("+", numbers);
        Console.WriteLine( ListOfNum + " = " + totalSum);
    }
}