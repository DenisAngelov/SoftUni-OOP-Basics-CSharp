using System;


namespace Kermen
{
    public class AloneYoung : Single
    {
        private decimal laptopCost;
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 10;

        public AloneYoung(decimal income, decimal laptopCost) 
            : base(income, NumberOfRooms, RoomElectricity)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption
        {
            get
            {
                return laptopCost + base.Consumption;
            }
        }

    }
}