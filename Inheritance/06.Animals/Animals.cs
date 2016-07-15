using System;
using System.Collections.Generic;

class Animal
{
    protected string name;
    protected int age;
    protected string gender;

    public string Name
    {
        get
        {
            return this.name;
        }

        protected set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid input!");

            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }

        protected set
        {
            if (value < 0)
                throw new ArgumentException("Invalid input!");

            this.age = value;
        }
    }

    public string Gender
    {
        get
        {
            return this.gender;
        }

        protected set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid input!");

            gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public virtual string produceSound()
    {
        return "Not implemented!";
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Gender}";
    }

}

class Dog : Animal
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string produceSound()
    {
        return "BauBau";
    }

}

class Cat : Animal
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string produceSound()
    {
        return "MiauMiau";
    }

}

class Frog : Animal
{
    public Frog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string produceSound()
    {
        return "Frogggg";
    }
}

class Kitten : Animal
{
    public Kitten(string name, int age) : base(name, age , "Female")
    {
    }

    public override string produceSound()
    {
        return "Miau";
    }
}

class Tomcat : Animal
{
    public Tomcat(string name, int age) : base(name, age, "Male")
    {
    }

    public override string produceSound()
    {
        return "Give me one million b***h";
    }
}

public class Animals
{
    public static void Main()
    {
        string animal = string.Empty;
        var animals = new List<Animal>();

        try
        {
            while ((animal = Console.ReadLine()) != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split();
                int age = int.Parse(animalData[1]);
                
                switch (animal)
                {
                    case "Dog": animals.Add(new Dog(animalData[0], age, animalData[2])); break;
                    case "Cat": animals.Add(new Cat(animalData[0], age, animalData[2])); break;
                    case "Frog": animals.Add(new Frog(animalData[0], age, animalData[2])); break;
                    case "Kitten": animals.Add(new Kitten(animalData[0], age)); break;
                    case "Tomcat": animals.Add(new Tomcat(animalData[0], age)); break;
                }
            }

            foreach (var anim in animals)
            {
                Console.WriteLine(anim.GetType());
                Console.WriteLine(anim);
                Console.WriteLine(anim.produceSound());
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}