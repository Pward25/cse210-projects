using System;

class Program
{
    static void Main(string[] args)
    {
    
        Console.Write("Input grade percentage: ");
        string userGrade = Console.ReadLine();
        int number = int.Parse(userGrade);



        if (number >= 90)
        {
            Console.WriteLine("Letter Grade: A");
        }
        else if (number >= 80)
        {
            Console.WriteLine("Letter Grade: B");
        }
        else if (number >= 70)
        {
            Console.WriteLine("Letter Grade: C");
        }
        else if (number >= 60)
        {
            Console.WriteLine("Letter Grade: D");
        }
        else
        {
            Console.WriteLine("Letter Grade: F");
        }

        if (number < 70)
        {
            Console.WriteLine("Failed! Better luck next time!");
        }
        else
        {
            Console.WriteLine("Passed. Great work!!");
        }
    }

}  