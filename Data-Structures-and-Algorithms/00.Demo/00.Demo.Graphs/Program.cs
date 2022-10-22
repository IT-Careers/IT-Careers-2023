public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, double>> cities = 
            new Dictionary<string, Dictionary<string, double>>();

        cities.Add("Sofia", new Dictionary<string, double>());        
        cities.Add("Ihtiman", new Dictionary<string, double>());        
        cities.Add("Pernik", new Dictionary<string, double>());        
        cities.Add("Kostinbrod", new Dictionary<string, double>());
        cities.Add("Plovdiv", new Dictionary<string, double>());
        cities.Add("Stara Zagora", new Dictionary<string, double>());
        cities.Add("Chelopechene", new Dictionary<string, double>());
        cities.Add("Peshtera", new Dictionary<string, double>());
        cities.Add("Pazardzhik", new Dictionary<string, double>());
        cities.Add("Ruse", new Dictionary<string, double>());
        cities.Add("Veliko Turnovo", new Dictionary<string, double>());
        cities.Add("Vidin", new Dictionary<string, double>());
        cities.Add("Belogradchik", new Dictionary<string, double>());

        cities["Sofia"].Add("Ihtiman", 30d);
        cities["Sofia"].Add("Plovdiv", 150d);
        cities["Ihtiman"].Add("Sofia", 30d);
        cities["Ihtiman"].Add("Plovdiv", 145.5d);
        cities["Sofia"].Add("Pernik", 20d);
        cities["Pernik"].Add("Sofia", 20d);
        cities["Sofia"].Add("Kostinbrod", 10d);
        cities["Kostinbrod"].Add("Sofia", 10d);
        cities["Sofia"].Add("Chelopechene", 10d);
        cities["Plovdiv"].Add("Stara Zagora", 100d);
        cities["Plovdiv"].Add("Peshtera", 50d);
        cities["Plovdiv"].Add("Pazardzhik", 40d);
        cities["Veliko Turnovo"].Add("Ruse", 50d);
        cities["Ruse"].Add("Veliko Turnovo", 40d);
        cities["Vidin"].Add("Belogradchik", 40d);

        HashSet<string> visited = new HashSet<string>();

        int countOfConnectedComponents = 0;

        foreach (var city in cities.Keys)
        {
            if (!visited.Contains(city))
            {
                countOfConnectedComponents++;
                Dfs(city, cities, visited);
            }
        }

        Console.WriteLine($"Connected components: {countOfConnectedComponents}");

        //Bfs(cities);
    }

    public static void Dfs(
        string currentNode, 
        Dictionary<string, Dictionary<string, double>> graph, 
        HashSet<string> visited)
    {
        if(!visited.Contains(currentNode))
        {
            visited.Add(currentNode);

            foreach (var child in graph[currentNode])
            {
                Console.WriteLine($"{currentNode} -> {child.Key} ({child.Value}km)");

                Dfs(child.Key, graph, visited);
            }
        }
    }

    public static void Bfs(Dictionary<string, Dictionary<string ,double>> cities)
    {
        HashSet<string> visited = new HashSet<string>();
        Queue<string> nodes = new Queue<string>();
        nodes.Enqueue("Sofia");

        while(nodes.Count > 0)
        {
            String currentNode = nodes.Dequeue();

            if (!visited.Contains(currentNode))
            {
                visited.Add(currentNode);

                foreach (var child in cities[currentNode])
                {
                    Console.WriteLine($"{currentNode} -> {child.Key} ({child.Value}km)");

                    nodes.Enqueue(child.Key);
                }
            }
        }
    }
}