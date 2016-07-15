using System;

public abstract class Shape
{
    public char side = '|';
    public abstract void Draw();
}

class Square : Shape
{
    int width;

    public Square(int width)
    {
        this.width = width;
    }

    public override void Draw()
    {
        Console.WriteLine($"{side}{new string('-', width)}{side}");
        for (int i = 0; i < width - 2; i++)
            Console.WriteLine($"{side}{new string(' ', width)}{side}");
        Console.WriteLine($"{side}{new string('-', width)}{side}");
    }
}

class Rectangle : Shape
{
    int width;
    int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"{side}{new string('-', width)}{side}");
        for (int i = 0; i < height - 2; i++)
            Console.WriteLine($"{side}{new string(' ', width)}{side}");
        Console.WriteLine($"{side}{new string('-', width)}{side}");
    }
}

public class CorDraw
{
    public CorDraw(Shape shape)
    {
        shape.Draw();
    }
}

public class DrawingTool
{
    public static void Main()
    {
        string typeOfShape = Console.ReadLine();
        Shape shape = null;

        if (typeOfShape.Equals("Square"))
        {
            int width = int.Parse(Console.ReadLine());
            shape = new Square(width);
        }

        if (typeOfShape.Equals("Rectangle"))
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            shape = new Rectangle(width, height);
        }

        shape.Draw();
    }
}