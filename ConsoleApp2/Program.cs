using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int position = 0;
        public static int nextStall = 0;
        public static bool[] stalls = new bool[20];
        public static int start = 0;
        public static int end = stalls.Length;
        public static int mid = (end - start) / 2;

        static void Main(string[] args)
        {
            printStalls(stalls);
            Console.ReadLine();
        }

        public static int NextStall(bool[] stalls)
        {
            if (position == 0)
            {
                nextStall = mid;
            }
            else
            {
                if (position % 2 == 1)
                {
                    end = mid;
                    mid = (end - start) / 2;
                    nextStall = mid;
                }

                else if (position % 2 == 0)
                {
                    mid = (end - start) / 2 + mid;
                    nextStall = mid;
                    end = mid;
                    mid = (end - start) / (int)Math.Pow(2, position);

                }
            }

            position++;
            return nextStall;
        }

        public static void printStalls(bool[] stalls)
        {
            String[] s1 = new String[stalls.Length];

            while (position < stalls.Length)
            {
                NextStall(stalls);
                stalls[nextStall] = true;
                for (int i = 0; i < stalls.Length; i++)
                {
                    if (stalls[i] == true)
                    {
                        s1[i] = "x";
                    }
                    else
                    {
                        s1[i] = "_";
                    }
                }
                Console.WriteLine("[{0}]", string.Join("", s1));
            }
        }


    }
}
