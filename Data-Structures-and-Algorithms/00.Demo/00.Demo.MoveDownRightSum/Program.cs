class Program
{
    public static void SetSumOfMatrix(
        int currentRow,
        int currentColumn,
        int[,] matrix,
        int[,] matrixOfSums)
    {
        int currentSum = matrix[currentRow, currentColumn];
        int upSum = 0;
        int leftSum = 0;

        if (currentRow > 0)
        {
            upSum = matrixOfSums[currentRow - 1, currentColumn];
        }

        if (currentColumn > 0)
        {
            leftSum = matrixOfSums[currentRow, currentColumn - 1];
        }

        currentSum += Math.Max(upSum, leftSum);

        matrixOfSums[currentRow, currentColumn] = currentSum;
    }

    public static void RecursiveTraverse(
        int currentRow, 
        int currentColumn,
        int[,] matrix,
        int[,] matrixOfSums)
    {
        if(currentRow == matrix.GetLength(0) - 1
            && currentColumn == matrix.GetLength(1) - 1)
        {
            SetSumOfMatrix(currentRow, currentColumn, matrix, matrixOfSums);
        }
        else
        {
            SetSumOfMatrix(currentRow, currentColumn, matrix, matrixOfSums);

            if (currentRow < matrix.GetLength(0) - 1)
            {
                RecursiveTraverse(currentRow + 1, currentColumn, matrix, matrixOfSums);
            }

            if(currentColumn < matrix.GetLength(1) - 1)
            {
                RecursiveTraverse(currentRow, currentColumn + 1, matrix, matrixOfSums);
            }
        }
    }

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
        int[,] matrix =
        {
            {2, 6, 1, 8, 9, 4, 2},
            {1, 8, 0, 3, 5, 6, 7},
            {1, 4, 8, 7, 2, 1, 8},
            {0, 9, 2, 8, 1, 7, 9},
            {2, 7, 1, 9, 7, 8, 2},
            {4, 5, 6, 1, 2, 5, 6},
            {9, 3, 5, 2, 8, 1, 9},
            {2, 3, 4, 1, 7, 2, 8}
        };

        int[,] matrixOfSums = new int[matrix.GetLength(0), matrix.GetLength(1)];

        RecursiveTraverse(0, 0, matrix, matrixOfSums);

        int currentRow = matrix.GetLength(0) - 1;
        int currentColumn = matrix.GetLength(1) - 1;

        List<string> path = new List<string>();

        while(currentRow >= 0 && currentColumn >= 0)
        {
            int upSum = 0;
            int leftSum = 0;

            if(currentRow > 0)
            {
                upSum = matrixOfSums[currentRow - 1, currentColumn];
            }

            if (currentColumn > 0)
            {
                leftSum = matrixOfSums[currentRow, currentColumn - 1];
            }

            if(upSum > leftSum)
            {
                path.Add("Down");
                currentRow--;
            } 
            else
            {
                path.Add("Right");
                currentColumn--;

            }
        }

        path.Reverse();

        Console.WriteLine(string.Join(Environment.NewLine, path));
    }
}