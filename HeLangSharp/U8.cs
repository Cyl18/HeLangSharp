using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Text;

namespace HeLangSharp
{
    public class U8CentralFiniteCurve
    {
        public static readonly U8Start 典 = new U8Start();
        public static readonly U8Start dian = new U8Start();
        public static readonly U8End 乐 = new U8End();
        public static readonly U8End le = new U8End();

        public static void Test5G()
        {
            // https://github.com/shaokeyibb/HeLangKotlinScriptImpl/blob/bc4a379e90bfbcb5f5fa619a5d1cd5137e7ac764/src/main/kotlin/io/hikarilan/helangkotlinscriptimpl/SpeedTester.kt
            // https://github.com/kifuan/helang/blob/219c3f5da2031154749996d322780941b5d5558b/helang/speed_tester.py

            throw new NotImplementedException();
        }

        public static void SPrint(u8 a)
        {
            for (int i = 0; i < a.nums.Length; i++)
            {
                var num = a.nums[i];
                Console.Write((char) num);
            }
            Console.WriteLine();
        }

        public static void Print(u8 a)
        {
            for (int i = 0; i < a.nums.Length; i++)
            {
                var num = a.nums[i];
                Console.Write(i == 0 ? $"{num}" : $" | {num}");
            }
            Console.WriteLine();
        }

        public static u8 CreateU8(int length)
        {
            if (length <= 0)
            {
                throw new InsufficientMemoryException();
            }

            var a = new U8Builder(0);
            for (int i = 0; i < length - 1; i++)
            {
                a.Add(0);
            }

            return a.Build();
        }
    }

    public ref struct u8
    {
        public Span<nint> nums { get; set; }

        internal u8(Span<nint> nums)
        {
            this.nums = nums;
        }

        public static u8 operator ++(u8 a)
        {
            for (var i = 0; i < a.nums.Length; i++)
            {
                a.nums[i]++;
            }

            return a;
        }

        public static implicit operator u8(Span<nint> a)
        {
            return new u8(a);
        }

        public nint this[u8 u]
        {
            set
            {
                foreach (var num in u.nums)
                {
                    nums[(int)num - 1] = value;
                }
            }
        }

        public nint this[nint v]
        {
            get
            {
                return nums[(int) v - 1];
            }
            set
            {
                if (v == 0)
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = value;
                    }
                }
                else
                {
                    nums[(int)v - 1] = value;
                }
            }
        }

    }

    public struct U8Start
    {
        public static U8Builder operator |(U8Start b, nint i)
        {
            return new U8Builder(i);
        }
    }

    public struct U8End
    {

    }

    public class U8Builder
    {
        List<nint> Nums = new();

        public U8Builder(nint startNum)
        {
            Nums.Add(startNum);
        }

        public void Add(nint num)
        {
            Nums.Add(num);
        }

        public u8 Build()
        { 
            //u8 a = stackalloc int[10];
            return new u8(CollectionsMarshal.AsSpan(Nums));
        }

        public static u8 operator |(U8Builder b, U8End e)
        {
            return b.Build();
        }

        public static U8Builder operator |(U8Builder b, nint i)
        {
            b.Add(i);
            return b;
        }
    }
}