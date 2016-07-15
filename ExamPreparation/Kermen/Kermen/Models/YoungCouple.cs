using System;

namespace Kermen
{
    public class YoungCouple : Couple
    {
        private decimal laptopCost;
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 20;

        public YoungCouple(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost) 
            : base(salaryOne + salaryTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YoungCouple(decimal income, int numberOfRooms, decimal roomElectricty, decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(income, numberOfRooms, roomElectricty, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption
        {
            get
            {
                return (this.laptopCost * 2) + base.Consumption;
            }
        }
    }
}