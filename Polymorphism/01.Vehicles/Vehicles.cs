using System;
using _01.Vehicles.Vehicle;
using System.Collections.Generic;
using System.Linq;

namespace _01.Vehicles
{
    public class Vehicles
    {
        public static void Main()
        {
            double[] vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            Car myCar = new Car(vehicleData[0], vehicleData[1]);
            vehicleData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            Truck myTruck = new Truck(vehicleData[0], vehicleData[1]);

            int numOfInputs = int.Parse(Console.ReadLine());

            for (int input = 0; input < numOfInputs; input++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[1].Equals("Car"))
                {
                    if (command[0].Equals("Drive"))
                        myCar.TravelDistance(double.Parse(command[2]));
                    else
                        myCar.Refuel(double.Parse(command[2]));
                }
                else
                {
                    if (command[0].Equals("Drive"))
                        myTruck.TravelDistance(double.Parse(command[2]));
                    else
                        myTruck.Refuel(double.Parse(command[2]));
                }
            }

            Console.WriteLine(myCar);
            Console.WriteLine(myTruck);
        }
    }
}
