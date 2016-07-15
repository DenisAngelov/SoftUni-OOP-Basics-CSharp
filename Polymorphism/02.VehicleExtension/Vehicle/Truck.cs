using System;

namespace _02.VehicleExtension.Vehicle
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelPerKm = fuelPerKm + 1.6;
            this.TankCapacity = tankCapacity;
        }

        public override void Refuel(double fuel)
        {
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
