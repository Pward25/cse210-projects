using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string command = "";

        do
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to your Journal. Please choose from the options below:");
            Console.WriteLine("1. Add entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Load Entry");
            Console.WriteLine("4. Save Entry");
            Console.WriteLine("5. Exit");
            Console.Write("Enter here: ");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    journal.AddEntry();  
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the filename to load entries: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case "4":
                    Console.Write("Enter the filename to save entries: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case "5":
                    Console.WriteLine("Exiting the journal. Have a great day!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (command != "5");
    }
}
