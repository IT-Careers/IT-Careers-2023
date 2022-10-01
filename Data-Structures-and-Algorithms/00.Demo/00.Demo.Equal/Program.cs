using System.Diagnostics;

public class Program
{
    // By Naiden
    public static int BetterGreedy(List<int> arr)
    {
        int[] pieces = { 5, 2, 1 }; // max(k) * k * n


        int min = arr.Min();

        int[] counts = new int[pieces.Max()];
        for (int i = 0; i < pieces.Max(); i++)
        {
            foreach (var person in arr)
            {
                int a = person - min + i;
                foreach (var piece in pieces)
                {
                    counts[i] += a / piece;
                    a %= piece;
                }
            }
        }

        return counts.Min();
    }

    public static int WorseGreedy(List<int> arr)
    {
        int[] pieces = { 5, 2, 1 };

        arr.Sort();

        int min = arr[0];
        int maxIndex = arr.Count - 1;
        int currentPieceIndex = 0;

        int count = 0;

        while (min != arr[maxIndex])
        {
            while (currentPieceIndex < pieces.Length)
            {
                if (arr[maxIndex] - min >= pieces[currentPieceIndex])
                {
                    count += (arr[maxIndex] - min) / pieces[currentPieceIndex];

                    arr[maxIndex] -= ((arr[maxIndex] - min) / pieces[currentPieceIndex]) * pieces[currentPieceIndex];
                }
                else
                {
                    currentPieceIndex++;
                }
            }

            maxIndex--;
            currentPieceIndex = 0;
        }

        return count;
    }

    public static int CountOperations(List<int> arr, int min)
    {
        int count = 0;

        for (int i = arr.Count - 1; i >= 0; i--)
        {
            int temp = arr[i] - min;

            count += temp / 5;
            temp = temp % 5;

            count += temp / 2;
            temp = temp % 2;

            if (temp != 0)
            {
                count++;
            }
        }

        return count;
    }

    public static int Equal(List<int> arr)
    {
        arr.Sort();
        int min = arr[0];

        // Start again!
        int count1 = CountOperations(arr, min);
        int count2 = CountOperations(arr, min - 1);
        int count3 = CountOperations(arr, min - 2);


        return Math.Min(count1, Math.Min(count2, count3));
    }

    public static void TestCases()
    {
        Console.WriteLine(Equal(new List<int> { 10, 7, 12 })); // 3, 0, 5 -> 3 operations

        Console.WriteLine(Equal(new List<int> { 2, 2, 3, 7 })); // 0, 0, 1, 5 -> 2 operations

        Console.WriteLine(Equal(new List<int> { 1, 5, 5 }));
        // +5 -> 6, 10, 5
        // +5 -> 11, 10, 10
        // +1 -> 11, 11, 11
        // Result: 3

        Console.WriteLine(Equal(new List<int> { 1, 5, 5, 10, 10 }));
        // +5 -> 6, 10, 10, 15, 10
        // +5 -> 11, 15, 15, 15, 15
        // +5 -> 16 20 20 20 15
        // +5 -> 21 25 25 20 20
        // +5 -> 26 30 25 25 25
        // +5 -> 31 30 30 30 30
        // +1 -> 31 31 31 31 31
        // Result: 7

        Console.WriteLine(Equal(new List<int> { 2, 5, 5, 5, 5, 5 }));
        // +5 -> 7, 10, 10, 10, 10, 5
        // +5 -> 12, 15, 15, 15, 10, 10
        // +5 -> 17, 20, 20, 15, 15, 15
        // +5 -> 22, 25, 20, 20, 20, 20
        // +5 -> 27, 25, 25, 25, 25, 25
        // +2 -> 27, 27, 27, 27, 27, 27

        // Result: 6
    }

    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("../../../../Input15.txt");

        int tests = int.Parse(lines[0]);

        for (int k = 0; k < 25; k++)
        {
            long accumulatedTime1 = 0;
            long accumulatedTime2 = 0;

            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0, j = 2; i < 100; i++, j += 2)
            {
                List<int> arr = lines[j].Split().Select(int.Parse).ToList();

                stopwatch.Reset();

                stopwatch.Start();

                Console.WriteLine(Equal(arr));

                stopwatch.Stop();

                accumulatedTime1 += stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();

                stopwatch.Start();

                Console.WriteLine(BetterGreedy(arr));

                stopwatch.Stop();

                accumulatedTime2 += stopwatch.ElapsedMilliseconds;
            }

            Console.WriteLine($"CountOfOperations Solutions: {accumulatedTime1}ms");
            Console.WriteLine($"BetterGreedy Solutions: {accumulatedTime2}ms");
        }
    }
}