using System.Drawing;

namespace _00.Demo.Knapsack
{
    public class Item
    {
        public Item(string description, int weight, int value)
        {
            this.Description = description;
            this.Weight = weight;
            this.Value = value;
        }

        public string Description { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }
}
