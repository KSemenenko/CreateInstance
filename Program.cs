using System;
using BenchmarkDotNet.Running;

namespace CreateInstance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CreateInstanceTests>();
            Console.ReadLine();
        }
    }
}