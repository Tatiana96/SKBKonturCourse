using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebra
{
    public static class ComputingAlgebra
    {
        private static Expression DifferentiatePartOfExpression(Expression expression)
        {

            if (expression is BinaryExpression)
            {
                if (expression.NodeType == ExpressionType.Add)
                    return Expression.Add(

                        DifferentiatePartOfExpression( ( (BinaryExpression)expression).Left ),
                        DifferentiatePartOfExpression( ( (BinaryExpression)expression).Right )

                        );

                else if (expression.NodeType == ExpressionType.Multiply)
                    return Expression.Add(

                        Expression.Multiply(
                            ((BinaryExpression)expression).Left,
                            DifferentiatePartOfExpression( ( (BinaryExpression)expression).Right) ),

                        Expression.Multiply(
                            ((BinaryExpression)expression).Right,
                            DifferentiatePartOfExpression( ( (BinaryExpression)expression).Left) )

                            );
            }

            else if ( (expression is MethodCallExpression ) && 
                ( ( (MethodCallExpression)expression).Method.Name == "Sin") )
            {
                var argument = ( (MethodCallExpression)expression).Arguments[0];

                return Expression.Multiply(

                     Expression.Call(typeof(Math).GetMethod("Cos"), argument),
                     DifferentiatePartOfExpression(argument)

                     );
            }

            else if (expression is ConstantExpression)
                return Expression.Constant(0.0);

            else if (expression is ParameterExpression)
                return Expression.Constant(1.0);

            throw new ArgumentException("Invalid expression. Please, try input again.");

        }

        public static Func<double, double> DifferentiateExpression(this Expression<Func<double, double>> expression)
        {

            return (Func<double, double>)Expression.Lambda(
                DifferentiatePartOfExpression(expression.Body),
                expression.Parameters
                ).Compile();

        }

    }
}
