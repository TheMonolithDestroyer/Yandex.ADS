using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandex.Practicum.Sprints.Sprint2
{
    public class TaskH : BaseClass
    {
        #region Tests
        // {[()]}
        // ()
        // []
        // {}
        // ()[]{}
        // ((()))
        // {{{}}}
        // [[[]]]
        // ()()
        // {}{}
        // [][]
        // {{(([[]]))}}
        // (
        // ]
        // {
        // ((()
        // {}}}
        // [[[][][]]]][[
        #endregion
        public static void Execute()
        {
            InitReaderAndWriter();

            var brackets = Common.ReadString(_reader);

            var result = IsCorrectBracketSeq(brackets);

            _writer.WriteLine(result);

            CloseReaderAndWriter();
        }

        private static bool IsCorrectBracketSeq(string brackets)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char bracket in brackets)
            {
                if (bracket == '(' || bracket == '[' || bracket == '{')
                {
                    stack.Push(bracket);
                    continue;
                }

                if (bracket == ')')
                {
                    if (stack.Count > 0)
                    {
                        char value = stack.Pop();
                        if (value != '(')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (bracket == ']')
                {
                    if (stack.Count > 0)
                    {
                        char value = stack.Pop();
                        if (value != '[')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (bracket == '}')
                {
                    if (stack.Count > 0)
                    {
                        char value = stack.Pop();
                        if (value != '{')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
