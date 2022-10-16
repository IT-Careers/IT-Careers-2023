using _00.Demo.RedBlackTree;

public class Program
{
    // !!!IMPORTANT!!! This is a 2-3 Red-Black Tree
    public static void Main(string[] args)
    {
        RedBlackTree<int> redBlackTree = new RedBlackTree<int>();

        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            redBlackTree.Insert(random.Next(1, 1000000));
        }

        Console.WriteLine(redBlackTree.Max());
        Console.WriteLine(RedBlackTree<int>.stepsTaken);

        redBlackTree.EachInOrder(Console.WriteLine);
    } 
}