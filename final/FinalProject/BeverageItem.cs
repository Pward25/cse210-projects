class BeverageItem : MenuItem
{
    public string Size { get; set; }

    public BeverageItem(string name, double basePrice, string size)
        : base(name, basePrice)
    {
        Size = size;
    }

    public override double CalculatePrice()
    {
        return Size switch
        {
            "Medium" => BasePrice * 1.2,
            "Large" => BasePrice * 1.5,
            _ => BasePrice
        };
    }
}
