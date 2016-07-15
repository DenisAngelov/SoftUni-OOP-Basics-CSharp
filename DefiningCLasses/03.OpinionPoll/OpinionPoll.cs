using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string name;
    public int age;

    public Person(string personName, int personAge)
    {
        name = personName;
        age = personAge;
    }

    public Person()
    {

    }

    public override string ToString()
    {
        return $"{name} - {age}";
    }

}

public class OpinionPoll
{
    public static void Main()
    {
        int numOfInputs = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int input = 0; input < numOfInputs; input++)
        {
            string[] data = Console.ReadLine().Split();
            people.Add(new Person(data[0], int.Parse(data[1])));
        }

        foreach (var person in people.OrderBy(x => x.age > 30).ThenBy(x => x.name))
        {
            if (person.age > 30)
                Console.WriteLine(person);
        }

    }
}