using System;

class Temparature
{
    public static double ConvertToCelsius(int temparature)
    {
        return (temparature - 32) * 0.5556;
    }

    public static double ConvertToFahrenheit(int temparature)
    {
        return (temparature * 1.8) + 32;
    }
}

public class TemperatureConverter
{
    public static void Main()
    {
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "End")
        {
            string[] tempInfo = data.Split();
            if (tempInfo[1].ToLower().Equals("celsius"))
            {
                double fahr = Temparature.ConvertToFahrenheit(int.Parse(tempInfo[0]));
                Console.WriteLine($"{fahr:F2} Fahrenheit");
            }
            else
            {
                double cels = Temparature.ConvertToCelsius(int.Parse(tempInfo[0]));
                Console.WriteLine($"{cels:F2} Celsius");
            }
        }

    }
}