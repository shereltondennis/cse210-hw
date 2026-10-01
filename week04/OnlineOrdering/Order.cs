using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;

        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Packing Label");
        label.AppendLine("-------------");

        foreach (Product product in _products)
        {
            label.AppendLine($"{product.GetName()} x {product.GetQuantity()}");
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Shipping Label");
        label.AppendLine("--------------");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetFormattedAddress());
        return label.ToString();
    }
}
