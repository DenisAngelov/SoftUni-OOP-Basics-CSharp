using System;

class Person
{
    protected string name;
    protected int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        protected set
        {
            if (value.Length < 3)
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            this.name = value;
        }

    }

    public virtual int Age
    {
        get
        {
            return this.age;
        }

        protected set
        {
            if (value < 0)
                throw new ArgumentException("Age must be positive!");
            this.age = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }

}

class Child : Person
{

    public Child(string name, int age) : base(name, age)
    {
        base.Name = name;
        this.Age = age;    
    }

    public override int Age
    {
        get
        {
            return base.Age;
        }

        protected set
        {
            if (value > 15) 
                throw new ArgumentException("Child's age must be less than 15!");
            base.Age = value;
        }
    }
}

public class ClassPerson
{
    public static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}