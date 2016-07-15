using System;
using System.Collections.Generic;
using System.Linq;

namespace Kermen
{
    public class Launcher
    {
        public static void Main()
        {
            List<HouseHold> kermen = new List<HouseHold>();
            string command = string.Empty;
            int counter = 0;

            while ((command = Console.ReadLine()) != "Democracy")
            {
                try
                {
                    HouseHold entity = HouseHoldFactory.CreateHouseHold(command);
                    kermen.Add(entity);
                }
                catch (Exception)
                {

                }

                if (counter % 3 == 0)
                    kermen.ForEach(x => x.GetIncome());

                if (command == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBills());
                    kermen.ForEach(x => x.PayBills());
                }else if (command == "EVN")
                    Console.WriteLine($"Total consumption {kermen.Sum(x => x.Consumption)}");

                counter++;
            }

            int asd = kermen.Sum(x => x.Population);

            Console.WriteLine($"Total population: {asd}");

        }
    }
}
