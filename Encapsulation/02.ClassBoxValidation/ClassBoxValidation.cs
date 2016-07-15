using System;
using System.Linq;
using System.Reflection;

class Box
{
    private double length;
    private double width;
    private double height;
    public bool wrongValues = false;

    public double Volume => length * width * height;
    public double LateralSurface => 2 * (length * height) + 2 * (width * height);
    public double Surface => 2 * (length * width) + 2 * (length * height) + 2 * (width * height);

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Heigth = height;
    }

    private double Length
    {
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
                wrongValues = true;
            }
            this.length = value;
        }
    }

    private double Width
    {
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
                wrongValues = true;
            }
            this.width = value;
        }
    }

    private double Heigth
    {
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                wrongValues = true;
            }
            this.height = value;
        }
    }

}

public class ClassBoxValidation
{
    public static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        double[] boxParams = new double[3];

        for (int i = 0; i < 3; i++)
            boxParams[i] = double.Parse(Console.ReadLine());

        Box newBox = new Box(boxParams[0], boxParams[1], boxParams[2]);

        if (!newBox.wrongValues)
        {
            Console.WriteLine($"Surface Area - {newBox.Surface:F2}");
            Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurface:F2}");
            Console.WriteLine($"Volume - {newBox.Volume:F2}");
        }
        
    }
}