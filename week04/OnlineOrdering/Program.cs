using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street, Sinker", "Montserrado county", "Monrovia Liberia", "84606");
        Customer customer1 = new Customer("Sinker 12 street", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", 89.99m, 1));
        order1.AddProduct(new Product("Mouse", 24.50m, 2));
        order1.AddProduct(new Product("Monitor", 199.99m, 1));

        Address address2 = new Address("Center Street", "Center Monrovia", "ID", "83440");
        Customer customer2 = new Customer("Eli Johnson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Stand", 39.99m, 1));
        order2.AddProduct(new Product("USB Hub", 34.50m, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}
