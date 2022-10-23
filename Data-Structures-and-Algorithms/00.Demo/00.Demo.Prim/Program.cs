public class Program
{
    public static void Main(string[] args)
    {
        string[] nodes = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        List<int[]> edges = new List<int[]>();
        edges.Add(new int[] { 0, 1, 4 });
        edges.Add(new int[] { 0, 2, 5 });
        edges.Add(new int[] { 1, 3, 2 });
        edges.Add(new int[] { 0, 3, 9 });
        edges.Add(new int[] { 2, 3, 20 });
        edges.Add(new int[] { 2, 4, 7 });
        edges.Add(new int[] { 3, 4, 8 });
        edges.Add(new int[] { 4, 5, 12 });
        edges.Add(new int[] { 7, 8, 7 });
        edges.Add(new int[] { 6, 7, 8 });
        edges.Add(new int[] { 6, 8, 10 });

        List<int[]> edges2 = new List<int[]>();
        edges2.Add(new int[] { 0, 1, 4 });
        edges2.Add(new int[] { 0, 7, 8 });
        edges2.Add(new int[] { 1, 7, 11 });
        edges2.Add(new int[] { 1, 2, 8 });
        edges2.Add(new int[] { 2, 8, 2 });
        edges2.Add(new int[] { 7, 8, 7 });
        edges2.Add(new int[] { 7, 6, 1 });
        edges2.Add(new int[] { 8, 6, 6 });
        edges2.Add(new int[] { 2, 3, 7 });
        edges2.Add(new int[] { 5, 2, 4 });
        edges2.Add(new int[] { 6, 5, 2 });
        edges2.Add(new int[] { 3, 5, 14 });
        edges2.Add(new int[] { 3, 4, 9 });
        edges2.Add(new int[] { 4, 5, 10 });


        List<int[]> forest = new List<int[]>();

        //forest.ForEach(edge =>
        //{
        //    Console.WriteLine($"{nodes[edge[0]]} -> {nodes[edge[1]]} ({edge[2]})");
        //});

        forest.ForEach(edge =>
        {
            Console.WriteLine($"{edge[0]} -> {edge[1]} ({edge[2]})");
        });
    }
}