namespace BinarniVyhledavaciStromy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();

            tree.Insert(4, "a");
            tree.Insert(1, "b");
            tree.Insert(6, "c");
            tree.Insert(3, "d");
            tree.Insert(5, "e");
            tree.Insert(2, "f");

            Console.WriteLine("TOTO JE STROM"); //Vypis celeho stromu
            tree.Print();

            Console.WriteLine("\nMinimum:"); //Hledani minima
            Node<string> min = tree.FindMin(tree.Root);
            Console.WriteLine($"{min.Key} : {min.Value}");

            Console.WriteLine("\nHledany prvek:"); //Hledani prvku
            Node<string> found = tree.Find(11);
            if (found != null)
                Console.WriteLine(found.Value);
            else 
                Console.WriteLine("ZAS TOLIK PRVKU TU NENI");

            tree.Remove(4); //Odstraneni prvku

            Console.WriteLine("\nStrom po mazani:");
            tree.Print();

            Console.ReadLine();
        }
    }

    class BinarySearchTree<T>
    {
        public Node<T> Root;

        public void Insert(int newKey, T newValue)
        {
            void _insert(Node<T> node, int newKey, T newValue)
            {
                if (newKey < node.Key)
                {
                    if (node.LeftSon == null)
                        node.LeftSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.LeftSon, newKey, newValue);
                }
                else if (newKey > node.Key)
                {
                    if (node.RightSon == null)
                        node.RightSon = new Node<T>(newKey, newValue);
                    else
                        _insert(node.RightSon, newKey, newValue);
                }
                else
                {
                    throw new Exception("Tento klic je jiz zabrany");
                }
            }

            if (Root == null)
                Root = new Node<T>(newKey, newValue);
            else
                _insert(Root, newKey, newValue);
        }

        public Node<T> Find(int key)
        {
            Node<T> current = Root;

            while (current != null)
            {
                if (key == current.Key)
                    return current;

                if (key < current.Key)
                    current = current.LeftSon;
                else
                    current = current.RightSon;
            }

            return null;
        }

        public Node<T> FindMin(Node<T> node)
        {
            if (node == null)
                return null;

            while (node.LeftSon != null)
                node = node.LeftSon;

            return node;
        }

        public void Print()
        {
            void _print(Node<T> node)
            {
                if (node == null)
                    return;

                _print(node.LeftSon);
                Console.WriteLine($"{node.Key} : {node.Value}");
                _print(node.RightSon);
            }

            _print(Root);
        }

        public void Remove(int key)
        {
            Root = _remove(Root, key);
        }

        private Node<T> _remove(Node<T> node, int key)
        {
            if (node == null)
                return null;

            if (key < node.Key)
                node.LeftSon = _remove(node.LeftSon, key);

            else if (key > node.Key)
                node.RightSon = _remove(node.RightSon, key);

            else
            {
                if (node.LeftSon == null && node.RightSon == null)
                    return null;

                if (node.LeftSon == null)
                    return node.RightSon;

                if (node.RightSon == null)
                    return node.LeftSon;

                Node<T> min = FindMin(node.RightSon);

                node.Key = min.Key;
                node.Value = min.Value;

                node.RightSon = _remove(node.RightSon, min.Key);
            }

            return node;
        }
    }

    class Node<T>
    {
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }

        public int Key;
        public T Value;

        public Node<T> LeftSon;
        public Node<T> RightSon;
    }
}


