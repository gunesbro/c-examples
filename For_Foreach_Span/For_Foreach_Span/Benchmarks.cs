using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace For_Foreach_Span
{
    //|       Method |    Size |            Mean |         Error |        StdDev |          Median | Allocated |
    //|------------- |-------- |----------------:|--------------:|--------------:|----------------:|----------:|
    //|          For |     100 |       116.40 ns |      2.374 ns |      5.689 ns |       114.96 ns |         - |
    //|      Foreach |     100 |       260.10 ns |      5.240 ns |      9.969 ns |       256.75 ns |         - |
    //|     For_Span |     100 |        53.45 ns |      1.579 ns |      4.655 ns |        51.46 ns |         - |
    //| Foreach_Span |     100 |        58.01 ns |      1.774 ns |      5.230 ns |        57.77 ns |         - |
    //|          For |  100000 |   116,619.64 ns |  2,358.518 ns |  6,917.125 ns |   115,751.53 ns |         - |
    //|      Foreach |  100000 |   257,663.81 ns |  5,021.775 ns |  7,202.079 ns |   255,957.40 ns |         - |
    //|     For_Span |  100000 |    37,025.68 ns |    727.341 ns |    837.607 ns |    37,037.22 ns |         - |
    //| Foreach_Span |  100000 |    37,060.97 ns |    700.321 ns |    833.682 ns |    36,827.20 ns |         - |
    //|          For | 1000000 | 1,123,058.06 ns | 21,839.803 ns | 47,477.934 ns | 1,110,240.62 ns |         - |
    //|      Foreach | 1000000 | 2,608,015.92 ns | 32,358.243 ns | 25,263.188 ns | 2,603,645.51 ns |         - |
    //|     For_Span | 1000000 |   364,720.45 ns |  4,046.345 ns |  3,784.954 ns |   364,359.08 ns |         - |
    //| Foreach_Span | 1000000 |   378,878.90 ns |  7,526.132 ns | 18,881.592 ns |   369,307.01 ns |         - |

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private static readonly Random Rnd = new(80_850);
        [Params(100,100_000,1_000_000)]
        public int Size { get; set; }

        private List<int> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(1, Size).Select(x => Rnd.Next()).ToList();
        }
        [Benchmark]
        public void For()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
            }
        }
        [Benchmark]
        public void Foreach()
        {
            foreach (var item in _items)
            {
            }
        }

        /// Items should not be added
        //     or removed from the System.Collections.Generic.List`1 while the System.Span`1
        //     is in use.
        // CollectionsMarshal support .NET 5, .NET 6, .NET 7
        [Benchmark]
        public void For_Span()
        {
            var asSpan = CollectionsMarshal.AsSpan(_items);
            for (int i = 0; i < asSpan.Length; i++)
            {
                var item = asSpan[i];
            }
        }
        [Benchmark]
        public void Foreach_Span()
        {
            foreach (int item in CollectionsMarshal.AsSpan(_items))
            {

            }
        }
    }
}
