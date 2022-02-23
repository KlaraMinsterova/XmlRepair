using BenchmarkDotNet.Attributes;
using static XmlRepair.XmlRepair;

namespace XmlRepair.Benchmark
{
    [MemoryDiagnoser]
    public class XmlRepairBenchmark
    {
        private static string xmlContent;

        [GlobalSetup]
        public void Setup()
        {
            xmlContent = ReadFile();
        }

        [Benchmark]
        public void RepairRegexBenchmark()
        {
            RepairRegex(xmlContent);
        }

        [Benchmark]
        public void RepairStringBuilderBenchmark()
        {
            RepairStringBuilder(xmlContent);
        }
    }
}
