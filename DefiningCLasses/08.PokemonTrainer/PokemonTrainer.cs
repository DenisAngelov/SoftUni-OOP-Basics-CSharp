using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

class Trainer
{
    public string name;
    public int ord;
    public int badges = 0;
    public List<Pokemon> pokemons = new List<Pokemon>();

    public Trainer(string name, int ord)
    {
        this.name = name;
        this.ord = ord;
    }

}

class Pokemon
{
    string name;
    public string element;
    public int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }

}

public class PokemonTrainer
{
    public static void Main()
    {
        string data = string.Empty;
        var participants = new Dictionary<string, Trainer>();
        int ord = 0;

        var trainers = new OrderedDictionary();

        while ((data= Console.ReadLine()) != "Tournament")
        {
            string[] info = data.Split();

            string trName = info[0];
            string pokName = info[1];
            string pokEle = info[2];
            int health = int.Parse(info[3]);

            if (!participants.ContainsKey(trName))
                participants.Add(trName, new Trainer(trName, ord));

            participants[trName].pokemons.Add(new Pokemon (pokName, pokEle, health));
            ord++;
        }

        while ((data = Console.ReadLine()) != "End")
        {
            foreach (var trainer in participants)
            {
                var currList = trainer.Value.pokemons;

                bool hasType = false;

                if (currList.Any(x => x.element == data))
                    hasType = true;

                if (!hasType)
                    currList.ForEach(x => x.health -= 10);
                else
                    trainer.Value.badges++;

                for (int i = 0; i < currList.Count; i++)
                {
                    if (currList[i].health < 0)
                        currList.RemoveAt(i);
                }
            }
        }

        var orderedParticipants = participants.OrderByDescending(x => x.Value.badges).ThenBy(x => x.Value.ord);

        foreach (var trainer in orderedParticipants)
            Console.WriteLine($"{trainer.Value.name} {trainer.Value.badges} {trainer.Value.pokemons.Count}");
    }
}