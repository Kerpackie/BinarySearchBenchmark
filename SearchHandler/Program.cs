using System.Diagnostics;
using BenchmarkLib;

namespace SearchHandler;

class Program
{
    static void Main(string[] args)
    {
        /*ForgetfulBinarySearch(Benchmark.TARGET, "1", "forgetful");*/
        
        var benchmarkType = args[0];
        var target = long.Parse(args[1]);
        var iteration = args[2];
        
        switch (benchmarkType)
        {
            case "binary":
                RunBinarySearch(target, iteration, benchmarkType);
                break;
            case "recognising":
                RunRecognisingEqualityBinarySearch(target, iteration, benchmarkType);
                break;
            case "forgetful":
                ForgetfulBinarySearch(target, iteration, benchmarkType);
                break;
            case "recursive":
                RunRecursiveBinarySearch(target, iteration, benchmarkType);
                break;
        }
    }

    private static void RunBinarySearch(long target, string iteration, string benchmarkType)
    {
        
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        var result = Search.BinarySearch(inputList, target, out var comparisons);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, comparisons, benchmarkType, 
            iteration, result);
    }
    
    private static void RunRecognisingEqualityBinarySearch(long target, string iteration, string benchmarkType)
    {
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        var result = Search.RecognisingEqualityBinarySearch(inputList, target, out var comparisons);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, comparisons, benchmarkType, 
            iteration, result);
    }
    
    private static void ForgetfulBinarySearch(long target, string iteration, string benchmarkType)
    {
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        long result = Search.ForgetfulBinarySearch(inputList, target, out var comparisons);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, comparisons, benchmarkType, 
            iteration, result);
    }
    
    private static void RunRecursiveBinarySearch(long target, string iteration, string benchmarkType)
    {
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        var result = Search.RecursiveBinary(inputList, 0, inputList.Count - 1, target);
        
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, result.comparisons, benchmarkType, 
            iteration, result.index);
    }
    
}