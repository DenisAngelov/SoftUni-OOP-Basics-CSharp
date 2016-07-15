using System;

class MathUtil
{
    public static string Sum(float x, float y)
    {
        return $"{x + y:F2}";
    }

    public static string Subtract(float x, float y)
    {
        return $"{x - y:F2}";
    }

    public static string Multiply(float x, float y)
    {
        return $"{x * y:F2}";
    }

    public static string Divide(float x, float y)
    {
        return $"{x / y:F2}";
    }

    public static string Percentage(float x, float y)
    {
        return $"{x * (y * 0.01):F2}";
    }
}

public class BasicMath
{
    public static void Main()
    {
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "End")
        {
            string[] problemInfo = data.Split();
            switch (problemInfo[0])
            {
                case "Sum": Console.WriteLine(MathUtil.Sum(float.Parse(problemInfo[1]), float.Parse(problemInfo[2]))); break;
                case "Subtract": Console.WriteLine(MathUtil.Subtract(float.Parse(problemInfo[1]), float.Parse(problemInfo[2]))); break;
                case "Multiply": Console.WriteLine(MathUtil.Multiply(float.Parse(problemInfo[1]), float.Parse(problemInfo[2]))); break;
                case "Divide": Console.WriteLine(MathUtil.Divide(float.Parse(problemInfo[1]), float.Parse(problemInfo[2]))); break;
                case "Percentage": Console.WriteLine(MathUtil.Percentage(float.Parse(problemInfo[1]), float.Parse(problemInfo[2]))); break;
            }
        }
    }
}