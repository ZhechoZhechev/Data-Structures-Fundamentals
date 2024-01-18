namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if(parentheses.Length % 2 == 1) return false;

            Stack<char> parChars = new Stack<char>();

            bool ifSuccess = true;
            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '[' || parentheses[i] == '(' || parentheses[i] == '{')
                {
                    parChars.Push(parentheses[i]);
                    continue;
                }

                if (parChars.Count == 0)
                {
                    ifSuccess = false;
                    break;
                }

                if (parentheses[i]== ']' && parChars.Peek() == '['
                    || parentheses[i] == ')' && parChars.Peek() == '('
                    || parentheses[i] == '}' && parChars.Peek() == '{')
                {
                    parChars.Pop();
                }
                else
                {
                    ifSuccess = false;
                    break;
                }
            }

            if (ifSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
