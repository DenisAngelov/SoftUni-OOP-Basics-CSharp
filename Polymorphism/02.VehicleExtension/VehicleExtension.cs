using System;
using _02.VehicleExtension.Vehicle;
using System.Linq;

public class VehicleExtension
{
    public static void Main()
    {
        double[] vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Car myCar = new Car(vehicleData[0], vehicleData[1], vehicleData[2]);
        vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Truck myTruck = new Truck(vehicleData[0], vehicleData[1], vehicleData[2]);
        vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
        Bus myBus = new Bus(vehicleData[0], vehicleData[1], vehicleData[2]);

        int numOfInputs = int.Parse(Console.ReadLine());

        for (int input = 0; input < numOfInputs; input++)
        {
            string[] command = Console.ReadLine().Split();

            try
            {
                if (command[1].Equals("Car"))
                {
                    if (command[0].Equals("Drive"))
                        myCar.TravelDistance(double.Parse(command[2]));
                    else
                        myCar.Refuel(double.Parse(command[2]));
                }
                else if (command[1].Equals("Truck"))
                {
                    if (command[0].Equals("Drive"))
                        myTruck.TravelDistance(double.Parse(command[2]));
                    else
                        myTruck.Refuel(double.Parse(command[2]));
                }
                else
                {
                    if (command[0].Equals("DriveEmpty"))
                        myBus.TravelDistance(double.Parse(command[2]), true);
                    else if (command[0].Equals("Drive"))
                        myBus.TravelDistance(double.Parse(command[2]), false);
                    else
                        myBus.Refuel(double.Parse(command[2]));
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(myCar);
        Console.WriteLine(myTruck);
        Console.WriteLine(myBus);
    }
}