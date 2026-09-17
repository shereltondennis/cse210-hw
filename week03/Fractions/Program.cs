using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify Constructors & Representations
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Verify Getters and Setters
        Fraction f5 = new Fraction();
        f5.SetTop(6);
        f5.SetBottom(7);
        Console.WriteLine($"\nModified fraction top: {f5.GetTop()}");
        Console.WriteLine($"Modified fraction bottom: {f5.GetBottom()}");
        Console.WriteLine($"Modified fraction string: {f5.GetFractionString()}");
    }
}