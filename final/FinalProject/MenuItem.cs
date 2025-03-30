using System;

abstract class MenuItem
{
    private string _name;
    private double _basePrice;

    public string Name
    {
        get { return _name; }
        protected set { _name = value; }
    }

    public double BasePrice
    {
        get { return _basePrice; }
        protected set { _basePrice = value > 0 ? value : 0; }
    }

    public MenuItem(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public abstract double CalculatePrice();

    public virtual void DisplayItem()
    {
        Console.WriteLine($"{Name} - ${CalculatePrice():0.00}");
    }
    
}
