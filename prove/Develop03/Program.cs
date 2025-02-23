using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        Scripture _scripture = scriptureLibrary.GetRandomScripture();
        Random _random = new Random();
        string _input = "";

        while (_scripture.HasVisibleWords() && _input.ToLower() != "quit")
        {
            Console.Clear();
            _scripture.DisplayReference();
            _scripture.Display();
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            _input = Console.ReadLine();
            if (_input.ToLower() != "quit")
            {
                _scripture.HideWords(_random);  
            }
        }

        Console.Clear();
        _scripture.DisplayReference();
        _scripture.Display();
        Console.WriteLine("\nGood Luck.");
    }
}
