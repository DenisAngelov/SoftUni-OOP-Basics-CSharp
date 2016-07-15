using System;
using System.Linq;

class DecimalNumber
{
    string number;

    public DecimalNumber(string number)
    {
        this.number = number;
    }
    
    public string Reverse()
    {
        return string.Join("", number.Reverse());
    }

}

public class NumberInRevOrder
{
    public static void Main()
    {
        string number = Console.ReadLine();
        DecimalNumber num = new DecimalNumber(number);
        Console.WriteLine(num.Reverse());
    }
}