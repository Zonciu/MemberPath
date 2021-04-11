using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace MemberPath.Benchmark
{
    [MemoryDiagnoser]
    public class GetOrDefaultBench
    {
        public TestObj Obj = new() { C5 = new Dictionary<string, Ch[]>() };

        [Params(10000000)]
        public int N;

        public string Path = "C5['Ac'][4].V1";

        [Benchmark(Baseline = true)]
        public void Normal()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.C5.TryGetValue("Ac", out var c5) ? c5.Length > 5 ? c5[4]?.V1 : null : null;
            }
        }

        [Benchmark]
        public void PathGetOrDefaultTV()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.PathGetOrDefault<TestObj, string>(Path);
            }
        }

        [Benchmark]
        public void PathGetOrDefaultOV()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.PathGetOrDefault<string>(Path);
            }
        }

        [Benchmark]
        public void PathGetOrDefaultOO()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.PathGetOrDefault(Path);
            }
        }

        [Benchmark]
        public void PathGetOrDefaultTVCached()
        {
            var func = PathHelper.GetDelegateDefault<TestObj, string>(Path);
            for (int i = 0; i < N; i++)
            {
                var r = func(Obj);
            }
        }

        [Benchmark]
        public void PathGetOrDefaultOVCached()
        {
            var func = PathHelper.GetDelegateDefault<string>(Path, Obj.GetType());
            for (int i = 0; i < N; i++)
            {
                var r = func(Obj);
            }
        }

        [Benchmark]
        public void PathGetOrDefaultOOCached()
        {
            var func = PathHelper.GetDelegateDefault(Path, Obj.GetType());
            for (int i = 0; i < N; i++)
            {
                var r = func(Obj);
            }
        }
    }
}
