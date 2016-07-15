using System;
using System.Collections.Generic;

class Car
{
    public string model;
    public float fuelAmmount;
    public float distancePerKm;
    public float distanceTraveled = 0;

    public Car(string model, float fuelAmmount, float distancePerKm)
    {
        this.model = model;
        this.fuelAmmount = fuelAmmount;
        this.distancePerKm = distancePerKm;
    }

}

public class SpeedRacing
{
    public static void Main(string[] args)
    {
        int numOfCars = int.Parse(Console.ReadLine());
        string action = string.Empty;
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int car = 0; car < numOfCars; car++)
        {
            string[] carData = Console.ReadLine().Split();
            cars.Add(carData[0], new Car(carData[0], float.Parse(carData[1]), float.Parse(carData[2])));
        }

        while ((action = Console.ReadLine()) != "End")
        {
            string[] currAction = action.Split();

            var currCar = cars[currAction[1]];
            float distanceToTravel = float.Parse(currAction[2]);
            float fuelToSubs = distanceToTravel * currCar.distancePerKm;
            bool canPass = currCar.fuelAmmount - fuelToSubs < 0 ? false : true;

            if (canPass)
            {
                currCar.fuelAmmount -= fuelToSubs;
                currCar.distanceTraveled += float.Parse(currAction[2]);
            }else
                Console.WriteLine("Insufficient fuel for the drive");
        }

        foreach (var car in cars)
        {
            var currCar = car.Value;
            Console.WriteLine("{0} {1:0.00} {2}", currCar.model, currCar.fuelAmmount, currCar.distanceTraveled);
        }

    }
}