public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

        //graph.Add("Pesho", new HashSet<string>());
        //graph.Add("Gosho", new HashSet<string>());
        //graph.Add("Tosho", new HashSet<string>());
        //graph.Add("Sasho", new HashSet<string>());
        //graph.Add("Yasho", new HashSet<string>());
        //graph.Add("Prakash", new HashSet<string>());
        //graph.Add("Stamat", new HashSet<string>());

        //graph["Pesho"].Add("Gosho");
        //graph["Pesho"].Add("Tosho");
        //graph["Pesho"].Add("Prakash");

        //graph["Gosho"].Add("Pesho");
        //graph["Gosho"].Add("Tosho");
        //graph["Yasho"].Add("Sasho");
        //1
        //graph["Tosho"].Add("Gosho");

        //graph["Sasho"].Add("Gosho");
        //graph["Sasho"].Add("Tosho");

        //graph["Prakash"].Add("Pesho");
        //graph["Prakash"].Add("Stamat");

        //graph["Stamat"].Add("Prakash");

        graph["A"] = new HashSet<string>();
        graph["B"] = new HashSet<string>();
        graph["C"] = new HashSet<string>();
        graph["D"] = new HashSet<string>();
        graph["E"] = new HashSet<string>();
        graph["F"] = new HashSet<string>();

        graph["A"].Add("B");
        graph["A"].Add("C");
        graph["B"].Add("D");
        graph["B"].Add("F");
        graph["C"].Add("E");
        graph["C"].Add("B");
        graph["C"].Add("D");
        graph["D"].Add("E");
        graph["D"].Add("F");

        Console.WriteLine(string.Join(" -> ", TopologicalSort(graph)));
    }

    /// <summary>
    /// Topological Sort -> Source Removal Approach
    /// </summary>
    /// <param name="graph"></param>
    /// <returns></returns>
    public static HashSet<string> TopologicalSort(Dictionary<string, HashSet<string>> graph)
    {
        HashSet<string> result = new HashSet<string>();

        while(graph.Count > result.Count)
        {
            bool foundAny = false;

            foreach (var node in graph)
            {
                if (!result.Contains(node.Key))
                {
                    bool isContained = false;

                    foreach (var otherNode in graph)
                    {
                        if (!result.Contains(otherNode.Key) && otherNode.Value.Contains(node.Key))
                        {
                            isContained = true;
                            break;
                        }
                    }

                    if (!isContained)
                    {
                        foundAny = true;
                        result.Add(node.Key);
                    }
                }
            }

            if(!foundAny)
            {
                foreach (var item in graph)
                {
                    if(!result.Contains(item.Key))
                    {
                        result.Add(item.Key);
                        break;
                    }
                }
            }
        }

        return result;
    }
} 