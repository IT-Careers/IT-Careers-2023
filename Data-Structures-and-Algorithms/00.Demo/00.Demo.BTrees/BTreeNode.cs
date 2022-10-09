namespace _00.Demo.BTrees
{
    public class BTreeNode<T> where T : IComparable<T>
    {
        private T rightKey;

        public BTreeNode(T value)
        {
            this.LeftKey = value;
        }

        public BTreeNode(T value, BTreeNode<T> leftChild, BTreeNode<T> rightChild) : this(value)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T LeftKey { get; set; }

        public T RightKey
        {
            get
            {
                return this.rightKey;
            }
            set
            {
                this.rightKey = value;
                this.HasRightKey = true;
            }
        }

        public BTreeNode<T> LeftChild { get; set; } = null;

        public BTreeNode<T> MiddleChild { get; set; } = null;

        public BTreeNode<T> RightChild { get; set; } = null;

        public bool IsLeafNode() => this.LeftChild == null && this.MiddleChild == null && this.RightChild == null;

        public bool IsTwoNode() => !this.HasRightKey;

        public bool IsThreeNode() => this.HasRightKey;

        public bool HasRightKey { get; set; } = false;
    }
}
