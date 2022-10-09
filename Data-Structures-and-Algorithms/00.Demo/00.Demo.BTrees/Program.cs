namespace _00.Demo.BTrees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BTree<int> bTree = new BTree<int>();

            bTree.Insert(50);
            bTree.Insert(100);
            bTree.Insert(150);
            bTree.Insert(200);
            bTree.Insert(250);
            bTree.Insert(25);
            bTree.Insert(125);
            bTree.Insert(225);
            bTree.Insert(26);
            bTree.Insert(126);
            bTree.Insert(226);
            bTree.Insert(130);
            bTree.Insert(129);
            bTree.Insert(128);
            bTree.Insert(127);

            var a = 5;
        }
    }
}