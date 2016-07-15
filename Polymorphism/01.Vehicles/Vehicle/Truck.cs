using System;

namespace _01.Vehicles.Vehicle
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelPerKm)
        {
            base.FuelQuantity = fuelQuantity;
            base.FuelPerKm = fuelPerKm + 1.6;
        }

        public override void Refuel(double fuel)
        {
            if (fuel < 0)
                throw new ArgumentException();

            this.FuelQuantity += fuel * 0.95;
        }

        public override void TravelDistance(double distance)
        {
            double requiredFuel = distance * this.FuelPerKm;
            if (requiredFuel <= this.FuelQuantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= requiredFuel;
            }
            else
                Console.WriteLine($"Truck needs refueling");
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:F2}";
        }

    }
}
