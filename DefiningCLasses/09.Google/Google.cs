using System;
using System.Collections.Generic;

class Person
{
    public string name;
    public Company company = new Company();
    public List<Pokemon> pokemons = new List<Pokemon>();
    public List<Parent> parents = new List<Parent>();
    public List<Child> children = new List<Child>();
    public Car car = new Car();

    public Person(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        string newLine = "\n";
        

        string pokemon = string.Empty;
        string parent = string.Empty;
        string child = string.Empty;

        if (pokemons.Count != 0)
            pokemon = "\n" + string.Join("\n", pokemons);
        if (parents.Count != 0)
            parent = "\n" + string.Join("\n", parents);
        if (children.Count != 0)
            child = "\n" + string.Join("\n", children); 

        return string.Format("{0}{1}Company:{2}{1}Car:{3}{1}Pokemon:{4}{1}Parents:{5}{1}Children:{6}"
            , name
            , newLine
            , company.ToString()
            , car.ToString()
            , pokemon
            , parent
            , child);
    }
}

class Company
{
    public string name;
    public string department;
    public float salary;

    public Company(string name, string department, float salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public Company()
    {

    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(name))
            return "";
        return string.Format($"\n{name} {department} {salary:F2}", name, department, salary);
    }

}

class Pokemon
{
    public string name;
    public string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{name} {type}";
    }

}

class Parent
{
    public string name;
    public string birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{name} {birthday}";
    }

}

class Child
{
    public string name;
    public string birthday;

    public Child(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{name} {birthday}";
    }

}

class Car
{
    public string model;
    public string speed;

    public Car(string model, string speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public Car()
    {

    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(model))
            return "";
        return $"\n{model} {speed}";
    }

}

public class Google
{
    public static void Main()
    {
        string data = string.Empty;
        var people = new Dictionary<string, Person>();

        while ((data = Console.ReadLine()) != "End")
        {
            string[] details = data.Split();
            string name = details[0];

            if (!people.ContainsKey(name))
                people.Add(name, new Person(name));

            switch (details[1])
            {
                case "company": people[name].company = new Company(details[2], details[3], float.Parse(details[4])); break;
                case "pokemon": people[name].pokemons.Add(new Pokemon(details[2], details[3])); break;
                case "parents": people[name].parents.Add(new Parent(details[2], details[3])); break;
                case "children": people[name].children.Add(new Child(details[2], details[3])); break;
                case "car": people[name].car = new Car(details[2], details[3]); break;
            }

        }

        data = Console.ReadLine();
        Console.WriteLine(people[data].ToString());
    }
}