using System;
using System.Collections.Generic;

namespace Exercise7_FinancialForecasting
{
    class FinancialForecaster
    {
        public static double FutureValueRecursive(double principal, double rate, int years)
        {
            if (years == 0) return principal;
            return FutureValueRecursive(principal, rate, years - 1) * (1 + rate);
        }

        static Dictionary<int, double> memo = new Dictionary<int, double>();

        public static double FutureValueMemoised(double principal, double rate, int years)
        {
            if (years == 0) return principal;

            if (memo.ContainsKey(years))
            {
                return memo[years];
            }

            double result = FutureValueMemoised(principal, rate, years - 1) * (1 + rate);
            memo[years] = result;
            return result;
        }

        public static double FutureValueIterative(double principal, double rate, int years)
        {
            double value = principal;
            for (int i = 0; i < years; i++)
            {
                value = value * (1 + rate);
            }
            return value;
        }

        static void Main(string[] args)
        {
            double principal = 10000.00;
            double rate = 0.08;
            int years = 10;

            Console.WriteLine("Principal: $" + principal.ToString("F2"));
            Console.WriteLine("Annual growth rate: " + (rate * 100).ToString("F0") + "%");
            Console.WriteLine("Years: " + years + "\n");

            double rv = FutureValueRecursive(principal, rate, years);
            Console.WriteLine("Recursive  result : $" + rv.ToString("F2"));

            memo.Clear();
            double mv = FutureValueMemoised(principal, rate, years);
            Console.WriteLine("Memoised   result : $" + mv.ToString("F2"));

            double iv = FutureValueIterative(principal, rate, years);
            Console.WriteLine("Iterative  result : $" + iv.ToString("F2") + "\n");

            Console.WriteLine("=== Complexity Comparison ===");
            Console.WriteLine("Plain recursion : O(n) time, O(n) stack");
            Console.WriteLine("Memoisation     : O(n) time, O(n) space");
            Console.WriteLine("Iterative       : O(n) time, O(1) space");

            Console.WriteLine("\nYear-by-year growth:");
            for (int y = 1; y <= years; y++)
            {
                Console.WriteLine("  Year " + y + " -> $" + FutureValueIterative(principal, rate, y).ToString("F2"));
            }
        }
    }
}
