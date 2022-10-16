using _00.Demo.ExpressionTreeExample.Expressions;

public class Program
{
    public static void Main(string[] args)
    {
        IntegerExpression integerExpression = new IntegerExpression(5);
        IntegerExpression integerExpression2 = new IntegerExpression(15);
        IntegerExpression integerExpression3 = new IntegerExpression(20);
        IntegerExpression integerExpression4 = new IntegerExpression(60);

        AddExpression addExpression = new AddExpression(integerExpression, integerExpression3);
        AddExpression addExpression2 = new AddExpression(integerExpression2, integerExpression4);
        AddExpression addExpression3 = new AddExpression(addExpression, addExpression2);

        int d = 5;

        int a = 5 + 15;
        int b = 20 + 60;
        int c = a + b;

        Console.WriteLine(addExpression3.ToString() + " = " + addExpression3.Evaluate());
    }
}