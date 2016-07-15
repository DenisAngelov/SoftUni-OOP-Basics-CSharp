using System;
using System.Text;

class Book
{
    protected string title;
    protected string author;
    protected double price;

    public Book(string author, string title, double price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Title
    {
        get
        {
            return title;
        }

        protected set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");

            title = value;
        }
    }

    public string Author
    {
        get
        {
            return author;
        }

        protected set
        {
            if (value.Contains(" "))
            {
                string[] names = value.Split();

                if (char.IsDigit(names[1][0]))
                    throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    public virtual double Price
    {
        get
        {
            return price;
        }

        protected set
        {
            if (value <= 0)
                throw new ArgumentException("Price not valid!");

            price = value;
        }
    }

    public override string ToString()
    {
        string result = string.Empty;
        result += $"Type: {this.GetType().Name}";
        result += $"\nTitle: {this.Title}";
        result += $"\nAuthor: {this.Author}";
        result += $"\nPrice: {this.Price:F1}\n";

        return result;
    }

}

class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, double price) : base(author, title, price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public override double Price
    {
        get
        {
            return base.Price * 1.3;
        }
    }

}

public class BookShop
{
    public static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Title not valid!");
        }
    }
}