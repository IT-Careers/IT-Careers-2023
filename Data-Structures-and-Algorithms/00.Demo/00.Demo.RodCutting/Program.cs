class Program
{
    // Warm up for later https://www.hackerrank.com/challenges/equal/problem?isFullScreen=true
    
    public static long GetPrice(long n, long currentLength, long[] prices, long[] maxPrices)
    {
        if(currentLength > n)
        {
            return 0;
        }

        if(n <= 0) 
        {
            return 0;
        }

        if (maxPrices[n] >= 0)
        {
            return maxPrices[n];
        }

        long currentPrice = prices[currentLength];

        long remainingPrice = GetPrice(n - currentLength, currentLength, prices, maxPrices);
        long otherPrice = GetPrice(n, currentLength + 1, prices, maxPrices);

        long maxOfTwo = Math.Max(currentPrice + remainingPrice, otherPrice);

        maxPrices[n] = Math.Max(maxPrices[n], maxOfTwo);

        return maxPrices[n];
    }
    
    public static void Main(string[] args)
    {
        long[] prices = new long[1000];

        prices[1] = 1;
        prices[2] = 5;
        prices[3] = 8;

        for (int i = 4; i < 1000; i++)
        {
            Random random = new Random();

            prices[i] = prices[i - 1] + random.NextInt64(0, (long)Math.Sqrt(prices[i - 1])); 
        }

        long n = long.Parse(Console.ReadLine());

        long[] maxPrices = new long[n + 1];

        for (int i = 0; i < maxPrices.Length; i++)
        {
            maxPrices[i] = -1;
        }

        Console.WriteLine(GetPrice(n, 1, prices, maxPrices));
    }
}