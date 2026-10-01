using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering Program");
        Console.WriteLine("======================");

        Address shippingAddress = new Address("123 Main Street", "Provo", "UT", "84606");
        Customer customer = new Customer("Ava Anderson", shippingAddress);

        Order order = new Order(customer);
        order.AddProduct(new Product("Mechanical Keyboard", "Wireless keyboard with blue switches", 89.99m), 1);
        order.AddProduct(new Product("USB-C Hub", "7-port hub for laptops", 34.50m), 2);
        order.AddProduct(new Product("Laptop Stand", "Aluminum adjustable stand", 49.00m), 1);

        order.DisplaySummary();
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFormattedAddress()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name
    {
        get { return name; }
    }

    public Address Address
    {
        get { return address; }
    }
}

class Product
{
    private string name;
    private string description;
    private decimal price;
    private int quantity;

    public Product(string name, string description, decimal price)
    {
        this.name = name;
        this.description = description;
        this.price = price;
        this.quantity = 1;
    }

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public decimal Price
    {
        get { return price; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public decimal GetTotalPrice()
    {
        return price * quantity;
    }
}

class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product, int quantity)
    {
        product.Quantity = quantity;
        products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;

        foreach (Product product in products)
        {
            total += product.GetTotalPrice();
        }

        return total;
    }

    public void DisplaySummary()
    {
        Console.WriteLine($"Customer: {customer.Name}");
        Console.WriteLine($"Shipping to: {customer.Address.GetFormattedAddress()}");
        Console.WriteLine();
        Console.WriteLine("Items:");

        foreach (Product product in products)
        {
            Console.WriteLine($"- {product.Quantity} x {product.Name} (${product.Price:F2} each) = ${product.GetTotalPrice():F2}");
        }

        Console.WriteLine();
        Console.WriteLine($"Total: ${GetTotalCost():F2}");
    }
}
