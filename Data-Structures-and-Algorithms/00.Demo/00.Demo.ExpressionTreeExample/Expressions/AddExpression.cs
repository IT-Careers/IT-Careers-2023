namespace _00.Demo.ExpressionTreeExample.Expressions
{
    public class AddExpression : IComplexExpression<int>
    {
        public AddExpression(IBasicExpression<int> leftChild, IBasicExpression<int> rightChild)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public IBasicExpression<int> LeftChild { get; set; }
        
        public IBasicExpression<int> RightChild { get; set; }

        public int Evaluate()
        {
            return this.LeftChild.Evaluate() + this.RightChild.Evaluate();
        }

        public override string ToString()
        {
            return this.LeftChild.ToString() + " + " + this.RightChild.ToString();
        }
    }
}
