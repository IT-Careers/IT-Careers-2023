using System.Security;

namespace _00.Demo.BTrees
{
    public class BTree<T> where T : IComparable<T>
    {
        public BTreeNode<T> Root { get; set; }

        private BTreeNode<T> InternalInsert(BTreeNode<T> currentNode, T value)
        {
            if (currentNode.IsLeafNode())
            {
                if (!currentNode.HasRightKey)
                {
                    if (currentNode.LeftKey.CompareTo(value) < 0)
                    {
                        currentNode.RightKey = value;
                    }
                    else
                    {
                        currentNode.RightKey = currentNode.LeftKey;
                        currentNode.LeftKey = value;
                    }
                }
                else
                {
                    T leftKey = currentNode.LeftKey;
                    T middleKey = value;
                    T rightKey = currentNode.RightKey;

                    if (middleKey.CompareTo(leftKey) < 0)
                    {
                        return new BTreeNode<T>(leftKey, new BTreeNode<T>(middleKey), new BTreeNode<T>(rightKey));
                    }
                    else if (middleKey.CompareTo(leftKey) >= 0 && middleKey.CompareTo(rightKey) < 0)
                    {
                        return new BTreeNode<T>(middleKey, new BTreeNode<T>(leftKey), new BTreeNode<T>(rightKey));
                    }
                    else if (middleKey.CompareTo(rightKey) >= 0)
                    {
                        return new BTreeNode<T>(rightKey, new BTreeNode<T>(leftKey), new BTreeNode<T>(middleKey));
                    }
                }
            }
            else
            {
                BTreeNode<T> newNode = null;

                if (currentNode.IsTwoNode()
                    && value.CompareTo(currentNode.LeftKey) < 0)
                {
                    newNode = this.InternalInsert(currentNode.LeftChild, value);
                }
                else if (currentNode.IsTwoNode()
                    && value.CompareTo(currentNode.LeftKey) >= 0)
                {
                    newNode = this.InternalInsert(currentNode.RightChild, value);
                }
                else if (currentNode.IsThreeNode()
                    && value.CompareTo(currentNode.LeftKey) < 0)
                {
                    newNode = this.InternalInsert(currentNode.LeftChild, value);
                }
                else if (currentNode.IsThreeNode()
                    && value.CompareTo(currentNode.LeftKey) > 0
                    && value.CompareTo(currentNode.RightKey) <= 0)
                {
                    newNode = this.InternalInsert(currentNode.MiddleChild, value);
                }
                else if (currentNode.IsThreeNode()
                    && value.CompareTo(currentNode.RightKey) > 0)
                {
                    newNode = this.InternalInsert(currentNode.RightChild, value);
                }

                if (newNode != null) {
                    if (currentNode.IsTwoNode())
                    {
                        if (newNode.LeftKey.CompareTo(currentNode.LeftKey) < 0)
                        {
                            currentNode.RightKey = currentNode.LeftKey;
                            currentNode.LeftKey = newNode.LeftKey;
                            currentNode.MiddleChild = newNode.RightChild;
                            currentNode.LeftChild = newNode.LeftChild;
                        }
                        else if(newNode.LeftKey.CompareTo(currentNode.LeftKey) >= 0)
                        {
                            currentNode.RightKey = newNode.LeftKey;
                            currentNode.MiddleChild = newNode.LeftChild;
                            currentNode.RightChild = newNode.RightChild;
                        }
                    }
                    else if (currentNode.IsThreeNode())
                    {
                        if(newNode.LeftKey.CompareTo(currentNode.LeftKey) < 0)
                        {
                            BTreeNode<T> leftChild = newNode;
                            BTreeNode<T> rightChild = new BTreeNode<T>(currentNode.RightKey, currentNode.MiddleChild, currentNode.RightChild);
                            return new BTreeNode<T>(currentNode.LeftKey, leftChild, rightChild);
                        }
                        else if (newNode.LeftKey.CompareTo(currentNode.LeftKey) >= 0 
                            && newNode.LeftKey.CompareTo(currentNode.RightKey) < 0)
                        {
                            BTreeNode<T> leftChild = new BTreeNode<T>(currentNode.LeftKey, currentNode.LeftChild, newNode.LeftChild);
                            BTreeNode<T> rightChild = new BTreeNode<T>(currentNode.RightKey, newNode.RightChild, currentNode.RightChild);
                            return new BTreeNode<T>(newNode.LeftKey, leftChild, rightChild);
                        }
                        else if(newNode.LeftKey.CompareTo(currentNode.RightKey) >= 0)
                        {
                            BTreeNode<T> leftChild = new BTreeNode<T>(currentNode.LeftKey, currentNode.LeftChild, currentNode.MiddleChild);
                            BTreeNode<T> rightChild = newNode;
                            return new BTreeNode<T>(currentNode.RightKey, leftChild, rightChild);
                        }
                    }
                }
            }
            
            return null;
        }

        private BTreeNode<T> InternalDelete(BTreeNode<T> currentNode, T value, BTreeNode<T> parentNode)
        {
            // TODO: Implement me...
            return null;
        }

        public void Insert(T value)
        {
            if (this.Root == null)
            {
                this.Root = new BTreeNode<T>(value);
            }
            else
            {
                BTreeNode<T> node = this.InternalInsert(this.Root, value);
                
                if(node != null)
                {
                    this.Root = node;
                }
            }
        }
        
        public void Delete(T value)
        {
            //BTreeNode<T> node = this.InternalDelete(this.Root, value);

            //if (node != null)
            //{
            //    this.Root = node;
            //}
        }
    }
}
