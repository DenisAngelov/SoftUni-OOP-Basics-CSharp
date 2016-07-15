using System;

namespace _02.VehicleExtension.Vehicle
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelPerKm;
        private double tankCapacity;

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }

            protected set
            {
                this.tankCapacity = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Fuel must be a positive number");

                this.fuelQuantity = value;
            }
        }

        public double FuelPerKm
        {
            get
            {
                return fuelPerKm;
            }

            protected set
            {
                if (value < 0)
                    throw new ArgumentException();

                this.fuelPerKm = value;
            }
        }

        public abstract void Refuel(double fuel);
        public abstract void TravelDistance(double distance);

    }
}
