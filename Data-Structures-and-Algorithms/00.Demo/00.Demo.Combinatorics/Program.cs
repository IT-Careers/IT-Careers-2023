class Program
{
    static int steps = 0;

    public static void SwapPermute(
        int index,
        string[] set)
    {
        if (index >= set.Length)
        {
            Console.WriteLine(string.Join(" ", set));
        }
        else
        {
            SwapPermute(index + 1, set);

            for (int i = index + 1; i < set.Length; i++)
            {
                Swap(set, index, i);
                SwapPermute(index + 1, set);
                Swap(set, index, i);
            }
        }
    }

    public static void Permute(
        int index,
        string[] set,
        bool[] used,
        string[] currentPermutation)
    {
        if (index >= currentPermutation.Length)
        {
            Console.WriteLine(string.Join(" ", currentPermutation));
        }
        else
        {
            for (int i = 0; i < set.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    currentPermutation[index] = set[i];
                    Permute(index + 1, set, used, currentPermutation);
                    used[i] = false;
                }
            }
        }
    }

    private static void Swap(string[] set, int first, int second)
    {
        string temp = set[first];
        set[first] = set[second];
        set[second] = temp;
    }

    public static void Main(string[] args)
    {
        string[] set = { "A", "B", "B" };

        Permute(0, set, new bool[set.Length], new string[set.Length]);

        Console.WriteLine($"Steps: {steps}");
    }
}