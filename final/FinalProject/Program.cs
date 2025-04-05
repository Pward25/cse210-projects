using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<MenuItem> LoadMenuFromFile(string filePath)
    {
        List<MenuItem> menu = new List<MenuItem>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    string type = parts[0].Trim();
                    string name = parts[1].Trim();
                    double price = double.Parse(parts[2].Trim());

                    switch (type)
                    {
                        case "Food":
                            bool isCombo = parts.Length > 3 && bool.Parse(parts[3].Trim());
                            menu.Add(new FoodItem(name, price, isCombo));
                            break;
                        case "Beverage":
                            string size = parts.Length > 3 ? parts[3].Trim() : "Small";
                            menu.Add(new BeverageItem(name, price, size));
                            break;
                        case "Dessert":
                            menu.Add(new DessertItem(name, price));
                            break;
                    }
                }
            }
        }
        return menu;
    }

    static void Main()
    {
        string filePath = "menu.txt";
        List<MenuItem> menu = LoadMenuFromFile(filePath);
        Order customerOrder = new Order();

        while (true)
        {
            Console.WriteLine("\nWelcome to the Restaurant Ordering System!");
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Place an Order");
            Console.WriteLine("3. View Your Order");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nRestaurant Menu:");
                    Console.WriteLine("--------------------------");
                    for (int i = 0; i < menu.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        menu[i].DisplayItem();
                    }
                    break;

                case "2":
                    Console.Write("Enter the item number to order: ");
                    if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= menu.Count)
                    {
                        MenuItem originalItem = menu[itemIndex - 1];
                        MenuItem itemToOrder = null;

                        if (originalItem is FoodItem food)
                        {
                            itemToOrder = new FoodItem(food.Name, food.BasePrice, food.IsCombo);

                            if (food.IsCombo)
                            {
                                Console.Write("Please select combo size (Small, Medium, Large): ");
                                string size = Console.ReadLine().Trim();
                                ((FoodItem)itemToOrder).SetComboSize(size);
                            }
                        }
                        else if (originalItem is BeverageItem bev)
                        {
                            itemToOrder = new BeverageItem(bev.Name, bev.BasePrice, bev.Size);
                        }
                        else if (originalItem is DessertItem des)
                        {
                            itemToOrder = new DessertItem(des.Name, des.BasePrice);
                        }

                        if (itemToOrder != null)
                        {
                            customerOrder.AddItem(itemToOrder);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Try again.");
                    }
                    break;


                case "3":
                    customerOrder.ShowOrder();
                    break;

                case "4":
                    Console.WriteLine("Thank you for visiting! Goodbye.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
