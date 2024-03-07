using System.Diagnostics;

namespace BinarySearchController;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---- Binary Search Controller ----");
        
        // Menu

        var input = "";
        var amount = 25;
        long target = 999995642;
        while (input != "4")
        {
            Menu();
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Amount of times to run: ");
                    amount = Convert.ToInt32(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Target Value: ");
                    // parse to long
                    target = Convert.ToInt64(Console.ReadLine());
                    break;
                case "3":
                    Console.WriteLine("Running Benchmark");
                    RunBenchmark(amount, target);
                    break;
                case "4":
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
        
    }

    private static void RunBenchmark(int amount, long target)
    {
        for (var i = 0; i < amount; i++)
        {
            string[] args = { "binary", target.ToString(), i.ToString() };
            Process.Start(FilePaths.SEARCH_HANDLER, args);
            Thread.Sleep(100);
        }
        
        for (var i = 0; i < amount; i++)
        {
            string[] args = { "recognising", target.ToString(), i.ToString() };
            Process.Start(FilePaths.SEARCH_HANDLER, args);
            Thread.Sleep(100);
        }
        
        for (var i = 0; i < amount; i++)
        {
            string[] args = { "forgetful", target.ToString(), i.ToString() };
            Process.Start(FilePaths.SEARCH_HANDLER, args);
            Thread.Sleep(100);
        }
        
        for (var i = 0; i < amount; i++)
        {
            string[] args = { "recursive", target.ToString(), i.ToString() };
            Process.Start(FilePaths.SEARCH_HANDLER, args);
            Thread.Sleep(100);
        }
    }

    static void Menu()
    {
        Console.WriteLine("1. Amount of times to run: ");
        Console.WriteLine("2. Target Value: ");
        Console.WriteLine("3. Run Benchmark");
        Console.WriteLine("5. Exit");
    }

}



/*
using System.Diagnostics;
using BinarySearchController;

Console.WriteLine("---- Binary Search Controller ----");



/*
Console.WriteLine("---- Running Binary Search ----");

for (int i = 0; i < 100; i++)
{
    Process.Start(FilePaths.BINARY_SEARCH);
    // Wait 100ms
    Thread.Sleep(100);
}

Console.WriteLine("---- Running Forgetful Binary Search ----");

for (int i = 0; i < 100; i++)
{
    Process.Start(FilePaths.FORGETFUL_BINARY_SEARCH);
    // Wait 100ms
    Thread.Sleep(100);
}

Console.WriteLine("---- Running Recognising Equality Binary Search ----");

for (int i = 0; i < 100; i++)
{
    Process.Start(FilePaths.RECOGNISING_EQUALITY_SEARCH);
    // Wait 100ms
    Thread.Sleep(100);
}

Console.WriteLine("---- Running Recursive Binary Search ----");

for (int i = 0; i < 100; i++)
{
    Process.Start(FilePaths.RECURSIVE_BINARY_SEARCH);
    // Wait 100ms
    Thread.Sleep(100);
}#1#
*/

