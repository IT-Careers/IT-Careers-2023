class Program
{
    public static long Recursive(long currentSum, int index, List<long> coins, long[,] counts)
    {
        if(index < 0)
        {
            return 0;
        }

        if(currentSum == 0)
        {
            return 1;
        }

        if (currentSum < 0)
        {
            return 0;
        }

        if (counts[currentSum, index] >= 0)
        {
            return counts[currentSum, index];
        }

        long coin = coins[index];

        long countOfRemaining = Recursive(currentSum - coin, index, coins, counts);
        long countOfOther = Recursive(currentSum, index - 1, coins, counts);

        counts[currentSum, index] = countOfRemaining + countOfOther;

        return counts[currentSum, index];
    }

    public static long GetWays(int n, List<long> coins)
    {
        coins.Sort(); // 4, 1,2,3

        long[,] counts = new long[n + 1, coins.Count];

        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j < coins.Count; j++)
            {
                counts[i, j] = -1;
            }
        }

        long count = Recursive(n, coins.Count - 1, coins, counts);

        return count;
    }

    public static void Main(string[] args)
    {
        int[] firstLineOfInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = firstLineOfInput[0];
        List<long> coins = Console.ReadLine().Split().Select(long.Parse).ToList();

        Console.WriteLine(GetWays(n, coins));
    }
}