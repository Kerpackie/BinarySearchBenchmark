namespace BenchmarkLib;

public class Benchmark
{
    public const int TARGET = 999995642;
    public const string PATH = "C:\\Users\\Cillian\\Desktop\\BinSearch";
    public const string INPUT = PATH + "\\sorted_unique_numbers.txt";
    public const string OUTPUT_PATH = PATH + "\\benchmark_results.csv";
    
    
    public static List<long> LoadUniqueNumbersFromFile()
    {
        var uniqueNumbers = new List<long>();
        using var reader = new StreamReader(INPUT);
        while (reader.ReadLine() is { } line)
        {
            uniqueNumbers.Add(long.Parse(line));
        }

        return uniqueNumbers;
    }
    
    public static void OutputResultsToFile(long ticks, long ms, int comparisons, string algorithm, string iteration,
        long valueFound)
    {
        using var writer = new StreamWriter(OUTPUT_PATH, true);
        
        // Write in CSV Format, algorithm, iteration, ticks, ms, comparisons
        try
        {
            writer.WriteLine($"{algorithm},{iteration},{ticks},{ms},{comparisons},{valueFound}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Thread.Sleep(1000);
            writer.WriteLine($"{algorithm},{iteration},{ticks},{ms},{comparisons},{valueFound}");
        }
        
        //writer.WriteLine($"{algorithm} iteration {iteration} took: {ticks} ticks - {ms} ms - {comparisons} comparisons");
    }
}