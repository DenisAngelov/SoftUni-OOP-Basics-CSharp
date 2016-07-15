using System;
using System.Linq;
using System.Reflection;

class Box
{
    private double length;
    private double width;
    private double height;

    public double Volume => length * width * height;
    public double LateralSurface => 2 * (length * height) + 2 * (width * height);
    public double Surface => 2 * (length * width) + 2 * (length * height) + 2 * (width * height);

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

}

class ClassBox
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        double[] boxParams = new double[3];

        for (int i = 0; i < 3; i++)
            boxParams[i] = double.Parse(Console.ReadLine());

        Box newBox = new Box(boxParams[0], boxParams[1], boxParams[2]);

        Console.WriteLine($"Surface Area - {newBox.Surface:F2}");
        Console.WriteLine($"Lateral Surface Area - {newBox.LateralSurface:F2}");
        Console.WriteLine($"Volume - {newBox.Volume:F2}");
    }
}