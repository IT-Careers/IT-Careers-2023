namespace _00.Demo.GraphsGame
{
    public class Graph
    {
        public Graph()
        {
            this.Locations = new Dictionary<string, Location>();
        }

        public Dictionary<string, Location> Locations { get; set; }

        public void AddNode(string node, int flag)
        {
            this.Locations.Add(node, new Location(node, flag));
        }

        public void AddEdge(string parentNode, string childNode, int weight)
        {
            this.Locations[parentNode].Children.Add(childNode, weight);
        }

        public Location GetNode(string nodeName)
        {
            return this.Locations[nodeName];
        }

        public Dictionary<string, int> GetChildren(string nodeName)
        {
            return this.Locations[nodeName].Children;
        }
    }
}
