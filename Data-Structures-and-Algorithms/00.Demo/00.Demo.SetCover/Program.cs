using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] u = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Greedy failure case (Source: https://pages.cs.wisc.edu/~shuchi/courses/787-F07/scribe-notes/lecture02.pdf)
        //int[] u = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //int[][] s =
        //{
        //    new int[]{ 1, 2, 3, 8, 9, 10 },
        //    new int[]{ 1, 2, 3, 4, 5 },
        //    new int[]{ 4, 5, 7 },
        //    new int[]{ 5, 6, 7 },
        //    new int[]{ 6, 7, 8, 9, 10 },
        //};
        int sCount = int.Parse(Console.ReadLine());
        int[][] s = new int[sCount][];
        for (int i = 0; i < s.Length; i++)
        {
            s[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        List<int[]> setCover = FindSetCover(u, s);

        Console.WriteLine($"{{ {string.Join(", ", setCover.Select(set => $"{{{string.Join(", ", set)}}}"))} }}");
    }

    private static List<int[]> FindSetCover(int[] u, int[][] s)
    {
        HashSet<int> uncovered = new HashSet<int>(u);
        List<int[]> resultSubsets = new List<int[]>();

        while (uncovered.Count > 0)
        {
            int[] resultSubset = s.OrderByDescending(subset =>
            {
                int uncoveredElementsCount = 0;

                for (int i = 0; i < subset.Length; i++)
                {
                    if (uncovered.Contains(subset[i]))
                    {
                        uncoveredElementsCount++;
                    }
                }

                return uncoveredElementsCount;
            }).ThenBy(subset => subset.Length).First();

            for (int i = 0; i < resultSubset.Length; i++)
            {
                uncovered.Remove(resultSubset[i]);
            }

            resultSubsets.Add(resultSubset);
        }

        return resultSubsets;
    }
}