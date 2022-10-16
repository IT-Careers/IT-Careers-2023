namespace _00.Demo.RedBlackTree
{
    public class RedBlackTreeNode<T> where T : IComparable<T>
    {
        public RedBlackTreeNode(T value)
        {
            this.Value = value;
            this.Color = RedBlackTreeNodeColor.Red;
        }

        public T Value { get; set; }

        public int Count { get; set; }

        public RedBlackTreeNode<T> LeftChild { get; set; }

        public RedBlackTreeNode<T> RightChild { get; set; }

        public RedBlackTreeNodeColor Color { get; set; }
    }
}
