using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetExample
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MyBenchmark
    {
        [Benchmark]
        public void DoStuff3Bench()
        {
            new MyBenchmarkMethods().DoStuff3();
        }
        [Benchmark]
        public void DoStuff4Bench()
        {
            new MyBenchmarkMethods().DoStuff4();
        }

        [Benchmark]
        public void DoStuff2Bench()
        {
            new MyBenchmarkMethods().DoStuff2();
        }

    }

    public class MyBenchmarkMethods
    {
        //public static void DoStuff()
        //{
        //    string[] list = { "A", "B", "C", "D" };
        //    StringBuilder stringBuilder = new StringBuilder();
        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        stringBuilder.Append(list[i]);
        //    }
        //    Console.WriteLine(stringBuilder);
        //}

        public void DoStuff2()
        {
            string[] list = { "A", "B", "C", "D" };
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in list)
            {
                stringBuilder.Append(item);
            }
            Console.WriteLine(stringBuilder.ToString());
        }
        public void DoStuff3()
        {
            string[] list = { "A", "B", "C", "D" };
            string stringBuilder = "";
            foreach (var item in list)
            {
                stringBuilder += item;
            }
            Console.WriteLine(stringBuilder);
        }
        public void DoStuff4()
        {
            string[] list = { "A", "B", "C", "D" };
            string stringBuilder = String.Empty;
            foreach (var item in list)
            {
                stringBuilder += item;
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
