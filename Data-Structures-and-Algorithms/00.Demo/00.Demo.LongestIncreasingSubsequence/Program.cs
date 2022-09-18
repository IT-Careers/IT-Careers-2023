using System.Linq;

class Program
{
    public static void RecursiveTraverse(
        int currentIndex, 
        int[] sequence, 
        List<int> currentSubsequence, 
        List<List<int>> allSubsequences)
    {
        if(currentIndex >= sequence.Length)
        {
            return;
        } 
        else
        {
            for (int i = currentIndex; i < sequence.Length; i++)
            {
                if (sequence[i] > currentSubsequence[currentSubsequence.Count - 1])
                {
                    currentSubsequence.Add(sequence[i]);
                    RecursiveTraverse(i + 1, sequence, currentSubsequence, allSubsequences);
                    currentSubsequence.RemoveAt(currentSubsequence.Count - 1);
                }
            }
        } 

        allSubsequences.Add(new List<int>(currentSubsequence));
    }

    public static void RecursiveSolution(int[] sequence)
    {
        List<List<int>> allSubsequences = new List<List<int>>();

        for (int i = 0; i < sequence.Length; i++)
        {
            List<int> currentSubsequence = new List<int>();
            currentSubsequence.Add(sequence[i]);
            RecursiveTraverse(i + 1, sequence, currentSubsequence, allSubsequences);
        }

        Console.WriteLine("Longest Increasing Subsequence: ");

        var subsequence = allSubsequences
            .OrderByDescending(s => s.Count)
            .FirstOrDefault();

        Console.WriteLine(string.Join(" -> ", subsequence));
    }

    public static void DPSolution(int[] sequence)
    {
        int[] lengths = new int[sequence.Length];
        int[] previous = new int[sequence.Length];

        int count = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            lengths[i] = 1;
            previous[i] = -1;

            for (int j = 0; j < i; j++)
            {
                count++; 
                if (sequence[i] > sequence[j])
                {
                    previous[i] = j;
                    lengths[i] = lengths[j] + 1;
                }
            }
        }

        Console.WriteLine("Iterations: " + count);

        int maxLengthIndex = 0;
        int currentMaxLength = 0;

        for (int i = 0; i < lengths.Length; i++)
        {
            if (lengths[i] >= currentMaxLength)
            {
                maxLengthIndex = i;
                currentMaxLength = lengths[i];
            }
        }

        List<int> longestIncreasingSubsequence = new List<int>();

        while (maxLengthIndex >= 0)
        {
            longestIncreasingSubsequence.Add(sequence[maxLengthIndex]);
            maxLengthIndex = previous[maxLengthIndex];
        }

        longestIncreasingSubsequence.Reverse();
        Console.WriteLine(string.Join(" -> ", longestIncreasingSubsequence));
    }

    public static void Main(string[] args)
    {
        int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

        DPSolution(sequence);
    }
}