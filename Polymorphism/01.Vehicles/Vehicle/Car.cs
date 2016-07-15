using System;

namespace _01.Vehicles.Vehicle
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelPerKm)
        {
            base.FuelQuantity = fuelQuantity;
            base.FuelPerKm = fuelPerKm + 0.9;
        }

        public override void Refuel(double fuel)
        {
            if (fuel < 0)
                throw new ArgumentException();

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
