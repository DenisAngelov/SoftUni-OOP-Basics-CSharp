using System;
using System.Collections.Generic;
using System.Linq;

class InvalidSongSecondsException : InvalidSongLengthException
{
    private const string Message = "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException() : base(Message)
    {
    }

    public InvalidSongSecondsException(string message) : base(message)
    {
    }
}

class InvalidSongMinutesException : InvalidSongLengthException
{
    private const string Message = "Song minutes should be between 0 and 14.";

    public InvalidSongMinutesException() : base(Message)
    {
    }

    public InvalidSongMinutesException(string message) : base(message)
    {
    }
}

class InvalidSongLengthException : InvalidSongException
{
    private const string Message = "Invalid song length.";

    public InvalidSongLengthException() : base(Message)
    {
    }

    public InvalidSongLengthException(string message) : base(message)
    {
    }
}

class InvalidSongNameException : InvalidSongException
{
    private const string Message = "Song name should be between 3 and 30 symbols.";

    public InvalidSongNameException() : base(Message)
    {
    }

    public InvalidSongNameException(string message) : base(message)
    {
    }
}

class InvalidArtistNameException : InvalidSongException
{
    private const string Message = "Artist name should be between 3 and 20 symbols.";

    public InvalidArtistNameException() : base(Message)
    {
    }

    public InvalidArtistNameException(string message) : base(message)
    {
    }
}

class InvalidSongException : Exception
{
    private const string Message = "Invalid song.";

    public InvalidSongException() : base(Message)
    {
    }

    public InvalidSongException(string message) : base(message)
    {
    }
}

class Song
{
    private int seconds;
    private int minutes;
    private string artistName;
    private string songName;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public string SongName
    {
        get
        {
            return songName;
        }

        set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException();
            songName = value;
        }
    }

    public string ArtistName
    {
        get
        {
            return artistName;
        }

        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();

            artistName = value;
        }
    }

    public int Minutes
    {
        get
        {
            return minutes;
        }

        set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            
            minutes = value;
        }
    }

    public int Seconds
    {
        get
        {
            return seconds;
        }

        set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            
            this.seconds = value;
        }
    }
}

public class OnlineRadioDatabase
{
    public static void Main()
    {
        List<Song> playlist = new List<Song>();
        int numOfSongs = int.Parse(Console.ReadLine());

        for (int input = 0; input < numOfSongs; input++)
        {
            string[] songDetails = Console.ReadLine().Split(';');
            try
            {
                int[] time = songDetails[2].Split(':').Select(int.Parse).ToArray();
                Song song = new Song(songDetails[0], songDetails[1], time[0], time[1]);
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }

        int totalMinutes = playlist.Sum(x => x.Minutes);
        int totalSeconds = playlist.Sum(x => x.Seconds);

        totalSeconds += totalMinutes * 60;

        int finalMinutes = totalSeconds / 60;
        int finalSeconds = totalSeconds % 60;
        int finalHours = finalMinutes / 60;

        finalMinutes %= 60;

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {finalHours}h {finalMinutes}m {finalSeconds}s");
    }
}