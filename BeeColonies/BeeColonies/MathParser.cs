using System;
using System.Collections.Generic;
using System.Text;

namespace BeeColonies
 {
        public enum OperatorType
        {
            PREFIX,
            OPEN_BRACKET,
            CLOSE_BRACKET,
            BINARY,
            CONST,
            DIGIT,
            ERROR,
            NULL,
            PARAM,
        }

        internal class Token
        {
            public string singleToken;
            public int priority;
            public OperatorType type;
            public Token(string in_singleToken, int in_priority, OperatorType in_type)
            {
                this.singleToken = in_singleToken;
                this.priority = in_priority;
                this.type = in_type;
            }

            public Token(Token token)
            {
                this.singleToken = token.singleToken;
                this.priority = token.priority;
                this.type = token.type;
            }
        }


        internal class MathParser
        {
            private static List<Token> tokens = new List<Token>{
                             new Token("(", -1, OperatorType.OPEN_BRACKET),
                             new Token(")", -1, OperatorType.CLOSE_BRACKET),
                             new Token("+", 1, OperatorType.BINARY),
                             new Token("-", 1, OperatorType.BINARY),
                             new Token("*", 2, OperatorType.BINARY),
                             new Token("/", 2, OperatorType.BINARY),
                             new Token("^", 3, OperatorType.BINARY),
                             new Token("sin", 0, OperatorType.PREFIX),
                             new Token("cos", 0, OperatorType.PREFIX),
                             new Token("tg", 0, OperatorType.PREFIX),
                             new Token("ctg", 0, OperatorType.PREFIX),
                             new Token("ln", 0, OperatorType.PREFIX),
                             new Token("pi", -1, OperatorType.CONST),
                             new Token("x", -1, OperatorType.PARAM),
                             new Token("y", -1, OperatorType.PARAM),
                             new Token("e", -1, OperatorType.CONST) };


            public static double calculate(double x, double y, string infixPhrase)
            {
                List<Token> polishList = toPolishPhrase(infixPhrase);
                Stack<double> localStack = new Stack<double>();

                foreach (Token i in polishList)
                {
                    switch (i.type)
                    {

                        case OperatorType.DIGIT:
                            localStack.Push(Double.Parse(i.singleToken));
                            break;

                        case OperatorType.BINARY:
                            switch (i.singleToken)
                            {
                                case "+": localStack.Push(localStack.Pop() + localStack.Pop()); break;
                                case "-": localStack.Push(-localStack.Pop() + localStack.Pop()); break;
                                case "*": localStack.Push(localStack.Pop() * localStack.Pop()); break;
                                case "/": localStack.Push(reverseDiv(localStack.Pop(), localStack.Pop())); break;
                                case "^": localStack.Push(reversePow(localStack.Pop(), localStack.Pop())); break;
                            }
                            break;

                        case OperatorType.PREFIX:
                            switch (i.singleToken)
                            {
                                case "sin": localStack.Push(Math.Sin(localStack.Pop())); break;
                                case "cos": localStack.Push(Math.Cos(localStack.Pop())); break;
                                case "tg": localStack.Push(Math.Tan(localStack.Pop())); break;
                                case "ctg": localStack.Push(ctg(localStack.Pop())); break;
                                case "ln": localStack.Push(Math.Log(localStack.Pop())); break;

                                case "-sin": localStack.Push(-Math.Sin(localStack.Pop())); break;
                                case "-cos": localStack.Push(-Math.Cos(localStack.Pop())); break;
                                case "-tg": localStack.Push(-Math.Tan(localStack.Pop())); break;
                                case "-ctg": localStack.Push(-ctg(localStack.Pop())); break;
                                case "-ln": localStack.Push(-Math.Log(localStack.Pop())); break;
                            }
                            break;

                        case OperatorType.CONST:
                            switch (i.singleToken)
                            {
                                case "pi": localStack.Push(3.1415926); break;
                                case "e": localStack.Push(2.7182818); break;

                                case "-pi": localStack.Push(-3.1415926); break;
                                case "-e": localStack.Push(-2.7182818); break;
                            }
                            break;

                        case OperatorType.PARAM:
                            switch (i.singleToken)
                            {
                                case "x": localStack.Push(x); break;
                                case "y": localStack.Push(y); break;

                                case "-x": localStack.Push(-x); break;
                                case "-y": localStack.Push(-y); break;
                            }
                            break;

                        default: throw new Exception("Something gone wrong");
                    }
                }
                return localStack.Pop();
            }


            private static List<Token> toPolishPhrase(string infixPhrase)
            {
                string localInfixPhrase = infixPhrase.Replace(" ", "");
                Token prevToken;
                Token token = new Token("", -2, OperatorType.NULL);
                List<Token> polishList = new List<Token>();
                Stack<Token> localStack = new Stack<Token>();

                while (localInfixPhrase != "")
                {
                    prevToken = token;
                    token = parseToken(localInfixPhrase, prevToken);
                    if (token.singleToken == "")
                        throw new Exception("program Error");

                    localInfixPhrase = localInfixPhrase.Substring(token.singleToken.Length);



                    switch (token.type)
                    {
                        case OperatorType.CONST:
                            switch (token.singleToken)
                            {
                                case "pi":
                                    polishList.Add(new Token(Math.PI.ToString(), -1, OperatorType.DIGIT));
                                    break;
                                case "e":
                                    polishList.Add(new Token(Math.E.ToString(), -1, OperatorType.DIGIT));
                                    break;
                            }
                            break;
                        case OperatorType.PARAM: polishList.Add(token); break;
                        case OperatorType.DIGIT: polishList.Add(token); break;
                        case OperatorType.PREFIX: localStack.Push(token); break;
                        case OperatorType.OPEN_BRACKET: localStack.Push(token); break;
                        case OperatorType.CLOSE_BRACKET:
                            if (localStack.Count == 0)
                                throw new Exception("Incorrect phrase");

                            Token tempToken = localStack.Pop();

                            while (tempToken.type != OperatorType.OPEN_BRACKET)
                            {
                                polishList.Add(tempToken);
                                if (localStack.Count == 0)
                                    throw new Exception("Incorrect phrase");

                                tempToken = localStack.Pop();
                            }
                            break;

                        case OperatorType.BINARY:
                            while (localStack.Count > 0 && (localStack.Peek().type == OperatorType.PREFIX ||
                                            localStack.Peek().priority >= token.priority))
                                polishList.Add(localStack.Pop());

                            localStack.Push(token);
                            break;
                        default: throw new Exception("Something gone wrong"); break;
                    }
                }
                while (localStack.Count > 0)
                {
                    if (localStack.Peek().type == OperatorType.OPEN_BRACKET ||
                        localStack.Peek().type == OperatorType.CLOSE_BRACKET)
                        throw new Exception("Incorrect phrase (brackets)");
                    polishList.Add(localStack.Pop());
                }
                return polishList;
            }

            private static Token parseToken(string infixPhrase, Token prevToken)
            {
                if (infixPhrase == "")
                    throw new Exception("parseToken error");
                string outToken = "";
                int iCounter = 0;

                if (Char.IsDigit(infixPhrase[0]))
                {
                    while (iCounter < infixPhrase.Length && Char.IsDigit(infixPhrase[iCounter]))
                    {
                        outToken += infixPhrase[iCounter];
                        ++iCounter;
                    }
                    return new Token(outToken, -1, OperatorType.DIGIT);
                }

                foreach (Token token in tokens)
                {
                    //Сразу отсеиваем токены, которые длиннее мат. выражения
                    if (infixPhrase.Length < token.singleToken.Length)
                        continue;

                    if (infixPhrase.Substring(0, token.singleToken.Length) == token.singleToken)
                    {
                        //  check for unary + and -
                        if (((token.singleToken == "+") || (token.singleToken == "-")) &&
                            ((prevToken.type == OperatorType.NULL) ||
                                    (prevToken.type == OperatorType.BINARY) ||
                                    (prevToken.type == OperatorType.OPEN_BRACKET)))
                        {
                            outToken += token.singleToken;
                            Token nextToken = parseToken(infixPhrase.Substring(token.singleToken.Length), token);
                            outToken += nextToken.singleToken;

                            return new Token(outToken, -1, nextToken.type);
                        }
                        else
                            return new Token(token);
                    }
                }
                // not parsed
                return new Token("", -2, OperatorType.ERROR);
            }

            private static double reversePow(double a, double b)
            {
                return Math.Pow(b, a);
            }

            private static double reverseDiv(double a, double b)
            {
                return b / a;
            }

            private static double ctg(double a)
            {
                return Math.Cos(a) / Math.Sin(a);
            }
        }
    }
