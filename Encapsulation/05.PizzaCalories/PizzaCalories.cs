using System;
using System.Collections.Generic;

class PizzaCalories
{
    static void Main()
    {

        try
        {
            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] input = line.Split(' ');
                switch (input[0])
                {
                    case "Dough":
                        Dought dough = new Dought(input[1], input[2], double.Parse(input[3]));
                        Console.WriteLine(dough.ToString());
                        break;

                    case "Topping":
                        {
                            Topping topping = new Topping(input[1], double.Parse(input[2]));
                            Console.WriteLine(topping.ToString());
                            break;
                        }
                    case "Pizza":
                        {
                            Pizza mainPizza = new Pizza(input[1], int.Parse(input[2]));
                            string[] arguments = Console.ReadLine().Split(' ');
                            Dought mainDought = new Dought(arguments[1], arguments[2], double.Parse(arguments[3]));
                            mainPizza.Dought = mainDought;
                            for (int i = 0; i < int.Parse(input[2]); i++)
                            {
                                arguments = Console.ReadLine().Split(' ');
                                mainPizza.AddTopping(arguments[1], double.Parse(arguments[2]));

                            }
                            Console.WriteLine(mainPizza.ToString());
                            break;
                        }

                }

                line = Console.ReadLine();
            }
        }
        catch (ArgumentException exception)
        {

            Console.WriteLine(exception.Message);
        }
    }
}

class Dought
{
    private string flour;
    private string bakingType;
    private double weight;
    private double calories;

    public Dought(string flourType, string bakingTechnique, double weight)
    {
        this.Flour = flourType;
        this.BakingType = bakingTechnique;
        this.Weight = weight;
        SetCalories();
    }
    private string Flour
    {
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                throw new ArgumentException("Invalid type of dough.");
            this.flour = value;
        }
    }

    private string BakingType
    {
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                throw new ArgumentException("Invalid type of dough.");
            this.bakingType = value;
        }
    }

    private double Weight
    {
        set
        {
            if (value < 1 || value > 200)
                throw new ArgumentException("Dough weight should be in the range [1..200].");

            this.weight = value;
        }
    }

    public double Calories { get { return this.calories; } }

    private void SetCalories()
    {
        double mod1;
        double mod2;

        switch (flour.ToLower())
        {
            case "white": mod1 = 1.5; break;
            case "wholegrain": mod1 = 1.0; break;
            default: mod1 = 1.0; break;
        }

        switch (bakingType.ToLower())
        {
            case "crispy": mod2 = 0.9; break;
            case "chewy": mod2 = 1.1; break;
            case "homemade": mod2 = 1.0; break;
            default: mod2 = 1.0; break;
        }

        this.calories = 2 * weight * mod1 * mod2;
    }

    public override string ToString()
    {
        return string.Format("{0:F2}", this.calories);
    }
}

class Topping
{
    private string type;
    private double weight;
    private double calories;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
        SetCalories();
    }
    private string Type
    {
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                throw new ArgumentException(string.Format("Cannot place {0} on top of your pizza.", value));

            this.type = value;
        }
    }

    private double Weight
    {
        set
        {
            if (value < 1 || value > 50)
                throw new ArgumentException(string.Format("{0} weight should be in the range [1..50].", type));
            this.weight = value;
        }
    }

    public double Calories
    {
        get { return this.calories; }

    }

    private void SetCalories()
    {
        double modifier;
        switch (type.ToLower())
        {
            case "meat": modifier = 1.2; break;
            case "veggies": modifier = 0.8; break;
            case "cheese": modifier = 1.1; break;
            case "sauce": modifier = 0.9; break;
            default: modifier = 1; break;
        }
        calories = 2 * weight * modifier;
    }

    public override string ToString()
    {
        return string.Format("{0:F2}", this.calories);
    }
}

class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dought dought;
    private double calories;

    public Pizza(string name, int toppings)
    {
        if (toppings < 0 || toppings > 10)
            throw new ArgumentException("Number of toppings should be in range [0..10].");

        this.Name = name;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            this.name = value;
        }
    }
    public double Calories { get { return this.Calories; } }

    public Dought Dought
    {
        set
        {
            this.dought = value;
            calories += value.Calories;
        }
    }

    public void AddTopping(string type, double weight)
    {
        Topping currToping = new Topping(type, weight);
        toppings.Add(currToping);
        calories += currToping.Calories;
    }

    public override string ToString()
    {
        return string.Format("{0} - {1:F2} Calories.", this.name, this.calories);
    }
}