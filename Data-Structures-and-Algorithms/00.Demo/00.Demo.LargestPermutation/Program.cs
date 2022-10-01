public class Program
{
    public static List<int> largestPermutation(int k, List<int> arr)
    {
        int[] memoIndex = new int[arr.Count + 1];

        for (int i = 0; i < arr.Count; i++)
        {
            memoIndex[arr[i]] = i;
        }

        for (int i = 0; i < Math.Min(arr.Count, k); i++)
        {
            if (arr[i] != arr.Count - i)
            {
                int maxIndex = memoIndex[arr.Count - i];
                
                int memoTemp = memoIndex[arr[i]];
                memoIndex[arr[i]] = memoIndex[arr.Count - i];
                memoIndex[arr.Count - i] = memoTemp;

                int temp = arr[i];
                arr[i] = arr[maxIndex];
                arr[maxIndex] = temp;
            } 
            else
            {
                k++;
            }
        }

        return arr;
    }

    public static void Main(string[] args)
    {
        List<int> permutation = Console.ReadLine().Split().Select(int.Parse).ToList();
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(string.Join(" ", largestPermutation(k, permutation)));
    }
}