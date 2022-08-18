using HeLangSharp;
using System.Collections;
using System.Text;
using static HeLangSharp.U8CentralFiniteCurve;

namespace HeLangSharp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInit()
        {
            u8 a = dian | 1 | 2 | le;

            CollectionAssert.AreEqual(a.nums.ToArray(), new nint[] { 1, 2 });
        }

        [TestMethod]
        public void TestIncrement()
        {
            u8 a = dian | 1 | 2 | le;
            a++;
            CollectionAssert.AreEqual(a.nums.ToArray(), new nint[] { 2, 3 });
        }

        [TestMethod]
        public void TestElementOperations()
        {
            u8 a = dian | 1 | 2 | 3 | 4 | 5 | le;

            Assert.AreEqual(a[1], 1);

            a[5] = 0;
            Assert.AreEqual(a[5], 0);

            a[dian | 1 | 3 | le] = 0;
            CollectionAssert.AreEqual(a.nums.ToArray(), new nint[] { 0, 2, 0, 4, 0 });

            a[0] = 0;
            CollectionAssert.AreEqual(a.nums.ToArray(), new nint[] { 0, 0, 0, 0, 0 });
        }

        [TestMethod]
        public void TestPrint()
        {
            var original = Console.Out;
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            Console.SetOut(writer);

            u8 a = dian | 1 | 2 | 3 | 4 | 5 | le;

            Print(a);

            u8 hw = dian | 72 | 101 | 108 | 108 | 111 | 44 | 32 | 119 | 111 | 114 | 108 | 100 | 33 | le;
            SPrint(hw);

            Assert.AreEqual(sb.ToString(), "1 | 2 | 3 | 4 | 5" + Environment.NewLine +
                                           "Hello, world!" + Environment.NewLine);

            Console.SetOut(original);
        }

        [TestMethod]
        public void TestSpan()
        {
            u8 a = stackalloc nint[10];
            a[0] = 1;
            
            CollectionAssert.AreEqual(a.nums.ToArray(), Enumerable.Repeat((nint)1, 10).ToArray());
        }

        [TestMethod]
        public void TestCreateU8()
        {
            u8 a = CreateU8(10);
            a[0] = 1;

            CollectionAssert.AreEqual(a.nums.ToArray(), Enumerable.Repeat((nint)1, 10).ToArray());
        }

        [TestMethod]
        public void Download5G()
        {
            Test5G();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientMemoryException))]
        public void TestErrorCreate()
        {
            CreateU8(-1);
        }
    }
}