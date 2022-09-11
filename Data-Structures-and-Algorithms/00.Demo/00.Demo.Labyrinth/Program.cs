class Program
{
    public static void FindPath(
        string[,] labyrinth, 
        int currentRow, 
        int currentColumn, 
        List<string> currentPath,
        List<List<string>> paths,
        string direction)
    {
        if(!IsInLabyrinth(labyrinth, currentRow, currentColumn))
        {
            return;
        }
        else if (labyrinth[currentRow, currentColumn] == "e")
        {
            currentPath.Add(direction);
            paths.Add(new List<string>(currentPath));
            currentPath.RemoveAt(currentPath.Count - 1);
            return;
        }
        else if(!IsEmptySpace(labyrinth, currentRow, currentColumn))
        {
            return;
        } 
        else
        {
            if (direction != null)
            {
                // First case scenario
                currentPath.Add(direction);
            }

            labyrinth[currentRow, currentColumn] = ".";

            Thread.Sleep(500);
            Console.Clear();
            PrintLabyrinth(labyrinth);

            FindPath(labyrinth, currentRow - 1, currentColumn, currentPath, paths, "Up");
            FindPath(labyrinth, currentRow, currentColumn + 1, currentPath, paths, "Right");
            FindPath(labyrinth, currentRow + 1, currentColumn, currentPath, paths, "Down");
            FindPath(labyrinth, currentRow, currentColumn - 1, currentPath, paths, "Left");

            if (currentPath.Count != 0)
            {
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            labyrinth[currentRow, currentColumn] = "-";
        }
    }

    private static bool IsInLabyrinth(string[,] labyrinth, int currentRow, int currentColumn)
    {
        return currentRow >= 0
            && currentRow < labyrinth.GetLength(0)
            && currentColumn >= 0
            && currentColumn < labyrinth.GetLength(1);
    }

    private static bool IsEmptySpace(string[,] labyrinth, int currentRow, int currentColumn)
    {
        return labyrinth[currentRow, currentColumn] == "-";
    }

    public static int[] FindStart(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int column = 0; column < labyrinth.GetLength(1); column++)
            {
                if (labyrinth[row, column] == "s")
                {
                    return new int[] { row, column };
                }
            }
        }

        return null;
    }

    public static void PrintLabyrinth(string[,] labyrinth)
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int column = 0; column < labyrinth.GetLength(1); column++)
            {
                Console.Write(labyrinth[row, column]);

                if (column < labyrinth.GetLength(1))
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        string[,] labyrinth =
        {
            { "*", "e", "*", "*", "*", "*", "*", "*" },
            { "*", "-", "*", "-", "-", "-", "-", "*" },
            { "*", "-", "*", "-", "*", "*", "-", "*" },
            { "*", "-", "*", "-", "*", "-", "-", "*" },
            { "*", "-", "*", "-", "*", "*", "*", "*" },
            { "*", "-", "-", "-", "-", "-", "-", "*" },
            { "*", "-", "*", "*", "*", "*", "-", "*" },
            { "*", "-", "-", "-", "-", "-", "-", "*" },
            { "*", "-", "*", "*", "*", "*", "*", "*" },
            { "*", "-", "-", "-", "-", "-", "-", "*" },
            { "*", "-", "*", "*", "*", "*", "-", "*" },
            { "*", "-", "*", "*", "*", "*", "-", "*" },
            { "*", "-", "*", "*", "*", "*", "-", "*" },
            { "*", "-", "*", "*", "-", "-", "-", "*" },
            { "*", "-", "*", "*", "-", "*", "-", "*" },
            { "*", "-", "*", "*", "-", "*", "-", "*" },
            { "*", "*", "*", "*", "s", "*", "*", "*" },
        };

        int[] startingIndices = FindStart(labyrinth);

        int currentRow = startingIndices[0];
        int currentColumn = startingIndices[1];

        labyrinth[currentRow, currentColumn] = "-";

        List<List<string>> paths = new List<List<string>>();

        FindPath(labyrinth, currentRow, currentColumn, new List<string>(), paths, null);

        Console.WriteLine($"There are {paths.Count} paths...");

        // Find path with shortest length
        
        foreach (var path in paths)
        {
            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine();
        }
    }
}