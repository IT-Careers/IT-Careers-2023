public class Program
{
    static int steps = 0;

    public static int BinarySearch(int numberToBeFound, int[] numbers, int startIndex, int endIndex)
    {
        steps++;

        int median = Math.Max((endIndex - startIndex) / 2, 1);
        int currentMedianIndex = startIndex + median;

        if (startIndex == endIndex)
        {
            return -1;
        }

        if (numberToBeFound == numbers[currentMedianIndex])
        {
            return currentMedianIndex;
        }

        if(numberToBeFound > numbers[currentMedianIndex])
        {
            return BinarySearch(numberToBeFound, numbers, currentMedianIndex, endIndex);
        }
        else
        {
            return BinarySearch(numberToBeFound, numbers, startIndex, currentMedianIndex);
        }
    }

    public static void Main(string[] args)
    {
        Random random = new Random();

        int randomLength = random.Next(5, 1000);
        int[] numbers = new int[randomLength];

        for (int i = 0; i < randomLength; i++)
        {
            numbers[i] = random.Next(1, 500);
        }

        numbers = numbers.OrderBy(x => x).ToArray();

        Console.WriteLine($"Array is with length - {numbers.Length}");
        Console.WriteLine($"Array is: {string.Join(" ", numbers)}");

        int numberToBeFound = int.Parse(Console.ReadLine());

        Console.WriteLine($"Index: {BinarySearch(numberToBeFound, numbers, 0, numbers.Length - 1)}");
        Console.WriteLine($"Steps taken: {steps}");
    }
}