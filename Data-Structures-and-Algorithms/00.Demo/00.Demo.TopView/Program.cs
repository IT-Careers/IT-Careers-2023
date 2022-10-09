using System.Text;

public class Program
{
    class Node
    {
        public int Depth { get; set; }

        public int LeftDistanceFromRoot { get; set; }

        public int RightDistanceFromRoot { get; set; }

        public int Value { get; set; }

        public Node LeftChild { get; set; }

        public Node RightChild { get; set; }
    }

    static Node Root { get; set; }

    static void InternalInsert(Node currentNode, int value, int depth = 0, int leftDistanceFromRoot = 0, int rightDistanceFromRoot = 0)
    {
        if(currentNode.Value > value)
        {
            if(currentNode.LeftChild == null)
            {
                currentNode.LeftChild = new Node { 
                    Value = value, 
                    Depth = depth, 
                    LeftDistanceFromRoot = leftDistanceFromRoot + 1, 
                    RightDistanceFromRoot = rightDistanceFromRoot - 1
                };
                listOfNodes.Add(currentNode.LeftChild);
            }
            else
            {
                InternalInsert(currentNode.LeftChild, value, depth + 1, leftDistanceFromRoot + 1, rightDistanceFromRoot - 1);
            }
        }
        else
        {
            if (currentNode.RightChild == null)
            {
                currentNode.RightChild = new Node
                {
                    Value = value,
                    Depth = depth,
                    LeftDistanceFromRoot = leftDistanceFromRoot - 1,
                    RightDistanceFromRoot = rightDistanceFromRoot + 1
                };

                listOfNodes.Add(currentNode.RightChild);
            }
            else
            {
                InternalInsert(currentNode.RightChild, value, depth + 1, leftDistanceFromRoot - 1, rightDistanceFromRoot + 1);
            }
        }
    }

    static List<Node> listOfNodes = new List<Node>();

    static void Insert(int value)
    {
        if(Root == null)
        {
            Root = new Node { Value = value };
            listOfNodes.Add(Root);
        }
        else
        {
            InternalInsert(Root, value, 1);
        }
    }

    static void TopView()
    {
        Dictionary<int, Node> rightAlignedNodes = new Dictionary<int, Node>();

        foreach (var item in listOfNodes.Where(node => node.RightDistanceFromRoot > 0))
        {
            if(!rightAlignedNodes.ContainsKey(item.RightDistanceFromRoot))
            {
                rightAlignedNodes[item.RightDistanceFromRoot] = item;
            }
            else if(item.Depth < rightAlignedNodes[item.RightDistanceFromRoot].Depth)
            {
                rightAlignedNodes[item.RightDistanceFromRoot] = item;
            }
        }

        Dictionary<int, Node> leftAlignedNodes = new Dictionary<int, Node>();

        foreach (var item in listOfNodes.Where(node => node.LeftDistanceFromRoot > 0).OrderByDescending(node => node.LeftDistanceFromRoot))
        {
            if (!leftAlignedNodes.ContainsKey(item.LeftDistanceFromRoot))
            {
                leftAlignedNodes[item.LeftDistanceFromRoot] = item;
            }
            else if (item.Depth < leftAlignedNodes[item.LeftDistanceFromRoot].Depth)
            {
                leftAlignedNodes[item.LeftDistanceFromRoot] = item;
            }
        }

        StringBuilder result = new StringBuilder();

        result.Append(string.Join(" ", leftAlignedNodes.Values.Select(node => node.Value)));
        result.Append(" " + Root.Value + " ");
        result.Append(string.Join(" ", rightAlignedNodes.Values.Select(node => node.Value)));

        Console.WriteLine(result.ToString().Trim());
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string[] inputParams = Console.ReadLine().Split();

        for (int i = 0; i < inputParams.Length; i++)
        {
            Insert(int.Parse(inputParams[i]));
        }

        TopView();
    }
}