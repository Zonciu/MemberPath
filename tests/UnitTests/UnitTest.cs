using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace MemberPath.Test
{
    public class UnitTest
    {
        public T1 t1 = new()
        {
            C1 = new("AAA", 1111) { V4 = new() { { 64.352141d, "cool" } } },
            C2 = new Child[] { new("A1", 11), new("B1", 222) },
            C3 = new() { new("C1", 333), new Child("E1", 666) { V3 = new[] { "VV1", "VV2" } } },
            C4 = new() { { "D1", new("D11", 444) }, { "D2", new("D222", 999) { V3 = new[] { "D21", "D22" } } } },
            C5 = new List<Child[]>() { new Child[] { new("C5-1", 551) } }
        };

        public T2 t2 = new()
        {
            C6 = new("CCCC", 123),
            C7 = new("DDDDD", 456),
            C8 = new("EEEE", 789),
            C9 = new St[] { new("9AA", 44), new("9BBB", 55) },
            C10 = new() { new("10AA", 12), new("10BBBB", 13) }
        };

        [Fact]
        public void Get()
        {
            t1.PathGet<T1, string>("C1.V1").Should().Be(t1.C1.V1);
            t1.PathGet<string>("C1.V1").Should().Be(t1.C1.V1);
            t1.PathGet("C1.V1").Should().Be(t1.C1.V1);

            t1.PathGet<T1, int>("C1.V2").Should().Be(t1.C1.V2);
            t1.PathGet<int>("C1.V2").Should().Be(t1.C1.V2);
            t1.PathGet("C1.V2").Should().Be(t1.C1.V2);

            t1.PathGet<T1, string>("C2[1].V1").Should().Be(t1.C2[1].V1);
            t1.PathGet<string>("C2[1].V1").Should().Be(t1.C2[1].V1);
            t1.PathGet("C2[1].V1").Should().Be(t1.C2[1].V1);

            t1.PathGet<T1, int>("C3[0].V2").Should().Be(t1.C3[0].V2);
            t1.PathGet<int>("C3[0].V2").Should().Be(t1.C3[0].V2);
            t1.PathGet("C3[0].V2").Should().Be(t1.C3[0].V2);

            t1.PathGet<T1, string>("C4['D1'].V1").Should().Be(t1.C4["D1"].V1);
            t1.PathGet<string>("C4['D1'].V1").Should().Be(t1.C4["D1"].V1);
            t1.PathGet("C4['D1'].V1").Should().Be(t1.C4["D1"].V1);

            t1.PathGet<T1, string>("C3[1].V3[1]").Should().Be(t1.C3[1].V3[1]);
            t1.PathGet<string>("C3[1].V3[1]").Should().Be(t1.C3[1].V3[1]);
            t1.PathGet("C3[1].V3[1]").Should().Be(t1.C3[1].V3[1]);

            t1.PathGet<T1, int>("C5[0][0].V2").Should().Be(t1.C5[0][0].V2);
            t1.PathGet<int>("C5[0][0].V2").Should().Be(t1.C5[0][0].V2);
            t1.PathGet("C5[0][0].V2").Should().Be(t1.C5[0][0].V2);

            var dkey = 64.352141d;
            t1.PathGet<T1, string>($"C1.V4[{dkey}]").Should().Be(t1.C1.V4[dkey]);
            t1.PathGet<string>($"C1.V4[{dkey}]").Should().Be(t1.C1.V4[dkey]);
            t1.PathGet("C1.V4").Should().Be(t1.C1.V4);
        }

        [Fact]
        public void Set()
        {
            var random = new Random();
            {
                var value = Guid.NewGuid().ToString();
                t1.PathSet<string>("C1.V1", value);
                t1.C1.V1.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t1.PathSet("C1.V1", value);
                t1.C1.V1.Should().Be(value);

                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C1.V1", t1.GetType()).Invoke(t1, value);
                t1.C1.V1.Should().Be(value);
            }
            {
                var value = random.Next();
                t1.PathSet<int>("C1.V2", value);
                t1.C1.V2.Should().Be(value);

                value = random.Next();
                t1.PathSet("C1.V2", value);
                t1.C1.V2.Should().Be(value);

                value = random.Next();
                PathHelper.SetDelegate("C1.V2", t1.GetType()).Invoke(t1, value);
                t1.C1.V2.Should().Be(value);
            }

            {
                var value = Guid.NewGuid().ToString();
                t1.PathSet<string>("C2[1].V1", value);
                t1.C2[1].V1.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t1.PathSet("C2[1].V1", value);
                t1.C2[1].V1.Should().Be(value);

                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C2[1].V1", t1.GetType()).Invoke(t1, value);
                t1.C2[1].V1.Should().Be(value);
            }
            {
                var value = random.Next();
                t1.PathSet<int>("C3[0].V2", value);
                t1.C3[0].V2.Should().Be(value);

                value = random.Next();
                t1.PathSet("C3[0].V2", value);
                t1.C3[0].V2.Should().Be(value);

                value = random.Next();
                PathHelper.SetDelegate("C3[0].V2", t1.GetType()).Invoke(t1, value);
                t1.C3[0].V2.Should().Be(value);
            }
            {
                var value = Guid.NewGuid().ToString();
                t1.PathSet<string>("C4['D1'].V1", value);
                t1.C4["D1"].V1.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t1.PathSet("C4['D1'].V1", value);
                t1.C4["D1"].V1.Should().Be(value);

                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C4['D1'].V1", t1.GetType()).Invoke(t1, value);
                t1.C4["D1"].V1.Should().Be(value);
            }
            {
                var value = Guid.NewGuid().ToString();
                t1.PathSet<string>("C3[1].V3[1]", value);
                t1.C3[1].V3[1].Should().Be(value);

                value = Guid.NewGuid().ToString();
                t1.PathSet("C3[1].V3[1]", value);
                t1.C3[1].V3[1].Should().Be(value);

                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C3[1].V3[1]", t1.GetType()).Invoke(t1, value);
                t1.C3[1].V3[1].Should().Be(value);
            }
            {
                var value = random.Next();
                t1.PathSet<int>("C5[0][0].V2", value);
                t1.C5[0][0].V2.Should().Be(value);

                value = random.Next();
                t1.PathSet("C5[0][0].V2", value);
                t1.C5[0][0].V2.Should().Be(value);

                value = random.Next();
                ((object)t1).PathSet("C5[0][0].V2", (object)value);
                t1.C5[0][0].V2.Should().Be(value);

                value = random.Next();
                PathHelper.SetDelegate("C5[0][0].V2", t1.GetType()).Invoke(t1, value);
                t1.C5[0][0].V2.Should().Be(value);
            }
        }

        [Fact]
        public void GetStruct()
        {
            t2.PathGet<T2, string>("C6.V3").Should().Be(t2.C6.V3);
            t2.PathGet<string>("C6.V3").Should().Be(t2.C6.V3);
            t2.PathGet("C6.V3").Should().Be(t2.C6.V3);

            t2.PathGet<T2, string>("C7.V3").Should().Be(t2.C7.V3);
            t2.PathGet<string>("C7.V3").Should().Be(t2.C7.V3);
            t2.PathGet("C7.V3").Should().Be(t2.C7.V3);

            t2.PathGet<T2, string>("C8.V3").Should().Be(t2.C8.Value.V3);
            t2.PathGet<string>("C8.V3").Should().Be(t2.C8.Value.V3);
            t2.PathGet("C8.V3").Should().Be(t2.C8.Value.V3);

            t2.PathGet<T2, string>("C9[0].V3").Should().Be(t2.C9[0].V3);
            t2.PathGet<string>("C9[0].V3").Should().Be(t2.C9[0].V3);
            t2.PathGet("C9[0].V3").Should().Be(t2.C9[0].V3);

            t2.PathGet<T2, string>("C10[0].V3").Should().Be(t2.C10[0].V3);
            t2.PathGet<string>("C10[0].V3").Should().Be(t2.C10[0].V3);
            t2.PathGet("C10[0].V3").Should().Be(t2.C10[0].V3);
        }

        [Fact]
        public void SetStruct()
        {
            var value = Guid.NewGuid().ToString();
            {
                var old = t2.C6.V3;
                PathHelper.SetDelegate("C6.V3", t2.GetType()).Invoke(t2, value);
                t2.C6.V3.Should().Be(old);

                value = Guid.NewGuid().ToString();
                t2.PathSet<string>("C6.V3", value);
                t2.C6.V3.Should().Be(old);

                value = Guid.NewGuid().ToString();
                t2.PathSet("C6.V3", value);
                t2.C6.V3.Should().Be(old);
            }
            {
                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C7.V3", t2.GetType()).Invoke(t2, value);
                t2.C7.V3.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t2.PathSet<string>("C7.V3", value);
                t2.C7.V3.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t2.PathSet("C7.V3", value);
                t2.C7.V3.Should().Be(value);
            }
            {
                var old = t2.C8.Value.V3;
                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C8.V3", t2.GetType()).Invoke(t2, value);
                t2.C8.Value.V3.Should().Be(old);

                value = Guid.NewGuid().ToString();
                t2.PathSet<string>("C8.V3", value);
                t2.C8.Value.V3.Should().Be(old);

                value = Guid.NewGuid().ToString();
                t2.PathSet("C8.V3", value);
                t2.C8.Value.V3.Should().Be(old);
            }
            {
                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C9[0].V3", t2.GetType()).Invoke(t2, value);
                t2.C9[0].V3.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t2.PathSet<string>("C9[0].V3", value);
                t2.C9[0].V3.Should().Be(value);

                value = Guid.NewGuid().ToString();
                t2.PathSet("C9[0].V3", value);
                t2.C9[0].V3.Should().Be(value);
            }
            {
                var old = t2.C10[0].V3;
                value = Guid.NewGuid().ToString();
                PathHelper.SetDelegate("C10[0].V3", t2.GetType()).Invoke(t2, value);
                t2.C10[0].V3.Should().Be(old);

                value = Guid.NewGuid().ToString();
                t2.PathSet<string>("C10[0].V3", value);
                t2.C10[0].V3.Should().Be(old);

                value = Guid.NewGuid().ToString();
                t2.PathSet("C10[0].V3", value);
                t2.C10[0].V3.Should().Be(old);
            }
        }

        [Fact]
        public void Lambda()
        {
            {
                var func = PathHelper.GetLambda("C1.V1", t1.GetType()).Compile();
                func(t1).Should().Be(t1.C1.V1);
            }
            {
                var func = PathHelper.GetLambda<string>("C1.V1", t1.GetType()).Compile();
                func(t1).Should().Be(t1.C1.V1);
            }
            {
                var func = PathHelper.GetLambda<T1, string>("C1.V1").Compile();
                func(t1).Should().Be(t1.C1.V1);
            }

            {
                var value = Guid.NewGuid().ToString();
                var action = PathHelper.SetLambda("C1.V1", t1.GetType()).Compile();
                action(t1, value);
                t1.C1.V1.Should().Be(t1.C1.V1);
            }
            {
                var value = Guid.NewGuid().ToString();
                var action = PathHelper.SetLambda<string>("C1.V1", t1.GetType()).Compile();
                action(t1, value);
                t1.C1.V1.Should().Be(t1.C1.V1);
            }
            {
                var value = Guid.NewGuid().ToString();
                var action = PathHelper.SetLambda<T1, string>("C1.V1").Compile();
                action(t1, value);
                t1.C1.V1.Should().Be(t1.C1.V1);
            }
        }

        [Theory]
        [InlineData("A.b.acv")]
        [InlineData("A[1].b.acv")]
        [InlineData("[4].b.acv")]
        [InlineData("A.b[0].acv")]
        [InlineData("A.b[0][5].acv")]
        [InlineData("A.b[0][5]['fekjk'].acv")]
        [InlineData("A.b[0][5]['fekjk'].acv[12]")]
        [InlineData("A.b[0][5]['fekjk'].acv['1gfds.a2']")]
        [InlineData("A.b['fe ]''[sad']")]
        [InlineData("A.b['fe '']''[''sad']")]
        public void Parse(string value)
        {
            var pathLink = PathHelper.Parse(value);
            var sb = new StringBuilder();
            for (var i = 0; i < pathLink.Count; i++)
            {
                var node = pathLink[i];
                if (i != 0 && node.NodeType == PathNodeType.Member)
                {
                    sb.Append('.');
                }

                sb.Append(node);
            }

            var path = sb.ToString();
            path.Should().Be(value);
        }

        [Theory]
        [InlineData(".A.")]
        [InlineData("1].b.acv")]
        [InlineData("[4.b.acv")]
        [InlineData("A..b0acv")]
        [InlineData("A.b[0].[5].acv")]
        [InlineData("A.b[0][5]['fekjk'].")]
        [InlineData("A.b[0][]['fekjk'].acv[12]")]
        [InlineData("A.b][['fekjk'].acv['1gfds.a2']")]
        [InlineData("A.b[fe ]''[sad']")]
        [InlineData("A.b.['fe '']''[''sad']")]
        [InlineData("A.b['fe '']']''sad']")]
        [InlineData("A.b['fe'asas']")]
        public void InvalidPath(string path)
        {
            FluentActions.Invoking(() => { PathHelper.Parse(path); })
                         .Should()
                         .Throw<InvalidPathException>();
        }

        [Theory]
        [InlineData(typeof(T1), "C1.V1", false)]
        [InlineData(typeof(T1), "C1.V4", false)]
        [InlineData(typeof(T1), "C2[2].V1", false)]
        [InlineData(typeof(T1), "C2.V1", true)]
        [InlineData(typeof(T1), "C3.V1", true)]
        [InlineData(typeof(T1), "C4.V1", true)]
        [InlineData(typeof(T1), "C5.V1", true)]
        [InlineData(typeof(T1), "C5[0][1].V1", false)]
        [InlineData(typeof(Child), "V4[12.415]", false)]
        public void InvalidParse(Type type, string path, bool shouldFailed)
        {
            if (shouldFailed)
            {
                FluentActions.Invoking(() => { PathHelper.GetExpression(path, type, typeof(object), typeof(object), false); })
                             .Should()
                             .Throw<Exception>();
            }
            else
            {
                FluentActions.Invoking(() => { PathHelper.GetExpression(path, type, typeof(object), typeof(object), false); })
                             .Should()
                             .NotThrow();
            }
        }

        [Fact]
        public void GetNullableValue()
        {
            var t = new T1 { C1 = null, C2 = null, C4 = new(), C5 = new() };
            FluentActions.Invoking(() => t.PathGet<string>("C1.V1")).Should().ThrowExactly<NullReferenceException>();
            FluentActions.Invoking(() => t.PathGet<string>("C2[3].V1")).Should().ThrowExactly<NullReferenceException>();

            t.PathGetOrDefault<string>("C1.V1").Should().Be(null);
            t.PathGetOrDefault<string>("C2[3].V1").Should().Be(null);
            t.PathGetOrDefault<string>("C4['tfk32'].V1").Should().Be(null);
            t.PathGetOrDefault<string>("C5[3][5].V1").Should().Be(null);

            PathHelper.GetDelegateDefault("C1.V1", t.GetType()).Invoke(t).Should().Be(null);
            PathHelper.GetDelegateDefault("C1.V2", t.GetType()).Invoke(t).Should().Be(null);
            PathHelper.GetDelegateDefault("V4", typeof(St));
            PathHelper.GetDelegateDefault<T1, string>("C5[3][5].V1").Invoke(t).Should().Be(null);
            PathHelper.GetDelegateDefault<string>("C5[3][5].V1", t.GetType()).Invoke(t).Should().Be(null);
            PathHelper.GetDelegateDefault<string>("C5[3][5].V1", t.GetType()).Invoke(t).Should().Be(null);

            var lt2 = new T2();
            lt2.PathGetOrDefault<string>("C8.V3").Should().Be(null);
            t2.PathGetOrDefault<string>("C8.V3").Should().Be(t2.C8!.Value!.V3);

            lt2.PathGetOrDefault("C8.V3").Should().Be(null);
            lt2.PathGetOrDefault<T2, string>("C8.V3").Should().Be(null);

            lt2.PathGetOrDefault<int?>("C9[1].V4").Should().BeNull();
            t2.PathGetOrDefault<int?>("C9[1].V4").Should().Be(t2.C9[1].V4);

            lt2.PathGetOrDefault<int>("C9[1].V4").Should().Be(0);
            t2.PathGetOrDefault<int>("C9[1].V4").Should().Be(t2.C9[1].V4);

            lt2.PathGetOrDefault("C9[1].V4").Should().BeNull();
        }

        [Fact]
        public void GetNullableLambda()
        {
            var lt2 = new T2();
            {
                var lambda = PathHelper.GetLambdaDefault("C10[2].V3", typeof(T2)).Compile();
                lambda.Invoke(lt2).Should().BeNull();
            }
            {
                var lambda = PathHelper.GetLambdaDefault<string>("C10[2].V3", typeof(T2)).Compile();
                lambda.Invoke(lt2).Should().BeNull();
            }
            {
                var lambda = PathHelper.GetLambdaDefault<T2, string>("C10[2].V3").Compile();
                lambda.Invoke(lt2).Should().BeNull();
            }
        }

        [Fact]
        public void SetCollectionItem()
        {
            var child = new Child() { V3 = new string[3], V4 = new(), V5 = new() { "A", "B", "C" } };
            child.PathSet("V4[13.23]", "test 13.23");
            child.PathGet("V4[13.23]").Should().Be("test 13.23").And.Be(child.V4[13.23]);

            child.PathSet("V3[2]", "abc");
            child.PathGet("V3[2]").Should().Be("abc").And.Be(child.V3[2]);

            child.PathSet("V5[1]", "999a");
            child.PathGet("V5[1]").Should().Be("999a").And.Be(child.V5[1]);
        }
    }
}
