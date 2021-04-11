using System;
using BenchmarkDotNet.Attributes;

namespace MemberPath.Benchmark
{
    [MemoryDiagnoser]
    public class SetBench
    {
        public TestObj Obj = new() { C1 = new Ch() { V1 = "A1" } };

        [Params(10000000)]
        public int N;

        public string Path = "C1.V1";

        [Benchmark(Baseline = true)]
        public void Normal()
        {
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                Obj.C1.V1 = value;
            }
        }

        [Benchmark]
        public void PathSetTV()
        {
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                Obj.PathSet(Path, value);
            }
        }

        [Benchmark]
        public void PathSetOV()
        {
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                Obj.PathSet<string>(Path, value);
            }
        }

        [Benchmark]
        public void PathSetOO()
        {
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                PathHelper.SetDelegate(Path, Obj.GetType()).Invoke(Obj, value);
            }
        }

        [Benchmark]
        public void PathSetTVCached()
        {
            var action = PathHelper.SetDelegate<TestObj, string>(Path);
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                action(Obj, value);
            }
        }

        [Benchmark]
        public void PathSetOVCached()
        {
            var action = PathHelper.SetDelegate<string>(Path, Obj.GetType());
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                action(Obj, value);
            }
        }

        [Benchmark]
        public void PathSetOOCached()
        {
            var action = PathHelper.SetDelegate(Path, Obj.GetType());
            var value = Guid.NewGuid().ToString();
            for (int i = 0; i < N; i++)
            {
                action(Obj, value);
            }
        }
    }
}
