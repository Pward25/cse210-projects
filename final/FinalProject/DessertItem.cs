class DessertItem : MenuItem
{
    public DessertItem(string name, double basePrice)
        : base(name, basePrice) { }

    public override double CalculatePrice()
    {
        return BasePrice;
    }
}
