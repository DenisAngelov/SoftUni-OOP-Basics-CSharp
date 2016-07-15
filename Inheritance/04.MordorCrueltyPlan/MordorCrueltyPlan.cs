using System;
using System.Collections.Generic;

class FoodFactory
{
    public static Food MakeFood(string food)
    {
        switch (food)
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushrooms": return new Mushrooms();
            default: return new DefaultFood();
        }
    }
}

abstract class Food
{
    protected int points;

    public Food(int points)
    {
        this.points = points;
    }

    public int GetHappinessPoints()
    {
        return this.points;
    }
}

class Cram : Food
{
    public Cram() : base(2)
    {
    }
}

class Lembas : Food
{
    public Lembas() : base(3)
    {
    }
}

class Apple : Food
{
    public Apple() : base(1)
    {
    }
}

class Melon : Food
{
    public Melon() : base(1)
    {
    }
}

class HoneyCake : Food
{
    public HoneyCake() : base(5)
    {
    }
}

class Mushrooms : Food
{
    public Mushrooms() : base(-10)
    {
    }
}

class DefaultFood : Food
{
    public DefaultFood() : base(-1)
    {
    }
}

class MoodFactory
{
    public static Mood GetCorrespondingMood(int moodFactor)
    {
        if (moodFactor < -5)
            return new Angry();
        else if (moodFactor <= 0)
            return new Sad();
        else if (moodFactor <=15)
            return new Happy();
        else
            return new JavaScript();
    }
}

abstract class Mood
{
    private string mood;

    public Mood(string mood)
    {
        this.mood = mood;
    }

    public string GetMood()
    {
        return this.mood;
    }

}

class Sad : Mood
{
    public Sad() : base("Sad")
    {
    }
}

class Angry : Mood
{
    public Angry() : base("Angry")
    {
    }
}

class Happy : Mood
{
    public Happy() : base("Happy")
    {
    }
}

class JavaScript : Mood
{
    public JavaScript() : base("JavaScript")
    {
    }
}

public class MordorCrueltyPlan
{
    public static void Main()
    {
        string[] foodsInput = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        var foods = new List<Food>();

        foreach (var food in foodsInput)
            foods.Add(FoodFactory.MakeFood(food.ToLower()));

        int moodFactor = 0;

        foreach (var food in foods)
            moodFactor += food.GetHappinessPoints();

        Console.WriteLine(moodFactor);
        Console.WriteLine(MoodFactory.GetCorrespondingMood(moodFactor));

    }
}