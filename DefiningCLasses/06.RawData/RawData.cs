using System;
using System.Collections.Generic;

class Car
{
    public string model = string.Empty;
    public Engine engine;
    Cargo cargo;
    public Tires tires;

    Car() : this(null, null, 0, null, null, null)
    {

    }

    public Car(string model, int[] engine, int weight, string type, int[] age, double[] pressure)
    {
        this.model = model;
        this.engine = new Engine(engine[0], engine[1]);
        this.cargo = new Cargo(weight, type);
        this.tires = new Tires(age, pressure);
    }
}

class Engine
{
    int speed;
    public int power;

    public Engine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }

}

class Tires
{
    int[] age = new int[4];
    public double[] pressure = new double[4];

    public Tires(int[] age, double[] pressure)
    {
        this.age = age;
        this.pressure = pressure;
    }

}

class Cargo
{
    int weight;
    string type = string.Empty;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }

}

public class RawData
{
    public static void Main()
    {
        int numOfInputs = int.Parse(Console.ReadLine());
        string printType = string.Empty;
        Dictionary<string, List<Car>> cars = new Dictionary<string, List<Car>>();

        for (int input = 0; input < numOfInputs; input++)
        {
            string[] data = Console.ReadLine().Split();
            string type = data[4];
            int[] engine = new int[2] { int.Parse(data[1]), int.Parse(data[2])};
            int[] tireAge = new int[4] { int.Parse(data[6]), int.Parse(data[8]), int.Parse(data[10]), int.Parse(data[12]) };
            double[] tirePressure = new double[4] { double.Parse(data[5]), double.Parse(data[7]), double.Parse(data[9]), double.Parse(data[11]) };

            if (!cars.ContainsKey(type))
                cars.Add(type, new List<Car>());
            cars[type].Add(new Car (data[0], engine, int.Parse(data[3]), data[4], tireAge, tirePressure));
        }

        printType = Console.ReadLine();

        foreach (var type in cars[printType])
        {
            if (printType.Equals("flamable"))
            {
                if (type.engine.power > 250)
                    Console.WriteLine(type.model);
            }
            else
            {
                if (type.tires.pressure[0] < 1)
                    Console.WriteLine(type.model);
            }
        }
    }
}