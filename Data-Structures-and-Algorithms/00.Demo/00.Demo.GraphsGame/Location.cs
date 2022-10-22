namespace _00.Demo.GraphsGame
{
    public class Location
    {
        public Location(string name, int flag)
        {
            this.Name = name;
            this.Flag = flag;
            this.Children = new Dictionary<string, int>();
        }

        public string Name { get; set; }

        public int Flag { get; set; }

        public Dictionary<string, int> Children { get; set; }
    }
}
