public class Tree<T>
{
    public Tree(T value) : this(value, new List<Tree<T>>())
    {
    }

    public Tree(T value, List<Tree<T>> children)
    {
        this.Value = value;
        this.Children = children;
    }

    public T Value { get; set; }

    public Tree<T> Parent { get; set; }

    public List<Tree<T>> Children { get; set; }

    private void InternalDFS(Tree<T> currentNode, List<T> currentOrder)
    {
        foreach (var child in currentNode.Children)
        {
            this.InternalDFS(child, currentOrder);
        }

        currentOrder.Add(currentNode.Value); // Traversed
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> order = new List<T>();

        this.InternalDFS(this, order);

        return order;
    }

    public IEnumerable<T> OrderBFS()
    {
        List<T> order = new List<T>();

        Queue<Tree<T>> traversalQueue = new Queue<Tree<T>>();
        traversalQueue.Enqueue(this);

        while(traversalQueue.Count > 0)
        {
            Tree<T> currentNode = traversalQueue.Dequeue();
            order.Add(currentNode.Value); // traversal

            foreach (var child in currentNode.Children)
            {
                traversalQueue.Enqueue(child);
            }
        }

        return order;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Tree<int> root = new Tree<int>(7);

        Tree<int> rootFirstChild = new Tree<int>(19);
        Tree<int> rootSecondChild = new Tree<int>(21);
        Tree<int> rootThirdChild = new Tree<int>(14);

        root.Children.Add(rootFirstChild);
        root.Children.Add(rootSecondChild);
        root.Children.Add(rootThirdChild);

        Tree<int> rootFirstChildFirstChild = new Tree<int>(1);
        Tree<int> rootFirstChildSecondChild = new Tree<int>(12);
        Tree<int> rootFirstChildThirdChild = new Tree<int>(31);

        rootFirstChild.Children.Add(rootFirstChildFirstChild);
        rootFirstChild.Children.Add(rootFirstChildSecondChild);
        rootFirstChild.Children.Add(rootFirstChildThirdChild);

        Tree<int> rootThirdChildFirstChild = new Tree<int>(23);
        Tree<int> rootThirdChildSecondChild = new Tree<int>(6);

        rootThirdChild.Children.Add(rootThirdChildFirstChild);
        rootThirdChild.Children.Add(rootThirdChildSecondChild);

        //Console.WriteLine(string.Join(" ", root.OrderDFS()));
        //Console.WriteLine(string.Join(" ", root.OrderBFS()));
    }
}