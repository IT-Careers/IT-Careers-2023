using System.Diagnostics;
using System.Numerics;

class Program
{
    public static BigInteger RecursiveFactorial(BigInteger n)
    {
        if(n == 1)
        {
            return 1;
        }

        return n * RecursiveFactorial(n - 1);
    }

    public static BigInteger IterativeFactorial(BigInteger n)
    {
        BigInteger result = 1;

        for (int i = 2; i <= n; i++)
        {
            result = result * i;
        }

        return result;
    }

    public static BigInteger RecursiveFibunacci(BigInteger n)
    {
        if(n == 0)
        {
            return 0;
        }
        else if(n == 1)
        {
            return 1;
        }
        else
        {
            return RecursiveFibunacci(n - 1) + RecursiveFibunacci(n - 2);
        }
    }

    public static BigInteger IterativeFibunacci(BigInteger n)
    {
        BigInteger previousPreviousNumber = 1;
        BigInteger previousNumber = 1;
        BigInteger currentNumber = 2;

        for (int i = 3; i < n; i++)
        {
            previousPreviousNumber = previousNumber;
            previousNumber = currentNumber;
            currentNumber = previousPreviousNumber + previousNumber;
        }

        return currentNumber;
    }

    public static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        Console.WriteLine(RecursiveFibunacci(n));

        stopwatch.Stop();

        Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Reset();
        stopwatch.Start();

        Console.WriteLine(IterativeFibunacci(n));

        stopwatch.Stop();

        Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
    }
}