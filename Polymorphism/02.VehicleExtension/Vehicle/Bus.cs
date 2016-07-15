using System;

namespace _02.VehicleExtension.Vehicle
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelPerKm = fuelPerKm;
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
            
        }

        public void TravelDistance(double distance, bool isEmpty)
        {
            double requiredFuel;

            if (isEmpty)
                requiredFuel = distance * this.FuelPerKm;
            else
                requiredFuel = distance * (this.FuelPerKm + 1.4);
             
            if (requiredFuel <= this.FuelQuantity)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= requiredFuel;
            }
            else
                Console.WriteLine($"Bus needs refueling");
        }

        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:F2}";
        }

    }
}
