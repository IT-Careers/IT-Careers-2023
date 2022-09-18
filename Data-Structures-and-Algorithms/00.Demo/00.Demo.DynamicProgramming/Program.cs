using System.Numerics;
using System.Runtime.Intrinsics.Arm;

class Program
{
    public static BigInteger RecursiveFibunacci(BigInteger n)
    {
        if (n == 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else
        {
            return RecursiveFibunacci(n - 1) + RecursiveFibunacci(n - 2);
        }
    }

    public static BigInteger OptimizedFibunacci(int n, BigInteger[] dpArray)
    {
        if (n == 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else
        {
            if (dpArray[n - 1] == 0)
            {
                dpArray[n - 1] = OptimizedFibunacci(n - 1, dpArray);
            }

            if (dpArray[n - 2] == 0)
            {
                dpArray[n - 2] = OptimizedFibunacci(n - 2, dpArray);
            }


            return dpArray[n - 1] + dpArray[n - 2];
        }
    }

    public static void Main(string[] args)
    {
        BigInteger[] dpArray = new BigInteger[1000000];

        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(OptimizedFibunacci(n, dpArray));
    }
}