using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kermen
{
    public class HouseHoldFactory
    {
        public static HouseHold CreateHouseHold(string input)
        {
            Regex rgx = new Regex(@"(\w+)\(([\d,.\s]+)\)");
            MatchCollection matches = rgx.Matches(input);
            if (rgx.IsMatch(input))
            {
                string houseHoldType = matches[0].Groups[1].Value;

                if (houseHoldType == "YoungCouple")
                {
                    decimal[] salaries = matches[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(decimal.Parse)
                        .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

                    return new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);
                }
                else if (houseHoldType == "YoungCoupleWithChildren")
                {
                    decimal[] salaries = matches[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(decimal.Parse)
                       .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);
                    Child[] children = new Child[matches.Count - 4];

                    for (int i = 4; i < matches.Count; i++)
                    {
                        decimal[] consumptions = matches[i].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(decimal.Parse)
                         .ToArray();
                        children[i - 4] = new Child(consumptions);
                    }

                    return new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost, children);
                }
                else if (houseHoldType == "AloneYoung")
                {
                    decimal salary = decimal.Parse(matches[0].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[1].Groups[2].Value);
                    return new AloneYoung(salary, laptopCost);
                }
                else if (houseHoldType == "OldCouple")
                {
                    decimal[] salaries = matches[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(decimal.Parse)
                       .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);

                    return new OldCouple(salaries[0], salaries[1], tvCost, fridgeCost, stoveCost);
                }
                else if (houseHoldType == "AloneOld")
                {
                    decimal pension = decimal.Parse(matches[0].Groups[2].Value);
                    return new AloneOld(pension);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            throw new ArgumentException();
        }
    }
}
