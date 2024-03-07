using System.Diagnostics;
using BenchmarkLib;

namespace SearchHandler;

class Program
{
    static void Main(string[] args)
    {
        var benchmarkType = args[0];
        var target = long.Parse(args[1]);
        var iteration = args[2];
        
        switch (benchmarkType)
        {
            case "binary":
                RunBinarySearch(target, iteration, benchmarkType);
                break;
            case "recognising":
                RunRecognisingEqaualityBinarySearch(target, iteration, benchmarkType);
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
        var count = Search.BinarySearch(inputList, target);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, count, benchmarkType, iteration);
    }
    
    private static void RunRecognisingEqaualityBinarySearch(long target, string iteration, string benchmarkType)
    {
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        var count = Search.RecognisingEqualityBinarySearch(inputList, target);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, count, benchmarkType, iteration);
    }
    
    private static void ForgetfulBinarySearch(long target, string iteration, string benchmarkType)
    {
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        var count = Search.ForgetfulBinarySearch(inputList, target);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, count, benchmarkType, iteration);
    }
    
    private static void RunRecursiveBinarySearch(long target, string iteration, string benchmarkType)
    {
        var inputList = Benchmark.LoadUniqueNumbersFromFile();
        var sw = new Stopwatch();
        sw.Start();
        var count = Search.RecursiveBinary(inputList, 0, inputList.Count - 1, target);
        sw.Stop();
        
        Benchmark.OutputResultsToFile(sw.ElapsedTicks, sw.ElapsedMilliseconds, count, benchmarkType, iteration);
    }
    
}