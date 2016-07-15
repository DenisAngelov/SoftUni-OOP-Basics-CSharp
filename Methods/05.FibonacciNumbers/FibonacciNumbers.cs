using System;
using System.Collections.Generic;

class FibonacciSequence
{
    List<long> fibSeq = new List<long>();

    public FibonacciSequence()
    {

    }

    public List<long> GetNumbersInRange(int startPosition, int endPosition)
    {
        fibSeq.Add(0);

        long a = 0;
        long b = 1;
        for (int i = 0; i < endPosition - 1; i++)
        {
            long temp = a;
            a = b;
            b = temp + b;
            fibSeq.Add(a);
        }

        return fibSeq.GetRange(startPosition, endPosition - startPosition);
    }

}

public class FibonacciNumbers
{
    public static void Main()
    {
        int startPosition = int.Parse(Console.ReadLine());
        int endPosition = int.Parse(Console.ReadLine());

        FibonacciSequence newSequence = new FibonacciSequence();
        List<long> fibonacciSequence = newSequence.GetNumbersInRange(startPosition, endPosition);
        Console.WriteLine(string.Join(", ", fibonacciSequence));
    }
}