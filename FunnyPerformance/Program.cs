using BenchmarkDotNet.Running;
using FunnyPerformance.StmLargeStringDeserialization;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FunnyPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<LargeStringPerformanceTest>();
        }
    }
}
