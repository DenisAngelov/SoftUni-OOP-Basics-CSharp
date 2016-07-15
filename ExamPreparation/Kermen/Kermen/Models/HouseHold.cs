using System;

namespace Kermen
{
    public abstract class HouseHold
    {
        private int numberOfRooms;
        private decimal roomElectricity;
        private readonly decimal income;
        private decimal money;

        protected HouseHold(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.money = 0;
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
        }

        public virtual decimal Consumption
        {
            get
            {
                return this.roomElectricity * this.numberOfRooms;
            }
        }

        public virtual int Population
        {
            get { return 1; }
        }

        public void GetIncome()
        {
            this.money += this.income;
        }

        public bool CanPayBills()
        {
            return this.money >= this.Consumption;
        }

        public void PayBills()
        {
            this.money -= this.Consumption;
        }

    }
}