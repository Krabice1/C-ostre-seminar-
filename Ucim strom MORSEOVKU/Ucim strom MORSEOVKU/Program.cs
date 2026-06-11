using System;

class Node
{
    public char Pismeno;
    public Node Left;
    public Node Right;
    public Node(char pismeno)
    {
        Pismeno = pismeno;
    }
}

class Program
{
    static Node BuildTree()
    {
        Node root = new Node('\0');        // Přiznávám užití AI, chatgpt potahalo, jinak bych asi zešílel ;)
        root.Left = new Node('E');         // Radši bych měl méně bodů za úlohu než paranoidní schizofrenii z vypisování toho stromu
        root.Right = new Node('T');     
        root.Left.Left = new Node('I');
        root.Left.Right = new Node('A');
        root.Right.Left = new Node('N');
        root.Right.Right = new Node('M');
        root.Left.Left.Left = new Node('S');
        root.Left.Left.Right = new Node('U');
        root.Left.Right.Left = new Node('R');
        root.Left.Right.Right = new Node('W');
        root.Right.Left.Left = new Node('D');
        root.Right.Left.Right = new Node('K');
        root.Right.Right.Left = new Node('G');
        root.Right.Right.Right = new Node('O');
        root.Left.Left.Left.Left = new Node('H');
        root.Left.Left.Left.Right = new Node('V');
        root.Left.Left.Right.Left = new Node('F');
        root.Left.Right.Left.Left = new Node('L');
        root.Left.Right.Right.Left = new Node('P');
        root.Left.Right.Right.Right = new Node('J');
        root.Right.Left.Left.Left = new Node('B');
        root.Right.Left.Left.Right = new Node('X');
        root.Right.Left.Right.Left = new Node('C');
        root.Right.Left.Right.Right = new Node('Y');
        root.Right.Right.Left.Left = new Node('Z');
        root.Right.Right.Left.Right = new Node('Q');

        return root;
    }

    private static string Decode(string mor, Node root)
    {
        string a = "";
        Node n = root;
        int u = 0;

        foreach (char c in mor)
        {
            u++;
            if (c == '.')
            {
                u = 0;
                n = n.Left;
            }
            else if (c == '-')
            {
                u = 0;
                n = n.Right;
            }
            else if (c == '/')
            {
                if (n != null && n.Pismeno != '\0')
                    a += n.Pismeno;
                a += ' ';
                n = root;
                u = 0;
            }

        }

        return a;
    }

    static void Main()
    {
        Node root = BuildTree();
        string input = Console.ReadLine();
        Console.WriteLine(Decode(input, root));
    }
}