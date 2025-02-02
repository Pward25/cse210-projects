using System;
using System.IO;


public class Journal
{
    private List<string> entries;
    public Journal()
    {
       entries = new List<string>();
    }
    public void AddEntry()
{
 
    string randomPrompt = Generator.GetRandomPrompt();
    
    Console.WriteLine($"Prompt: {randomPrompt}");
    Console.Write("Your response: ");
    string userEntry = Console.ReadLine();

    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

    string entry = $"Date: {currentDate}\nPrompt: {randomPrompt}\nResponse: {userEntry}";

    entries.Add(entry);
}

        
    public void DisplayEntries()
    {
        Console.WriteLine("Your Journal Entries:");
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"{entries[i]}");
        }
        
    }
    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, entries);
        Console.WriteLine("Entries saved.");
        entries.Clear();
    }
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        entries = new List<string>(File.ReadAllLines(filename));
        Console.WriteLine($"Entries loaded from {filename}"); 
    } 


}