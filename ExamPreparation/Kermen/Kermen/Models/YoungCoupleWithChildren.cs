using System;
using System.Linq;

namespace Kermen
{
    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const int RoomElectricity = 30;
        private Child[] children;

        public YoungCoupleWithChildren(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost, Child[] children) 
            : base(salaryOne + salaryTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost, laptopCost)
        {
            this.children = children;
        }

        public override decimal Consumption
        {
            get
            {
                return this.children.Sum(x => x.GetTotalConsumptions()) + base.Consumption;
            }
        }

        public override int Population
        {
            get
            {
                return this.children.Length + base.Population;
            }
        }
    }
}