﻿using System;
using System.Reflection;

class Person
{
    public string name;
    public int age;

    public Person() : this (0)
    {
        name = "No name";
        age = 1;
    }

    public Person(int newAge) : this(null, 0)
    {
        name = "No name";
        age = newAge;
    }

    public Person(string newName, int newAge)
    {
        name = newName;
        age = newAge;
    }

    
}

public class CreatingConstructors
{
    public static void Main()
    {
        Type personType = typeof(Person);
        ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
        ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
        ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
        bool swapped = false;
        if (nameAgeCtor == null)
        {
            nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
            swapped = true;
        }

        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
        Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
        Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

        Console.WriteLine("{0} {1}", basePerson.name, basePerson.age);
        Console.WriteLine("{0} {1}", personWithAge.name, personWithAge.age);
        Console.WriteLine("{0} {1}", personWithAgeAndName.name, personWithAgeAndName.age);

    }
}