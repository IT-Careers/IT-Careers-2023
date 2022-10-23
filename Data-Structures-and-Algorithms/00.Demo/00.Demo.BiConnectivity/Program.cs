public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        
        int n = 12;

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, new List<int>());
        }

        AddEdge(graph, 0, 1);
        AddEdge(graph, 0, 6);
        AddEdge(graph, 0, 2);
        AddEdge(graph, 0, 7);
        AddEdge(graph, 0, 9);
        AddEdge(graph, 1, 6);
        AddEdge(graph, 2, 7);
        AddEdge(graph, 3, 4);
        AddEdge(graph, 4, 10);
        AddEdge(graph, 4, 6);
        AddEdge(graph, 5, 7);
        AddEdge(graph, 6, 10);
        AddEdge(graph, 6, 8);
        AddEdge(graph, 6, 11);
        AddEdge(graph, 7, 9);
        AddEdge(graph, 8, 11);


        foreach (var node in graph.Keys)
        {
            Dictionary<int, List<int>> newGraph = new Dictionary<int, List<int>>(graph);
            newGraph.Remove(node);

            bool[] visited = new bool[n];
            int connectedComponents = 0;

            foreach (var otherNode in newGraph.Keys)
            {
                if (!visited[otherNode])
                {
                    connectedComponents++;
                    Dfs(otherNode, newGraph, visited);
                }
            }

            if(connectedComponents > 1)
            {
                Console.WriteLine(node);
            }
        }
        
    }

    public static void Dfs(int currentNode, Dictionary<int, List<int>> graph, bool[] visited)
    {
        if (!visited[currentNode] && graph.ContainsKey(currentNode))
        {
            visited[currentNode] = true;

            foreach (var child in graph[currentNode])
            {
                Dfs(child, graph, visited);
            }
        }
    }


    public static void AddEdge(
        Dictionary<int, List<int>> graph,
        int parentNode,
        int childNode)
    {
        graph[parentNode].Add(childNode);
        graph[childNode].Add(parentNode);
    }
}