using System;
using System.Collections.Generic;

class Animal
{
    string name;
    string breed;

    public string Name => name;
    public string Breed => breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }
}

class AnimalsClinic
{
    public static List<Animal> healed = new List<Animal>();
    public static List<Animal> rehabilitated = new List<Animal>();
    public static int counter = 1;
    public static int healedAnimals = 0;
    public static int rehabilitatedAnimals = 0;

    public AnimalsClinic(Animal animal, string treatment)
    {
        if (treatment.Equals("heal"))
        {
            healed.Add(animal);
            Console.WriteLine($"Patient {counter}: [{animal.Name} ({animal.Breed})] has been healed!");
            counter++;
            healedAnimals++;
        }
        else
        {
            rehabilitated.Add(animal);
            Console.WriteLine($"Patient {counter}: [{animal.Name} ({animal.Breed})] has been rehabilitated!");
            counter++;
            rehabilitatedAnimals++;
        }
    }

}

public class AnimalClinic
{
    public static void Main()
    {
        string data = string.Empty;
        AnimalsClinic clinic;


        while ((data = Console.ReadLine()) != "End")
        {
            string[] animalInfo = data.Split();
            Animal currAnimal = new Animal(animalInfo[0], animalInfo[1]);
            clinic = new AnimalsClinic(currAnimal, animalInfo[2]);
        }

        data = Console.ReadLine();
        
        Console.WriteLine($"Total healed animals: {AnimalsClinic.healedAnimals}");
        Console.WriteLine($"Total rehabilitated animals: {AnimalsClinic.rehabilitatedAnimals}");

        if (data.Equals("heal"))
        {
            foreach (var animal in AnimalsClinic.healed)
                Console.WriteLine($"{animal.Name} {animal.Breed}");
        }
        else
        {
            foreach (var animal in AnimalsClinic.rehabilitated)
                Console.WriteLine($"{animal.Name} {animal.Breed}");
        }
    }
}