using System.Collections.Generic;

namespace MemberPath.Benchmark
{
    public class TestObj
    {
        public Ch C1 { get; set; }

        public Ch[] C2 { get; set; }

        public List<Ch> C3 { get; set; }

        public Dictionary<string, Ch> C4 { get; set; }

        public Dictionary<string, Ch[]> C5 { get; set; }

        public Ch3 C6;

        public Ch3? C7 { get; set; }
    }

    public class Ch
    {
        public string V1 { get; set; }

        public int V2 { get; set; }

        public Ch2 V3 { get; set; }
    }

    public class Ch2
    {
        public string V4 { get; set; }
    }

    public struct Ch3
    {
        public string V1 { get; set; }

        public int V2 { get; set; }

        public Ch4 V3 { get; set; }
    }

    public class Ch4
    {
        public string V9 { get; set; }
    }
}
