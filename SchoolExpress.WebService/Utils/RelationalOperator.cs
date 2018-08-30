
using System;

namespace SchoolExpress.WebService.Utils
{
    public enum RelationalOperator
    {
        EqualTo,
        NotEqualTo,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        Contains,
        In,
        Like,
        StartsWith
    }

    public static class RelationalOperatorExtension
    {
        public static string[] Symbols {
            get
            {
                return new[]
                {
                    "==",
                    "!=",
                    ">",
                    "<",
                    ">=",
                    "<=",
                    "*=",
                    "contains",
                    "~=",
                    "like",
                    "^=",
                    "startswith"
                };
            }
        }

        public static RelationalOperator GetOperator(string symbol)
        {
            switch (symbol)
            {
                case "==":
                    return RelationalOperator.EqualTo;
                case "!=":
                    return RelationalOperator.NotEqualTo;
                case ">":
                    return RelationalOperator.GreaterThan;
                case "<":
                    return RelationalOperator.LessThan;
                case ">=":
                    return RelationalOperator.GreaterThanOrEqualTo;
                case "<=":
                    return RelationalOperator.LessThanOrEqualTo;
                case "*=":
                case "contains":
                    return RelationalOperator.Contains;
                case "~=":
                case "like":
                    return RelationalOperator.Like;
                case "^=":
                case "startswith":
                    return RelationalOperator.StartsWith;
                default:
                    throw new Exception("Operator Not Found.");
            }
        }
    }
}


