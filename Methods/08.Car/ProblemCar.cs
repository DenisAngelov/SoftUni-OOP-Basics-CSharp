using System;
using System.Linq;

class Car
{
    double speed;
    double fuel;
    double fuelEconomy;
    double distance;

    public string GetFuel => $"Fuel left: {fuel:F1} liters";
    public string GetTime => $"Total time: {distance / speed} hours and {distance % speed} minutes";
    public string Distance => $"Total distance: {distance:F1} kilometers";
    public void AddFuel(double amount) => fuel += amount;

    public Car(double speed, double fuel, double fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
    }

    public void Travel(double distance)
    {
        fuel -= distance * (fuel / fuelEconomy);
        this.distance += distance;
    }
}

public class ProblemCar
{
    static void Main()
    {
        double[] carData = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Car judgeCar = new Car(carData[0], carData[1], carData[2]);

        string data = string.Empty;

        while ((data = Console.ReadLine()) != "END")
        {
            string[] currInput = data.Split();
            switch (currInput[0])
            {
                case "Distance": Console.WriteLine(judgeCar.Distance);break;
                case "Time": Console.WriteLine(judgeCar.GetTime);break;
                case "Fuel": Console.WriteLine(judgeCar.GetFuel);break;
                case "Refuel": judgeCar.AddFuel(double.Parse(currInput[1]));break;
                case "Travel": judgeCar.Travel(double.Parse(currInput[1]));break;
            }
        }
    }
}