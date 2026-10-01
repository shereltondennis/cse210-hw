using System;

public class Product
{
    private string _name;
    private decimal _price;
    private int _quantity;

    public Product(string name, decimal price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public decimal GetPrice()
    {
        return _price;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public decimal GetTotalPrice()
    {
        return _price * _quantity;
    }
}
