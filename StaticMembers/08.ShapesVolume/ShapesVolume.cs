using System;

class Cube
{
    public double side;

    public Cube(double side)
    {
        this.side = side;
    }
}

class Cylinder
{
    public double radius;
    public double height;

    public Cylinder(double radius, double height)
    {
        this.radius = radius;
        this.height = height;
    }
}


class TriangularPrism
{
    public double side;
    public double height;
    public double length;

    public TriangularPrism(double side, double height, double length)
    {
        this.side = side;
        this.height = height;
        this.length = length;
    }
}

class VolumeCalculator
{
    public static void CubeVolume(Cube cube)
    {
        Console.WriteLine($"{Math.Pow(cube.side, 3):F3}");
    }

    public static void CylinderVolume(Cylinder cylinder)
    {
        Console.WriteLine($"{Math.PI * (cylinder.radius * cylinder.radius) * cylinder.height:F3}");
    }

    public static void TriangularPrismVolume(TriangularPrism prism)
    {
        Console.WriteLine($"{(prism.side * prism.height * prism.length) / 2:F3}");
    }

}

public class ShapesVolume
{
    public static void Main()
    {
        string data = string.Empty;
        while ((data = Console.ReadLine()) != "End")
        {
            string[] shapeInfo = data.Split();
            switch (shapeInfo[0])
            {
                case "Cube":
                    Cube currCube = new Cube(double.Parse(shapeInfo[1]));
                    VolumeCalculator.CubeVolume(currCube);
                    break;
                case "Cylinder":
                    Cylinder currCylinder = new Cylinder(double.Parse(shapeInfo[1]), double.Parse(shapeInfo[2]));
                    VolumeCalculator.CylinderVolume(currCylinder);
                    break;
                case "TrianglePrism":
                    TriangularPrism currTrianglePrism = new TriangularPrism(double.Parse(shapeInfo[1]), double.Parse(shapeInfo[2]), double.Parse(shapeInfo[3]));
                    VolumeCalculator.TriangularPrismVolume(currTrianglePrism);
                    break;
            }
        }
    }
}