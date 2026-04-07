namespace fix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Napiš pro POSTfix (1)/pro PREfix (2):");
                string choice = Console.ReadLine();

                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Neplatný vstup! Zadejte 1 pro POSTfix nebo 2 pro PREfix.");
                    continue;
                }

                Console.WriteLine("Teď můžeš napsat svůj výraz!");
                string[] expression = Console.ReadLine().Split(" ");

                bool possible = true;

                Stack<float> stack = new Stack<float>();

                // POSTFIX
                if (choice == "1")
                {
                    for (int i = 0; i < expression.Length; i++)
                    {
                        if (double.TryParse(expression[i], out double number))
                        {
                            stack.Push(float.Parse(expression[i]));
                        }
                        else
                        {
                            if (stack.Count < 2)
                            {
                                Console.WriteLine("Chybí operand!");
                                possible = false;
                                break;
                            }

                            float b = stack.Pop();
                            float a = stack.Pop();

                            if (b == 0 && expression[i] == "/")
                            {
                                Console.WriteLine("Dělení nulou není povoleno!");
                                possible = false;
                                break;
                            }

                            switch (expression[i])
                            {
                                case "+":
                                    stack.Push(a + b);
                                    break;
                                case "-":
                                    stack.Push(a - b);
                                    break;
                                case "*":
                                    stack.Push(a * b);
                                    break;
                                case "/":
                                    stack.Push(a / b);
                                    break;
                                default:
                                    Console.WriteLine("Toto nelze!");
                                    possible = false;
                                    break;
                            }
                        }
                    }

                    if (possible == true && stack.Count == 1)
                    {
                        Console.WriteLine("Výsledek: " + stack.Pop());
                    }
                    if (possible == true && stack.Count > 1)
                    {
                        Console.WriteLine("Chybí operátor!");
                    }
                }

                // PREFIX
                if (choice == "2")
                {
                    for (int i = expression.Length - 1; i >= 0; i--)
                    {
                        if (double.TryParse(expression[i], out double number))
                        {
                            stack.Push(float.Parse(expression[i]));
                        }
                        else
                        {
                            if (stack.Count < 2)
                            {
                                Console.WriteLine("Chybí operand!");
                                possible = false;
                                break;
                            }

                            float a = stack.Pop();
                            float b = stack.Pop();

                            if (b == 0 && expression[i] == "/")
                            {
                                Console.WriteLine("Dělení nulou není povoleno!");
                                possible = false;
                                break;
                            }

                            switch (expression[i])
                            {
                                case "+":
                                    stack.Push(a + b);
                                    break;
                                case "-":
                                    stack.Push(a - b);
                                    break;
                                case "*":
                                    stack.Push(a * b);
                                    break;
                                case "/":
                                    stack.Push(a / b);
                                    break;
                                default:
                                    Console.WriteLine("Toto nelze!");
                                    possible = false;
                                    break;
                            }
                        }
                    }

                    if (possible == true && stack.Count == 1)
                    {
                        Console.WriteLine("Výsledek: " + stack.Pop());
                    }
                    if (possible == true && stack.Count > 1)
                    {
                        Console.WriteLine("Chybí operátor!");
                    }
                }
            }
        }
    }
}
