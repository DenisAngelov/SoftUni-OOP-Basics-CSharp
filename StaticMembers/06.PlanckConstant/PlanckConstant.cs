using System;

class Calculation
{
    static double planck = 6.62606896e-34;
    static double PI = 3.14159;

    public static double Result()
    {
        return planck / (2 * PI);
    }

}

public class PlanckConstant
{
    public static void Main()
    {
        Console.WriteLine(Calculation.Result());
    }
}