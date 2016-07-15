using System;
using System.Collections.Generic;
using System.Linq;

public class Rectangle
{
    string id;
    float width;
    float height;
    float x;
    float y;

    public string ID => id;

    public Rectangle(params string[] details)
    {
        float[] data = details.Skip(1).Select(float.Parse).ToArray();
        id = details[0];
        width = data[0];
        height = data[1];
        x = data[2];
        y = data[3];
    }
    
    public string isIntersecting(Rectangle rect)
    {
        if (x + width < rect.x || rect.x + rect.width < x || y + height < rect.y || rect.y + rect.height < y)
            return "false";
        else
            return "true";
    }

}

public class RectangleIntersection
{
    public static void Main()
    {
        var rects = new Dictionary<string, Rectangle>();
        int[] rectDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int numOfRects = rectDetails[0];
        int numOfInters = rectDetails[1];

        for (int rect = 0; rect < numOfRects; rect++)
        {
            string[] data = Console.ReadLine().Split();
            Rectangle currRect = new Rectangle(data);
            rects.Add(currRect.ID, currRect);
        }

        for (int inters = 0; inters < numOfInters; inters++)
        {
            string[] data = Console.ReadLine().Split();
            Console.WriteLine(rects[data[0]].isIntersecting(rects[data[1]]));
        }
    }
}