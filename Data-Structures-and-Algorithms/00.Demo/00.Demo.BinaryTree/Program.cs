using System;

public class BinaryTree<T>
{
    public BinaryTree(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }

    public BinaryTree<T> LeftChild { get; set; }

    public BinaryTree<T> RightChild { get; set; }

    private void InternalPreOrderDFS(BinaryTree<T> currentNode, Action<T> action)
    {
        action.Invoke(currentNode.Value);

        if(currentNode.LeftChild != null)
        {
            this.InternalPreOrderDFS(currentNode.LeftChild, action);
        }

        if (currentNode.RightChild != null)
        {
            this.InternalPreOrderDFS(currentNode.RightChild, action);
        }
    }

    private void InternalInOrderDFS(BinaryTree<T> currentNode, Action<T> action)
    {
        if (currentNode.LeftChild != null)
        {
            this.InternalInOrderDFS(currentNode.LeftChild, action);
        }

        action.Invoke(currentNode.Value);

        if (currentNode.RightChild != null)
        {
            this.InternalInOrderDFS(currentNode.RightChild, action);
        }
    }

    private void InternalPostOrderDFS(BinaryTree<T> currentNode, Action<T> action)
    {
        if (currentNode.LeftChild != null)
        {
            this.InternalPostOrderDFS(currentNode.LeftChild, action);
        }

        if (currentNode.RightChild != null)
        {
            this.InternalPostOrderDFS(currentNode.RightChild, action);
        }

        action.Invoke(currentNode.Value);
    }

    public void PreOrderDFS(Action<T> action)
    {
        this.InternalPreOrderDFS(this, action);
    }

    public void InOrderDFS(Action<T> action)
    {
        this.InternalInOrderDFS(this, action);
    }

    public void PostOrderDFS(Action<T> action)
    {
        this.InternalPostOrderDFS(this, action);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BinaryTree<int> root = new BinaryTree<int>(17);
        BinaryTree<int> node9 = new BinaryTree<int>(9);
        BinaryTree<int> node25 = new BinaryTree<int>(25);
        BinaryTree<int> node3 = new BinaryTree<int>(3);
        BinaryTree<int> node11 = new BinaryTree<int>(11);
        BinaryTree<int> node20 = new BinaryTree<int>(20);
        BinaryTree<int> node31 = new BinaryTree<int>(31);

        root.LeftChild = node9;
        root.RightChild = node25;
        node9.LeftChild = node3;
        node9.RightChild = node11;
        node25.LeftChild = node20;
        node25.RightChild = node31;

        List<int> values = new List<int>();

        root.InOrderDFS((value) => values.Add(value));

        Console.WriteLine(string.Join(" ", values));
    }
}