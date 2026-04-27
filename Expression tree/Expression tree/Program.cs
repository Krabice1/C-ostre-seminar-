using System;
using System.Collections.Generic;

namespace Expression_tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "5 1 2 + 4 * + 3 -";
            string[] exp = expression.Split();
            Stack<Uzel> uzly = new Stack<Uzel>();

            for (int i = 0; i < exp.Length; i++)
            {
                if (double.TryParse(exp[i], out double value))
                {
                    Uzel uzel = new Uzel(value);
                    uzly.Push(uzel);
                }
                else
                {
                    Uzel pravySynator = uzly.Pop();
                    Uzel levySynator = uzly.Pop();
                    Uzel uzel = new Uzel(exp[i], levySynator, pravySynator);
                    uzly.Push(uzel);
                }
            }

            Uzel koren = uzly.Pop();

            while (true)
            {
                Console.WriteLine("Napiš pro POSTfix (1)/pro PREfix (2)/pro INfix (3)/pro výsledek (4)");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine(koren.DoPostfixu());
                }
                else if (choice == "2")
                {
                    Console.WriteLine(koren.DoPrefixu());
                }
                else if (choice == "3")
                {
                    Console.WriteLine(koren.DoInfixu());
                }
                else if (choice == "4")
                {
                    Console.WriteLine(koren.Vysledek());
                }
                else
                {
                    break;
                }
            }
        }

        class Uzel
        {
            public Uzel LevySynator { get; set; }
            public Uzel PravySynator { get; set; }
            public double Cislo { get; set; }
            public string Operator { get; set; }

            public Uzel(double cislo)
            {
                Cislo = cislo;
                LevySynator = null;
                PravySynator = null;
                Operator = null;
            }

            public Uzel(string op, Uzel levy, Uzel pravy)
            {
                Operator = op;
                LevySynator = levy;
                PravySynator = pravy;
            }

            public string DoPrefixu()
            {
                if (LevySynator == null && PravySynator == null)
                    return Cislo.ToString();

                return Operator + " " + LevySynator.DoPrefixu() + " " + PravySynator.DoPrefixu();
            }

            public string DoPostfixu()
            {
                if (LevySynator == null && PravySynator == null)
                    return Cislo.ToString();

                return LevySynator.DoPostfixu() + " " + PravySynator.DoPostfixu() + " " + Operator;
            }

            public string DoInfixu()
            {
                if (LevySynator == null && PravySynator == null)
                    return Cislo.ToString();

                return "(" + LevySynator.DoInfixu() + " " + Operator + " " + PravySynator.DoInfixu() + ")";
            }

            public double Vysledek()
            {
                if (LevySynator == null && PravySynator == null)
                    return Cislo;

                double left = LevySynator.Vysledek();
                double right = PravySynator.Vysledek();

                switch (Operator)
                {
                    case "+": return left + right;
                    case "-": return left - right;
                    case "*": return left * right;
                    case "/": return left / right;
                    default: throw new Exception("Neznámý operátor");
                }
            }

            public override string ToString()
            {
                return DoInfixu();
            }
        }
    }
}
