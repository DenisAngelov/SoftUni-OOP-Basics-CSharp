using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

}

class Family
{
    public List<Person> family = new List<Person>();

    public Family()
    {

    }

    public void AddMember(Person newMember)
    {
        family.Add(newMember);
    }

    public Person GetOldestMember()
    {
        return family.OrderByDescending(x => x.age).First();
    }

}

public class OldestFamilyMember
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int numberOfMembers = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int member = 0; member < numberOfMembers; member++)
        {
            string[] memberDetails = Console.ReadLine().Split();
            Person newMember = new Person(memberDetails[0], int.Parse(memberDetails[1]));
            family.AddMember(newMember);
        }

        Person oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.name} {oldestMember.age}");
    }
}