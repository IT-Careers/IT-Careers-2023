namespace _00.Demo.ExpressionTreeExample.Expressions
{
    public interface IComplexExpression<T> : IBasicExpression<T>
    {
        IBasicExpression<T> LeftChild { get; set; }

        IBasicExpression<T> RightChild { get; set; }
    }
}
