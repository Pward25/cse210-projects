class Order
{
    private List<MenuItem> _orderItems = new List<MenuItem>();
    private const double SalesTaxRate = 0.06;

    public void AddItem(MenuItem item)
    {
        _orderItems.Add(item);
        Console.WriteLine($"{item.Name} added to your order.");
    }

    public void ShowOrder()
    {
        Console.WriteLine("\nYour Order:");
        Console.WriteLine("--------------------------");
        double subtotal = 0;
        foreach (var item in _orderItems)
        {
            item.DisplayItem();
            subtotal += item.CalculatePrice();
        }

        double tax = subtotal * SalesTaxRate;
        double total = subtotal + tax;

        Console.WriteLine("--------------------------");
        Console.WriteLine($"Subtotal: ${subtotal:0.00}");
        Console.WriteLine($"Sales Tax (6%): ${tax:0.00}");
        Console.WriteLine($"Total Amount: ${total:0.00}\n");
    }
}
