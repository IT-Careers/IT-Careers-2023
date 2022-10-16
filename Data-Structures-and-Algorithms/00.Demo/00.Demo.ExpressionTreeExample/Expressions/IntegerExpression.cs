namespace _00.Demo.ExpressionTreeExample.Expressions
{
    public class IntegerExpression : IBasicExpression<int>
    {
        public IntegerExpression(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public int Evaluate()
        {
            return this.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
