﻿using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Account.Common.Util;

public static class PredicateBuilder
{
    public static Expression<Func<T, bool>> True<T>() => f => true;

    public static Expression<Func<T, bool>> False<T>() => f => false;

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = CreateParameterFrom(expr1, expr2);
        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(Rewrite(expr1.Body, parameter), Rewrite(expr2.Body, parameter)), parameter);
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var parameter = CreateParameterFrom(expr1, expr2);
        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Rewrite(expr1.Body, parameter), Rewrite(expr2.Body, parameter)), parameter);
    }

    private static ParameterExpression CreateParameterFrom(LambdaExpression left, LambdaExpression right)
    {
        var leftParameters = left.Parameters;
        var rightParameters = right.Parameters;

        if (leftParameters.Count != right.Parameters.Count)
            throw new ArgumentException();

        if (leftParameters.Count != 1)
            throw new ArgumentException();

        return Expression.Parameter(leftParameters[0].Type);
    }

    private static Expression Rewrite(Expression expression, ParameterExpression parameter)
    {
        return new ParameterRewriter(parameter).Transform(expression);
    }

    private class ParameterRewriter(ParameterExpression parameter) : ExpressionTransformer
    {
        public Expression VisitParameter(ParameterExpression expression)
        {
            return parameter;
        }
    }
}

abstract class ExpressionTransformer
{
    public Expression Transform(Expression expression)
    {
        return Visit(expression);
    }

    private Expression Visit(Expression exp)
    {
        if (exp == null) return exp;

        switch (exp.NodeType)
        {
            case ExpressionType.Negate:
            case ExpressionType.NegateChecked:
            case ExpressionType.Not:
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
            case ExpressionType.ArrayLength:
            case ExpressionType.Quote:
            case ExpressionType.TypeAs:
            case ExpressionType.UnaryPlus:
                return VisitUnary((UnaryExpression)exp);
            case ExpressionType.Add:
            case ExpressionType.AddChecked:
            case ExpressionType.Subtract:
            case ExpressionType.SubtractChecked:
            case ExpressionType.Multiply:
            case ExpressionType.MultiplyChecked:
            case ExpressionType.Divide:
            case ExpressionType.Power:
            case ExpressionType.Modulo:
            case ExpressionType.And:
            case ExpressionType.AndAlso:
            case ExpressionType.Or:
            case ExpressionType.OrElse:
            case ExpressionType.LessThan:
            case ExpressionType.LessThanOrEqual:
            case ExpressionType.GreaterThan:
            case ExpressionType.GreaterThanOrEqual:
            case ExpressionType.Equal:
            case ExpressionType.NotEqual:
            case ExpressionType.Coalesce:
            case ExpressionType.ArrayIndex:
            case ExpressionType.RightShift:
            case ExpressionType.LeftShift:
            case ExpressionType.ExclusiveOr:
                return VisitBinary((BinaryExpression)exp);
            case ExpressionType.TypeIs:
                return VisitTypeIs((TypeBinaryExpression)exp);
            case ExpressionType.Conditional:
                return VisitConditional((ConditionalExpression)exp);
            case ExpressionType.Constant:
                return VisitConstant((ConstantExpression)exp);
            case ExpressionType.Parameter:
                return VisitParameter((ParameterExpression)exp);
            case ExpressionType.MemberAccess:
                return VisitMemberAccess((MemberExpression)exp);
            case ExpressionType.Call:
                return VisitMethodCall((MethodCallExpression)exp);
            case ExpressionType.Lambda:
                return VisitLambda((LambdaExpression)exp);
            case ExpressionType.New:
                return VisitNew((NewExpression)exp);
            case ExpressionType.NewArrayInit:
            case ExpressionType.NewArrayBounds:
                return VisitNewArray((NewArrayExpression)exp);
            case ExpressionType.Invoke:
                return VisitInvocation((InvocationExpression)exp);
            case ExpressionType.MemberInit:
                return VisitMemberInit((MemberInitExpression)exp);
            case ExpressionType.ListInit:
                return VisitListInit((ListInitExpression)exp);
            default:
                throw new Exception(string.Format("Unhandled expression type: '{0}'", exp.NodeType));
        }
    }

    private MemberBinding VisitBinding(MemberBinding binding)
    {
        switch (binding.BindingType)
        {
            case MemberBindingType.Assignment:
                return VisitMemberAssignment((MemberAssignment)binding);
            case MemberBindingType.MemberBinding:
                return VisitMemberMemberBinding((MemberMemberBinding)binding);
            case MemberBindingType.ListBinding:
                return VisitMemberListBinding((MemberListBinding)binding);
            default:
                throw new Exception(string.Format("Unhandled binding type '{0}'", binding.BindingType));
        }
    }

    private ElementInit VisitElementInitializer(ElementInit initializer)
    {
        ReadOnlyCollection<Expression> arguments = VisitExpressionList(initializer.Arguments);
        if (arguments != initializer.Arguments) return Expression.ElementInit(initializer.AddMethod, arguments);
        return initializer;
    }

    private Expression VisitUnary(UnaryExpression u)
    {
        Expression operand = Visit(u.Operand);
        if (operand != u.Operand) return Expression.MakeUnary(u.NodeType, operand, u.Type, u.Method);
        return u;
    }

