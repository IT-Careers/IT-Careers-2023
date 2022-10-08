public class BinarySearchTreeNode<T>  where T : IComparable<T>
{
    public BinarySearchTreeNode(T value)
    {
        this.Value = value;
    }
    
    public BinarySearchTreeNode(T value, BinarySearchTreeNode<T> leftChild, BinarySearchTreeNode<T> rightChild) : this(value)
    {
        LeftChild = leftChild;
        RightChild = rightChild;
    }

    public T Value { get; set; }

    public BinarySearchTreeNode<T> LeftChild { get; set; }

    public BinarySearchTreeNode<T> RightChild { get; set; }
}

public class BinarySearchTree<T> where T : IComparable<T>
{
    public BinarySearchTree()
    {
    }

    public BinarySearchTree(BinarySearchTreeNode<T> root)
    {
        this.Root = root;
    }


    public BinarySearchTreeNode<T> Root;

    private void InternalInsert(BinarySearchTreeNode<T> currentNode, T value)
    {
        if(value.CompareTo(currentNode.Value) < 0)
        {
            if(currentNode.LeftChild == null)
            {
                currentNode.LeftChild = new BinarySearchTreeNode<T>(value);
            }
            else
            {
                this.InternalInsert(currentNode.LeftChild, value);
            }
        }
        else
        {
            if (currentNode.RightChild == null)
            {
                currentNode.RightChild = new BinarySearchTreeNode<T>(value);
            }
            else
            {
                this.InternalInsert(currentNode.RightChild, value);
            }
        }
    }

    private BinarySearchTree<T> InternalSearch(BinarySearchTreeNode<T> currentNode, T value)
    {
        if(value.CompareTo(currentNode.Value) < 0 && currentNode.LeftChild != null)
        {
            if(currentNode.LeftChild.Value.Equals(value))
            {
                return new BinarySearchTree<T>(currentNode.LeftChild);
            }
            else
            {
                return this.InternalSearch(currentNode.LeftChild, value);
            }
        }
        else if(value.CompareTo(currentNode.Value) >= 0 && currentNode.RightChild != null)
        {
            if (currentNode.RightChild.Value.Equals(value))
            {
                return new BinarySearchTree<T>(currentNode.RightChild);
            }
            else
            {
                return this.InternalSearch(currentNode.RightChild, value);
            }
        }

        return null;
    }

    private void InternalEachInOrder(BinarySearchTreeNode<T> currentNode, Action<T> action)
    {
        if (currentNode.LeftChild != null)
        {
            this.InternalEachInOrder(currentNode.LeftChild, action);
        }

        action.Invoke(currentNode.Value);

        if (currentNode.RightChild != null)
        {
            this.InternalEachInOrder(currentNode.RightChild, action);
        }
    }

    private BinarySearchTreeNode<T> InternalMin(BinarySearchTreeNode<T> currentNode)
    {
        if(currentNode.LeftChild != null)
        {
            return this.InternalMin(currentNode.LeftChild);
        }

        return currentNode;
    }

    private BinarySearchTreeNode<T> InternalMax(BinarySearchTreeNode<T> currentNode)
    {
        if (currentNode.RightChild != null)
        {
            return this.InternalMax(currentNode.RightChild);
        }

        return currentNode;
    }

    private void InternalRemove(BinarySearchTreeNode<T> currentNode, T value)
    {
    }

    public void Insert(T value)
    {
        if (this.Root == null)
        {
            this.Root = new BinarySearchTreeNode<T>(value);
        }
        else
        {
            this.InternalInsert(this.Root, value);
        }
    }

    public T Min()
    {
        if(this.Root == null)
        {
            return default(T);
        }

        return this.InternalMin(this.Root).Value;
    }

    public T Max(T value)
    {
        if (this.Root == null)
        {
            return default(T);
        }

        return this.InternalMax(this.Root).Value;
    }

    public void Remove(T value)
    {
        if(this.Root == null)
        {
            return;
        }
        
        // TODO: Implement me...
        this.InternalRemove(this.Root, value);
    }

    public bool Contains(T value)
    {
        if (this.Root == null)
        {
            return false;
        }
        else if (this.Root.Value.Equals(value))
        {
            return true;
        }
        else
        {
            return this.InternalSearch(this.Root, value) != null;
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.Root == null)
        {
            return;
        }

        this.InternalEachInOrder(this.Root, action);
    }

    public BinarySearchTree<T> Search(T value)
    {
        if(this.Root == null)
        {
            return null;
        }

        if(this.Root.Value.Equals(value))
        {
            return this;
        }

        return this.InternalSearch(this.Root, value);
    }

    public void Copy(BinarySearchTree<T> tree)
    {
        this.Root = new BinarySearchTreeNode<T>(tree.Root.Value, tree.Root.LeftChild, tree.Root.RightChild); 
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Insert(17);
        tree.Insert(9);
        tree.Insert(20);
        tree.Insert(6);
        tree.Insert(18);
        tree.Insert(25);
        tree.Insert(19);

        tree.Remove(17);

        //List<int> values = new List<int>();

        //tree.EachInOrder((value) => values.Add(value));

        //Console.WriteLine(string.Join(" ", values));
    }
}