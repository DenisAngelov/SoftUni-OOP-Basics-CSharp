using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

public class Pizza
{
    string name;
    int group;
    static SortedDictionary<int, List<string>> pizzaMenu = new SortedDictionary<int, List<string>>();
    

    public Pizza(int group, string name)
    {
        if (!pizzaMenu.ContainsKey(group))
            pizzaMenu.Add(group, new List<string>());

        this.group = group;
        this.name = name;

        pizzaMenu[this.group].Add(this.name);
    }

    public static SortedDictionary<int, List<string>> GetPizzaMenu()
    {
        return pizzaMenu;
    }

}

public class PizzaTime
{
    public static void Main()
    {
        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
        if (!containsMethod)
        {
            throw new Exception();
        }

        Regex rgx = new Regex(@"(\d+)(\w+)");
        string[] pizzaData = Console.ReadLine().Split();

        foreach (var pizza in pizzaData)
        {
            Match findPizza = rgx.Match(pizza);
            if (findPizza.Success)
            {
                Pizza currPizza = new Pizza(int.Parse(findPizza.Groups[1].Value), findPizza.Groups[2].Value);
            }
        }

        var pizzaMenu = Pizza.GetPizzaMenu();
        foreach (var pizza in pizzaMenu)
            Console.WriteLine($"{pizza.Key} - {string.Join(", ", pizza.Value)}");
    }
}