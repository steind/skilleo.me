using System;
using System.Collections.Generic;
using System.Text;

namespace skilleo.challenges
{
    public class MultiOperationCalculator : Challenge
    {
        public override string ProcessInput(string input)
        {
            var stack = new Stack<string>();
            var queue = new Queue<string>();

            var inputs = input.Split(' ');
            int? operand1 = null;
            int? operand2 = null;
            var op = string.Empty;

            // reorder the input string so / and * operations are first
            var reorderedInput = string.Empty;

            foreach (var s in inputs)
            {



                int operand;

                if (s == "/" || s == "*")
                {
                    // process operator
                    op = s;
                    continue;
                }

                if (Int32.TryParse(s, out operand))
                {
                    if (operand1 == null)
                    {
                        operand1 = operand;
                        operand2 = null;
                        continue;
                    }

                    operand2 = operand;
                }

                throw new Exception(string.Format("Unexpected input '{0}'. Solve expects integers or symbols (+, -, /, or *).", s));
            }

            // solve

            return input;
        }

        private string SimplifyLeftToRight(string input)
        {
            var terms = input.Split(' ');
            if (terms.Length == 1)
            {
                return input;
            }

            var result = new StringBuilder();
            int? operand1 = null;
            var operation = string.Empty;
            int? operand2 = null;

            foreach (var term in terms)
            {
                if (term == "+" || term == "-" || term == "/" || term == "*")
                {
                    if (operand1 != null && operand2 != null)
                    {
                        result.Append(string.Format("{0} ", term));
                        operand1 = null;
                        operand2 = null;
                        operation = String.Empty;
                    }
                    else
                    {
                        operation = term;
                    }

                    continue;
                }

                int number;
                if (!Int32.TryParse(term, out number))
                {
                    throw new Exception(string.Format("Unexpected operand '{0}'. Integer expected."));
                }

                if (operand1 == null)
                {
                    operand1 = number;
                }
                else
                {
                    operand2 = number;
                    switch (operation)
                    {
                        case "+":
                            result.Append(string.Format("{0} ", operand1 + operand2));
                            break;
                        case "-":
                            result.Append(string.Format("{0} ", operand1 - operand2));
                            break;
                        case "/":
                            result.Append(string.Format("{0} ", operand1 / operand2));
                            break;
                        case "*":
                            result.Append(string.Format("{0} ", operand1 * operand2));
                            break;
                    }
                }
            }

            if (operand1 != null && operand2 == null)
            {
                result.Append(string.Format("{0}", operand1));
            }


            return result.ToString();
        }
    }
}
