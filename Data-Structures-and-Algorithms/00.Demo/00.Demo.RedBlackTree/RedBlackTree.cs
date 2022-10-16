namespace _00.Demo.RedBlackTree
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public static int stepsTaken = 0;

        public RedBlackTreeNode<T> Root { get; set; }

        private bool IsRed(RedBlackTreeNode<T> currentNode)
        {
            return currentNode != null && currentNode.Color == RedBlackTreeNodeColor.Red;
        }

        private int Count(RedBlackTreeNode<T> currentNode)
        {
            if (currentNode == null) return 0;

            return 1 + Count(currentNode.LeftChild) + Count(currentNode.RightChild);
        }

        private void FlipColors(RedBlackTreeNode<T> currentNode)
        {
            currentNode.Color = RedBlackTreeNodeColor.Red;
            
            if(currentNode.LeftChild != null)
            {
                currentNode.LeftChild.Color = RedBlackTreeNodeColor.Black;
            }

            if (currentNode.RightChild != null)
            {
                currentNode.RightChild.Color = RedBlackTreeNodeColor.Black;
            }
        }

        private RedBlackTreeNode<T> RotateLeft(RedBlackTreeNode<T> currentNode)
        {
            RedBlackTreeNode<T> temporaryNode = currentNode;

            currentNode = currentNode.RightChild;
            temporaryNode.RightChild = currentNode.LeftChild;
            currentNode.LeftChild = temporaryNode;

            currentNode.Color = temporaryNode.Color;
            temporaryNode.Color = RedBlackTreeNodeColor.Red;

            currentNode.Count = temporaryNode.Count;
            temporaryNode.Count = this.Count(currentNode);

            return currentNode;
        }

        private RedBlackTreeNode<T> RotateRight(RedBlackTreeNode<T> currentNode)
        {
            RedBlackTreeNode<T> temporaryNode = currentNode;
            currentNode = currentNode.LeftChild;
            temporaryNode.LeftChild = currentNode.RightChild;
            currentNode.RightChild = temporaryNode;

            currentNode.Color = temporaryNode.Color;
            temporaryNode.Color = RedBlackTreeNodeColor.Red;

            currentNode.Count = temporaryNode.Count;
            temporaryNode.Count = this.Count(currentNode);

            return currentNode;
        }

        private T InternalMax(RedBlackTreeNode<T> currentNode)
        {
            stepsTaken++;
            if(currentNode.RightChild == null)
            {
                return currentNode.Value;
            }

            return this.InternalMax(currentNode.RightChild);
        }

        public T Max()
        {
            return this.Root == null ? default(T) : this.InternalMax(this.Root);
        }

        private RedBlackTreeNode<T> InternalInsert(RedBlackTreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                currentNode = new RedBlackTreeNode<T>(value);
            }
            else
            {
                bool isInsertedRight = false;

                if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode.LeftChild = this.InternalInsert(currentNode.LeftChild, value);
                }
                else
                {
                    currentNode.RightChild = this.InternalInsert(currentNode.RightChild, value);
                    isInsertedRight = true;
                }

                if (this.IsRed(currentNode.LeftChild) && this.IsRed(currentNode.LeftChild.RightChild))
                {
                    currentNode.LeftChild = this.RotateLeft(currentNode.LeftChild);
                }
                if (this.IsRed(currentNode.RightChild) && this.IsRed(currentNode.RightChild.LeftChild))
                {
                    currentNode.RightChild = this.RotateRight(currentNode.RightChild);
                }
                if (this.IsRed(currentNode.LeftChild) && this.IsRed(currentNode.LeftChild.LeftChild))
                {
                    currentNode = this.RotateRight(currentNode);
                }
                if (this.IsRed(currentNode.RightChild) && this.IsRed(currentNode.RightChild.RightChild))
                {
                    currentNode = this.RotateLeft(currentNode);
                }
                if (this.IsRed(currentNode) && this.IsRed(currentNode.LeftChild))
                {
                    currentNode = this.RotateRight(currentNode);
                }
                if(this.IsRed(currentNode) && this.IsRed(currentNode.RightChild))
                {
                    currentNode = this.RotateLeft(currentNode);
                }
                if (this.IsRed(currentNode.LeftChild) && this.IsRed(currentNode.RightChild))
                {
                    this.FlipColors(currentNode);
                }
            }

            currentNode.Count = Count(currentNode);

            return currentNode;
        }

        public void Insert(T value)
        {
            this.Root = this.InternalInsert(this.Root, value);
            this.Root.Color = RedBlackTreeNodeColor.Black;
        }
    }
}
