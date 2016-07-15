using System;

namespace Kermen
{
    public class OldCouple : Couple
    {
        private decimal stoveCost;
        private const int NumberOfRooms = 3;
        private const int RoomElectricity = 15;

        public OldCouple(decimal pensionOne, decimal pensionTwo, decimal tvCost, decimal fridgeCost, decimal stoveCost) 
            : base(pensionOne + pensionTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumption
        {
            get
            {
                return stoveCost + base.Consumption;
            }
        }
    }
}