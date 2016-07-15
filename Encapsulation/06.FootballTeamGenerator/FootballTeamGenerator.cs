using System;
using System.Collections.Generic;
using System.Linq;

class Team
{
    private string name;
    private List<Player> players = new List<Player>();

    public decimal Rating
    {
        get
        {
            if (players.Count == 0)
                return 0;
            else
                return Math.Ceiling(players.Sum(x => x.Skill) / players.Count);
        }
    }

    public Team(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A name should not be empty.");
            this.name = value;
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string name)
    {
        int index = players.FindIndex(player => player.Name.Equals(name));

        if (index >= 0)
            players.RemoveAt(index);
        else
            Console.WriteLine($"Player {name} is not in {this.name} team.");
    }

}

class Player
{
    private string name;
    private decimal endurance;
    private decimal sprint;
    private decimal dribble;
    private decimal passing;
    private decimal shooting;

    public decimal Skill => Math.Ceiling((endurance + sprint + dribble + passing + shooting) / 5);

    public Player(string name, decimal endurance, decimal sprint, decimal dribble, decimal passing, decimal shooting)
    {
        this.name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A name should not be empty.");
            this.name = value;
        }
    }

    private decimal Endurance
    {
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Endurance should be between 0 and 100.");
            this.endurance = value;
        }
    }

    private decimal Sprint
    {
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Sprint should be between 0 and 100.");
            this.sprint = value;
        }
    }

    private decimal Dribble
    {
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Dribble should be between 0 and 100.");
            this.dribble = value;
        }
    }

    private decimal Passing
    {
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Passing should be between 0 and 100.");
            this.passing = value;
        }
    }

    private decimal Shooting
    {
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Shooting should be between 0 and 100.");
            this.shooting = value;
        }
    }
}

public class FootballTeamGenerator
{
    public static void Main()
    {
        var teams = new Dictionary<string, Team>();
        
        string data = string.Empty;

        while ((data = Console.ReadLine()) != "END")
        {
            string[] dataDetails = data.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            switch (dataDetails[0])
            {
                case "Team":
                    try
                    {
                        teams.Add(dataDetails[1], new Team(dataDetails[1]));
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        continue;
                    }
                    break;
                case "Add":
                    if (!teams.ContainsKey(dataDetails[1]))
                        Console.WriteLine($"Team {dataDetails[1]} does not exist.");
                    else
                    {
                        try
                        {
                            Player currPlayer = new Player(dataDetails[2], decimal.Parse(dataDetails[3]), decimal.Parse(dataDetails[4]), decimal.Parse(dataDetails[5]), decimal.Parse(dataDetails[6]), decimal.Parse(dataDetails[7]));
                            teams[dataDetails[1]].AddPlayer(currPlayer);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            continue;
                        }
                    }
                    break;
                case "Remove":
                    try
                    {
                        teams[dataDetails[1]].RemovePlayer(dataDetails[2]);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        continue;
                    }
                    break;
                case "Rating":
                    if (!teams.ContainsKey(dataDetails[1]))
                        Console.WriteLine($"Team {dataDetails[1]} does not exist.");
                    else
                        Console.WriteLine($"{dataDetails[1]} - {teams[dataDetails[1]].Rating}");
                    break;
            }
        }
    }
}