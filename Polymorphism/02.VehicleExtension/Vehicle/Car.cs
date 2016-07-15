using System;

namespace _02.VehicleExtension.Vehicle
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelPerKm = fuelPerKm + 0.9;
            this.TankCapacity = tankCapacity;
        }

        public override void Refuel(double fuel)
        {
            double fuelSpace = TankCapacity - FuelQuantity;
            if (fuelSpace < fuel)
                throw new ArgumentException("Cannot fit fuel in tank");

            this.FuelQuantity += fuel;
        }

        public override void TravelDistance(double distance)
        {
            double requiredFuel = distance * this.FuelPerKm;
            if (requiredFuel <= this.FuelQuantity)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= requiredFuel;
            }
            else
                Console.WriteLine($"Car needs refueling");
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:F2}";
        }

    }
}
