using BenchmarkDotNet.Attributes;

namespace MemberPath.Benchmark
{
    [MemoryDiagnoser]
    public class GetBench
    {
        public TestObj Obj = new()
        {
            C5 = new()
            {
                {
                    "Ac", new Ch[]
                    {
                        new(),
                        new(),
                        new(),
                        new(),
                        new() { V1 = "Goooooooooo" }
                    }
                }
            }
        };

        [Params(10000000)]
        public int N;

        public string Path = "C5['Ac'][4].V1";

        [Benchmark(Baseline = true)]
        public void Normal()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.C5["Ac"][4].V1;
            }
        }

        [Benchmark]
        public void PathGetTV()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.PathGet<TestObj, string>(Path);
            }
        }

        [Benchmark]
        public void PathGetOV()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.PathGet<string>(Path);
            }
        }

        [Benchmark]
        public void PathGetOO()
        {
            for (int i = 0; i < N; i++)
            {
                var r = Obj.PathGet(Path);
            }
        }

        [Benchmark]
        public void PathGetTVCached()
        {
            var func = PathHelper.GetDelegate<TestObj, string>(Path);
            for (int i = 0; i < N; i++)
            {
                var r = func(Obj);
            }
        }

        [Benchmark]
        public void PathGetOVCached()
        {
            var func = PathHelper.GetDelegate<string>(Path, Obj.GetType());
            for (int i = 0; i < N; i++)
            {
                var r = func(Obj);
            }
        }

        [Benchmark]
        public void PathGetOOCached()
        {
            var func = PathHelper.GetDelegate(Path, Obj.GetType());
            for (int i = 0; i < N; i++)
            {
                var r = func(Obj);
            }
        }
    }
}
