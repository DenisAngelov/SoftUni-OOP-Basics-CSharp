using System;
using System.Linq;

namespace Kermen
{
    public class Child
    {
        private decimal[] consumptions;

        public Child(decimal[] consumptions)
        {
            this.consumptions = consumptions;
        }

        public decimal GetTotalConsumptions()
        {
            return this.consumptions.Sum();
        }

    }
}