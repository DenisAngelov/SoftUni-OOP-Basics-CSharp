using System;

namespace Kermen
{
    public abstract class Couple : HouseHold
    {
        private decimal tvCost;
        private decimal fridgeCost;

        public Couple(decimal income, int numberOfRooms, decimal roomElectricity, decimal tvCost, decimal fridgeCost) 
            : base(income, numberOfRooms, roomElectricity)
        {
        }

        public override decimal Consumption
        {
            get
            {
                return this.tvCost + this.fridgeCost + base.Consumption;
            }
        }

        public override int Population
        {
            get
            {
                return 1 + base.Population;
            }
        }

    }
}