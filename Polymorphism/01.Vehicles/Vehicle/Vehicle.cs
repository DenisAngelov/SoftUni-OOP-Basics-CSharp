using System;

namespace _01.Vehicles.Vehicle
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelPerKm;

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                if (value < 0)
                    throw new ArgumentException();
                
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
