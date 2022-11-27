using System;
using BenchmarkDotNet.Running;
namespace For_Foreach_Span
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
            Console.ReadKey();
        }
    }
}
