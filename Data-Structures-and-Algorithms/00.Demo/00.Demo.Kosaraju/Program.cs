public class Program
{
    public static void Main(string[] args) 
    { 
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        int n = 14;

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
        }

        graph[0].Add(1);
        graph[0].Add(11);
        graph[0].Add(13);
        graph[1].Add(6);
        graph[2].Add(0);
        graph[3].Add(4);
        graph[4].Add(3);
        graph[4].Add(6);
        graph[5].Add(13);
        graph[6].Add(11);
        graph[6].Add(0);
        graph[7].Add(12);
        graph[8].Add(6);
        graph[8].Add(11);
        graph[9].Add(0);
        graph[10].Add(10);
        graph[10].Add(4);
        graph[12].Add(7);
        graph[13].Add(9);
        graph[13].Add(2);

        bool[] visited = new bool[n];
        List<int> connectedNodes = new List<int>();

        foreach (var node in graph.Keys)
        {
            if(!visited[node])
            {
                Dfs(node, graph, visited, connectedNodes);
            }
        }

        Dictionary<int, int> connectedComponentsRoots = new Dictionary<int, int>();
        Dictionary<int, List<int>> connectedComponents = new Dictionary<int, List<int>>();

        foreach (var node in connectedNodes)
        {
            if(!connectedComponentsRoots.ContainsKey(node))
            {
                connectedComponents.Add(node, new List<int>());
                OtherDfs(node, node, connectedComponentsRoots, graph, connectedComponents);
            }
        }
    }


    public static void OtherDfs(
        int currentNode, 
        int currentRoot, 
        Dictionary<int, int> connectedComponentsRoots, 
        Dictionary<int, List<int>> graph,
        Dictionary<int, List<int>> connectedComponents)
    {
        if(!connectedComponentsRoots.ContainsKey(currentNode))
        {
            connectedComponentsRoots[currentNode] = currentRoot;
            connectedComponents[currentRoot].Add(currentNode);

            foreach (var child in graph[currentNode])
            {
                OtherDfs(child, currentRoot, connectedComponentsRoots, graph, connectedComponents);
            }
        }
    }

    public static void Dfs(int currentNode, Dictionary<int, List<int>> graph, bool[] visited, List<int> connectedNodes) 
    {
        if(!visited[currentNode])
        {
            visited[currentNode] = true;

            foreach (var child in graph[currentNode])
            {
                Dfs(child, graph, visited, connectedNodes);
            }

            connectedNodes.Add(currentNode);
        }
    }
}