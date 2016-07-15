using System;
using System.Linq;

class CountBeer
{
    static int beerInStock = 0;
    static int beersDrank = 0;

    public static int InStock => beerInStock;
    public static int Drank => beersDrank;

    public static void BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
    }

    public static void DrinkBeer(int bottlesCount)
    {
        beersDrank += bottlesCount;
        beerInStock -= bottlesCount;
    }
}

public class BeerCounter
{
    public static void Main()
    {
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "End")
        {
            int[] beerInfo = data.Split().Select(int.Parse).ToArray();
            CountBeer.BuyBeer(beerInfo[0]);
            CountBeer.DrinkBeer(beerInfo[1]);
        }

        Console.WriteLine($"{CountBeer.InStock} {CountBeer.Drank}");
    }
}