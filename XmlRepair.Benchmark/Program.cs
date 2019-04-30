using BenchmarkDotNet.Running;

namespace XmlRepair.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = BenchmarkRunner.Run<XmlRepairBenchmark>();
        }
    }
}
