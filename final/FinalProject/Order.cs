using System;
using System.Collections.Generic;

class Order
{
    private List<MenuItem> _orderItems = new List<MenuItem>();

    public void AddItem(MenuItem item)
    {
        _orderItems.Add(item);
        Console.WriteLine($"{item.Name} added to your order.");
    }

    public void ShowOrder()
    {
        Console.WriteLine("\nYour Order:");
        Console.WriteLine("--------------------------");
        double total = 0;
        foreach (var item in _orderItems)
        {
            item.DisplayItem();
            total += item.CalculatePrice();
        }
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Total Amount: ${total:0.00}\n");
    }
}
