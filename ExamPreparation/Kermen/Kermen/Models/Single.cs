using System;


namespace Kermen
{
    public abstract class Single : HouseHold
    {
        public Single(decimal income, int numberOfRooms, decimal roomElectricity) 
            : base(income, numberOfRooms, roomElectricity)
        {
        }
    }
}