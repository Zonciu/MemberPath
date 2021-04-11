using System.Collections.Generic;

namespace MemberPath.Test
{
    public class T1
    {
        public Child C1 { get; set; }

        public Child[] C2 { get; set; }

        public List<Child> C3 { get; set; }

        public Dictionary<string, Child> C4 { get; set; }

        public List<Child[]> C5 { get; set; }
    }

    public class Child
    {
        public string V1 { get; set; }

        public int V2 { get; set; }

        public string[] V3 { get; set; }

        public Dictionary<double, string> V4 { get; set; }

        public List<string> V5 { get; set; }

        public Child(string v1, int v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public Child()
        { }
    }

    public class T2
    {
        public St C6 { get; set; }

        public St C7;

        public St? C8;

        public St[] C9 { get; set; }

        public List<St> C10 { get; set; }
    }

    public struct St
    {
        public string V3;

        public int V4;

        public St(string v3, int v4)
        {
            V3 = v3;
            V4 = v4;
        }
    }
}
