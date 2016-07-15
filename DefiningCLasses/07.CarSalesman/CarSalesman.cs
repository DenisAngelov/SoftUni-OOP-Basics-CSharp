using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public string model;
    public short power;
    public string displacement = "n/a";
    public string efficiency = "n/a";

    public Engine() { } 


    public Engine(string model, short power)
    {
        this.model = model;
        this.power = power;
    }
}

class Car
{
    string model;
    Engine refference;
    public string weight = "n/a";
    public string color = "n/a";

    public Car(string model, Engine refference)
    {
        this.model = model;
        this.refference = refference;
    }

    public override string ToString()
    {
        string engSpace = new string(' ', 4);
        return $"{model}:\n  {refference.model}:\n{engSpace}Power: {refference.power}\n{engSpace}Displacement: {refference.displacement}\n{engSpace}Efficiency: {refference.efficiency}\n  Weight: {weight}\n  Color: {color}";
    }
}

public class CarSalesman
{
    public static void Main()
    {
        int numOfEntries = int.Parse(Console.ReadLine());
        var cars = new List<Car>();
        var engines = new Dictionary<string, Engine>();

        for (int eng = 0; eng < numOfEntries; eng++)
        {
            string[] engineData = Console.ReadLine().Split();
            string model = engineData[0];
            short power = short.Parse(engineData[1]);
            Engine currEng = new Engine(model, power);

            if (!engines.ContainsKey(model))
                engines.Add(model, new Engine());

            if (engineData.Length == 3)
            {
                if (char.IsDigit(engineData[2][0]))
                    currEng.displacement = engineData[2];
                else
                    currEng.efficiency = engineData[2];
            }

            if (engineData.Length == 4)
            {
                currEng.displacement = engineData[2];
                currEng.efficiency = engineData[3];
            }

            engines[model] = currEng;

        }

        numOfEntries = int.Parse(Console.ReadLine());

        for (int car = 0; car < numOfEntries; car++)
        {
            string[] carData = Console.ReadLine().Trim().Split();

            Car currCar = new Car(carData[0], engines[carData[1]]);

            if (carData.Length == 3)
            {
                if (char.IsDigit(carData[2][0]))
                    currCar.weight = carData[2];
                else
                    currCar.color = carData[2];
            }
            if (carData.Length == 4)
            {
                currCar.weight = carData[2];
                currCar.color = carData[3];
            }

            cars.Add(currCar);
        }

        foreach (var car in cars)
            Console.WriteLine(car.ToString());
    }
}