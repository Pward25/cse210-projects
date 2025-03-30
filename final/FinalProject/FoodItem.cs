class FoodItem : MenuItem
{
    public bool IsCombo { get; set; }
    public string ComboSize { get; set; }

    public FoodItem(string name, double basePrice, bool isCombo)
        : base(name, basePrice)
    {
        IsCombo = isCombo;
    }

    public override double CalculatePrice()
    {
        double price = BasePrice;
        
        // Apply discount for combo if the user selected it
        if (IsCombo)
        {
            if (ComboSize == "Medium")
                price *= 0.95; // Example for Medium combo discount
            else if (ComboSize == "Large")
                price *= 0.90; // Example for Large combo discount
            else
                price *= 0.9; // Small combo or default combo discount
        }

        return price;
    }

    public void SetComboSize(string size)
    {
        ComboSize = size;
    }
}
