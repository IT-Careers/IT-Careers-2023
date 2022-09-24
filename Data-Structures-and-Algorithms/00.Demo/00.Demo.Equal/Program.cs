using System;
using System.Numerics;

public class Program
{
    public static int[] GetMaxAndMin(List<int> arr)
    {
        int minValue = int.MaxValue;
        int maxValue = int.MinValue;

        int maxIndex = -1;

        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
                maxIndex = i;
            }

            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }

        return new int[] { minValue, maxIndex };
    }

    public static int Equal(List<int> arr)
    {
        int[] pieces = { 5, 2, 1 };

        int[] minValueAndMaxIndex = GetMaxAndMin(arr);

        int min = minValueAndMaxIndex[0];
        int maxIndex = minValueAndMaxIndex[1];
        int currentIndex = 0;

        int count = 0;

        while(min != arr[maxIndex])
        {
            if (arr[maxIndex] - min >= pieces[currentIndex])
            {
                arr[maxIndex] -= pieces[currentIndex];

                minValueAndMaxIndex = GetMaxAndMin(arr);

                min = minValueAndMaxIndex[0];
                maxIndex = minValueAndMaxIndex[1];

                count++;
            }
            else
            {
                currentIndex++;
            }
        }

        return count;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(Equal(new List<int> { 55, 101, 101 }));
    }
}