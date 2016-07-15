using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private double cost;

    public Product(string name, double cost)
    {
        this.Name = name;
        this.Cost = cost;
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
                throw new ArgumentException("Name cannot be empty");
            this.name = value;
        }
    }

    public double Cost
    {
        get
        {
            return this.cost;
        }

        private set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");
            this.cost = value;
        }
    }
}

class Person
{
    private string name;
    private double money;
    private List<string> products = new List<string>();

    public List<string> Products => this.products;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
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
                throw new ArgumentException("Name cannot be empty");
            this.name = value;
        }
    }

    public double Money
    {
        get
        {
            return this.money;
        }

        private set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");
            this.money = value;
        }
    }

    public void AddProduct(Product product)
    {
        if (this.money >= product.Cost)
        {
            this.money -= product.Cost;
            products.Add(product.Name);
            Console.WriteLine($"{this.name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.name} can't afford {product.Name}");
        }
    }

}

public class ShoppingSpree
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] peopleData = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        string[] productsData = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            foreach (string person in peopleData)
            {
                string[] personData = person.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(personData[0], double.Parse(personData[1])));
            }

            foreach (string product in productsData)
            {
                string[] productData = product.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Product(productData[0], double.Parse(productData[1])));
            }

            string buyProduct = string.Empty;

            while ((buyProduct = Console.ReadLine()) != "END")
            {
                string[] purchaseData = buyProduct.Split();

                Person currPerson = people.Find(person => person.Name.Equals(purchaseData[0]));
                Product currProduct = products.Find(product => product.Name.Equals(purchaseData[1]));
                currPerson.AddProduct(currProduct);
            }

            foreach (var person in people)
            {
                string currProducts = string.Empty;
                if (person.Products.Count == 0)
                    currProducts = "Nothing bought";
                else
                    currProducts = string.Join(", ", person.Products);
                Console.WriteLine($"{person.Name} - {currProducts}");
            }
        }
        catch (Exception ae)
        {
            Console.WriteLine(ae.Message);
        }

    }
}