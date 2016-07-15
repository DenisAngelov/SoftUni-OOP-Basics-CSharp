using System;


namespace Kermen
{
    public class AloneOld : Single
    {
        private const decimal RoomElectricity = 15;
        private const int NumberOfRooms = 1;

        public AloneOld(decimal income) 
            : base(income, NumberOfRooms, RoomElectricity)
        {
        }
    }
}