    private Expression VisitBinary(BinaryExpression b)
    {
        Expression left = Visit(b.Left);
        Expression right = Visit(b.Right);
        Expression conversion = Visit(b.Conversion);
        if (left != b.Left || right != b.Right || conversion != b.Conversion)
        {
            if (b.NodeType == ExpressionType.Coalesce && b.Conversion != null)
            {
                return Expression.Coalesce(left, right, conversion as LambdaExpression);
            }
            else
            {
                return Expression.MakeBinary(b.NodeType, left, right, b.IsLiftedToNull, b.Method);
            }
        }

        return b;
    }

    private Expression VisitTypeIs(TypeBinaryExpression b)
    {
        Expression expr = Visit(b.Expression);
        if (expr != b.Expression)
        {
            return Expression.TypeIs(expr, b.TypeOperand);
        }

        return b;
    }

    private Expression VisitConstant(ConstantExpression c)
    {
        return c;
    }

    private Expression VisitConditional(ConditionalExpression c)
    {
        Expression test = Visit(c.Test);
        Expression ifTrue = Visit(c.IfTrue);
        Expression ifFalse = Visit(c.IfFalse);
        if (test != c.Test || ifTrue != c.IfTrue || ifFalse != c.IfFalse)
        {
            return Expression.Condition(test, ifTrue, ifFalse);
        }

        return c;
    }

    private Expression VisitParameter(ParameterExpression p)
    {
        return p;
    }

    private Expression VisitMemberAccess(MemberExpression m)
    {
        Expression exp = Visit(m.Expression);
        if (exp != m.Expression)
        {
            return Expression.MakeMemberAccess(exp, m.Member);
        }

        return m;
    }

    private Expression VisitMethodCall(MethodCallExpression m)
    {
        Expression obj = Visit(m.Object);
        IEnumerable<Expression> args = VisitExpressionList(m.Arguments);
        if (obj != m.Object || args != m.Arguments)
        {
            return Expression.Call(obj, m.Method, args);
        }

        return m;
    }

    private ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
    {
        var list = VisitList(original, Visit);

        return new ReadOnlyCollection<Expression>(list);
    }

    private MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
    {
        Expression e = Visit(assignment.Expression);
        if (e != assignment.Expression) return Expression.Bind(assignment.Member, e);
        return assignment;
    }

    private MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
    {
        IEnumerable<MemberBinding> bindings = VisitBindingList(binding.Bindings);
        if (bindings != binding.Bindings) return Expression.MemberBind(binding.Member, bindings);
        return binding;
    }

    private MemberListBinding VisitMemberListBinding(MemberListBinding binding)
    {
        IEnumerable<ElementInit> initializers = VisitElementInitializerList(binding.Initializers);
        if (initializers != binding.Initializers) return Expression.ListBind(binding.Member, initializers);
        return binding;
    }

    private IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
    {
        return VisitList(original, VisitBinding);
    }

    private IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
    {
        return VisitList(original, VisitElementInitializer);
    }

    private IList<TElement> VisitList<TElement>(ReadOnlyCollection<TElement> original, Func<TElement, TElement> visit)
    {
        List<TElement> list = null;
        for (int i = 0, n = original.Count; i < n; i++)
        {
            TElement element = visit(original[i]);
            if (list != null)
            {
                list.Add(element);
            }
            else if (!EqualityComparer<TElement>.Default.Equals(element, original[i]))
            {
                list = new List<TElement>(n);
                for (int j = 0; j < i; j++)
                {
                    list.Add(original[j]);
                }

                list.Add(element);
            }
        }

        if (list != null)
            return list;

        return original;
    }

    private Expression VisitLambda(LambdaExpression lambda)
    {
        Expression body = Visit(lambda.Body);
        if (body != lambda.Body) return Expression.Lambda(lambda.Type, body, lambda.Parameters);
        return lambda;
    }

    private NewExpression VisitNew(NewExpression nex)
    {
        IEnumerable<Expression> args = VisitExpressionList(nex.Arguments);
        if (args != nex.Arguments)
        {
            if (nex.Members != null)
                return Expression.New(nex.Constructor, args, nex.Members);
            else
                return Expression.New(nex.Constructor, args);
        }

        return nex;
    }

    private Expression VisitMemberInit(MemberInitExpression init)
    {
        NewExpression n = VisitNew(init.NewExpression);
        IEnumerable<MemberBinding> bindings = VisitBindingList(init.Bindings);
        if (n != init.NewExpression || bindings != init.Bindings) return Expression.MemberInit(n, bindings);
        return init;
    }

    private Expression VisitListInit(ListInitExpression init)
    {
        NewExpression n = VisitNew(init.NewExpression);
        IEnumerable<ElementInit> initializers = VisitElementInitializerList(init.Initializers);
        if (n != init.NewExpression || initializers != init.Initializers) return Expression.ListInit(n, initializers);
        return init;
    }

    private Expression VisitNewArray(NewArrayExpression na)
    {
        IEnumerable<Expression> exprs = VisitExpressionList(na.Expressions);
        if (exprs != na.Expressions)
        {
            if (na.NodeType == ExpressionType.NewArrayInit)
            {
                return Expression.NewArrayInit(na.Type.GetElementType(), exprs);
            }
            else
            {
                return Expression.NewArrayBounds(na.Type.GetElementType(), exprs);
            }
        }

        return na;
    }

    private Expression VisitInvocation(InvocationExpression iv)
    {
        IEnumerable<Expression> args = VisitExpressionList(iv.Arguments);
        Expression expr = Visit(iv.Expression);
        if (args != iv.Arguments || expr != iv.Expression) return Expression.Invoke(expr, args);
        return iv;
    }
}