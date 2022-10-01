using _00.Demo.Knapsack;

public class Program
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Console.Write(matrix[row, column]);

                if (column < matrix.GetLength(1))
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        int maxCapacity = 4;

        Item[] items =
        {
            new Item("Flashlight", 2, 3),
            new Item("Laptop", 2, 1),
            new Item("Book", 1, 3),
        };

        int[,] dpMatrix = new int[items.Length + 1, maxCapacity + 1];
        HashSet<Item> takenItems = new HashSet<Item>();

        for (int item = 1; item < dpMatrix.GetLength(0); item++)
        {
            Item currentItem = items[item - 1];

            for (int capacity = 0; capacity < dpMatrix.GetLength(1); capacity++)
            {
                if(capacity >= currentItem.Weight)
                {
                    int previousMax = dpMatrix[item - 1, capacity];
                    int currentMax = dpMatrix[item - 1, capacity - currentItem.Weight] + currentItem.Value;

                    if(currentMax > previousMax)
                    {
                        dpMatrix[item, capacity] = currentMax;
                    }
                    else
                    {
                        dpMatrix[item, capacity] = previousMax;
                    }
                }
            }
        }

        int rowIndex = dpMatrix.GetLength(0) - 1;
        int columnIndex = dpMatrix.GetLength(1) - 1;
        int currentItemIndex = items.Length - 1;

        while(rowIndex >= 0 && columnIndex >= 0 && currentItemIndex >= 0)
        {
            Item currentItem = items[currentItemIndex];
            int currentValue = dpMatrix[rowIndex, columnIndex];
            int valueBeforeTaking = int.MinValue;

            if (columnIndex >= currentItem.Weight)
            {
                valueBeforeTaking = dpMatrix[rowIndex - 1, columnIndex - currentItem.Weight];
            }

            if(valueBeforeTaking + currentItem.Value == currentValue)
            {
                takenItems.Add(currentItem);
                columnIndex -= currentItem.Weight;
            }
            else
            {
                columnIndex--;
            }

            rowIndex--;
            currentItemIndex--;
        }

        Console.WriteLine($"Maximum value: {dpMatrix[dpMatrix.GetLength(0) - 1, dpMatrix.GetLength(1) - 1]}");
        Console.WriteLine($"Items: {string.Join(", ", takenItems.Select(x => x.Description))}");
    }
}