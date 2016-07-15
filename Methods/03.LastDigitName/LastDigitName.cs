using System;

class Number
{
    char digit;

    public Number(char digit)
    {
        this.digit = digit;
    }

    public string NameOfNumber()
    {
        switch (digit)
        {
            case '0': return "zero";
            case '1': return "one";
            case '2': return "two";
            case '3': return "three";
            case '4': return "four";
            case '5': return "five";
            case '6': return "six";
            case '7': return "seven";
            case '8': return "eight";
            case '9': return "nine";
            default: return "Invalid number!";
        }
    }

}

public class LastDigitName
{
    public static void Main()
    {
        string data = Console.ReadLine();
        Number charToNum = new Number(data[data.Length - 1]);
        Console.WriteLine(charToNum.NameOfNumber());
    }
}