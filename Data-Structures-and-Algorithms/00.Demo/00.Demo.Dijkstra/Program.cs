public class Program
{
    public static void Main(string[] args)
    {
        int n = 12;

        Dictionary<int, Dictionary<int, int>> weightedGraph = new Dictionary<int, Dictionary<int, int>>();

        for (int i = 0; i < n; i++)
        {
            weightedGraph.Add(i, new Dictionary<int, int>());
        }

        AddEdge(weightedGraph, 0, 6, 10);
        AddEdge(weightedGraph, 0, 8, 12);
        AddEdge(weightedGraph, 6, 4, 17);
        AddEdge(weightedGraph, 6, 5, 6);
        AddEdge(weightedGraph, 8, 5, 3);
        AddEdge(weightedGraph, 8, 2, 14);
        AddEdge(weightedGraph, 4, 5, 5);
        AddEdge(weightedGraph, 4, 11, 11);
        AddEdge(weightedGraph, 4, 1, 20);
        AddEdge(weightedGraph, 5, 11, 33);
        AddEdge(weightedGraph, 2, 11, 9);
        AddEdge(weightedGraph, 2, 7, 15);
        AddEdge(weightedGraph, 11, 1, 6);
        AddEdge(weightedGraph, 11, 7, 20);
        AddEdge(weightedGraph, 7, 1, 26);
        AddEdge(weightedGraph, 7, 9, 3);
        AddEdge(weightedGraph, 1, 9, 5);
        AddEdge(weightedGraph, 3, 10, 7);

        int origin = 0;
        int target = 9;

        bool[] visited = new bool[n];
        int[] distances = new int[n];
        int[] previous = new int[n];

        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            previous[i] = -1;
        }

        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

        priorityQueue.Enqueue(origin, 0);
        distances[origin] = 0;

        while(priorityQueue.Count > 0)
        {
            int current = priorityQueue.Dequeue();
            
            if (!visited[current])
            {
                visited[current] = true;

                foreach (var child in weightedGraph[current])
                {
                    int distanceFromStart = distances[child.Key];
                    int distanceFromParent = distances[current] + child.Value;

                    if(distanceFromStart > distanceFromParent)
                    {
                        distances[child.Key] = distanceFromParent;
                        previous[child.Key] = current;
                    } 
                    else
                    {
                        distances[child.Key] = distanceFromStart;
                    }

                    priorityQueue.Enqueue(child.Key, distances[child.Key]);
                }
            }
        }

        LinkedList<int> path = new LinkedList<int>();

        int previousNode = target;

        while (previousNode != -1)
        {
            path.AddFirst(previousNode);
            previousNode = previous[previousNode];
        }

        Console.WriteLine(string.Join(" -> ", path) + $" ({distances[target]})");
    }

    public static void AddEdge(
        Dictionary<int, Dictionary<int, int>> weightedGraph,
        int parentNode,
        int childNode,
        int weight)
    {
        weightedGraph[parentNode].Add(childNode, weight);
        weightedGraph[childNode].Add(parentNode, weight);
    }
}