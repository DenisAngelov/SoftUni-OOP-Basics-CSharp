using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    string name;
    int age;
    string occupation;

    public int Age => age;

    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    public override string ToString()
    {
        return $"{name} - age: {age}, occupation: {occupation}";
    }

}

public class PrintPeople
{
    public static void Main()
    {
        var people = new List<Person>();
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "END")
        {
            string[] personInfo = data.Split();
            people.Add(new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
        }

        foreach (var person in people.OrderBy(x => x.Age))
            Console.WriteLine(person.ToString());
    }
}