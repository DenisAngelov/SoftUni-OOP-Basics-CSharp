using System;

class Number
{
    int currNumber;
    bool isPrime;

    public int CurrNumber => currNumber;
    public bool IsPrime => isPrime;

    public Number(int currNumber)
    {
        this.currNumber = currNumber;
        isPrime = isNumPrime(currNumber);
    }

    public int GetNextPrime()
    {
        int nextPrime = currNumber;
        bool foundNextPrime = false;

        while (true)
        {
            nextPrime++;
            foundNextPrime = isNumPrime(nextPrime);
            if (foundNextPrime)
                break;
        }
        return nextPrime;
    }

    bool isNumPrime(int num)
    {
        bool isCurNumPrime = true;
        for (long j = 2; j < num; j++) 
        {
            if (num % j == 0)
            {
                isCurNumPrime = false;
                break;
            }
        }
        return isCurNumPrime;
    }
}

public class PrimeChecker
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Number currNumber = new Number(number);
        Number nextPrime = new Number(currNumber.GetNextPrime());
        Console.WriteLine($"{nextPrime.CurrNumber}, {currNumber.IsPrime.ToString().ToLower()}");
    }
}