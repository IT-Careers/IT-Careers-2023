class Program
{
    // Warm up for later https://www.hackerrank.com/challenges/equal/problem?isFullScreen=true
    
    public static long GetPrice(long n, long currentLength, long[] prices)
    {
        if(currentLength > n)
        {
            return 0;
        }

        if(n <= 0) 
        {
            return 0;
        }

        long currentPrice = prices[currentLength];

        long remainingPrice = GetPrice(n - currentLength, currentLength, prices);
        long otherPrice = GetPrice(n, currentLength + 1, prices);

        return Math.Max(currentPrice + remainingPrice, otherPrice);
    }
    
    public static void Main(string[] args)
    {
        long[] prices = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30, 31, 34, 44, 50, 60, 70, 78, 90, 102, 120, 135, 145, 175, 200, 250, 300 };

        Console.WriteLine(prices.Length);

        long n = long.Parse(Console.ReadLine());

        Console.WriteLine(GetPrice(n, 1, prices));
    }
}