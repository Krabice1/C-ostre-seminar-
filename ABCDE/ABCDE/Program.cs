namespace _15_Abecedni_poradi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vztahy = Console.ReadLine().Split();  //input

            List<char> znakyAbecedy = new List<char>();

            for (int i = 0; i < vztahy.Length; i++)
            {
                string vztah = vztahy[i];

                if (!znakyAbecedy.Contains(vztah[0]))
                    znakyAbecedy.Add(vztah[0]);

                if (!znakyAbecedy.Contains(vztah[2]))
                    znakyAbecedy.Add(vztah[2]);
            }
            //vytvoreni stringu bez zobacku

            int pocetVrcholu = znakyAbecedy.Count;

            int[,] graf = new int[pocetVrcholu, pocetVrcholu];

            foreach (string vztah in vztahy)
            {
                int indexZ = znakyAbecedy.IndexOf(vztah[0]);
                int indexDo = znakyAbecedy.IndexOf(vztah[2]);

                graf[indexZ, indexDo] = 1;
            }

            VypisGraf(graf, pocetVrcholu);     //vypis grafu
            int[] stupneVrcholu = new int[pocetVrcholu];
            for (int i = 0; i < pocetVrcholu; i++)
            {
                int suma = 0;

                for (int j = 0; j < pocetVrcholu; j++)
                {
                    suma += graf[j, i];
                }
                stupneVrcholu[i] = suma;
            }
            Queue<int> fronta = new Queue<int>(); //fronta pro vrcholy se stupnem 0

            for (int i = 0; i < stupneVrcholu.Length; i++)
            {
                if (stupneVrcholu[i] == 0)
                    fronta.Enqueue(i);
            }
            List<char> vysledek = new List<char>();
            while (fronta.Count > 0)
            {
                int u = fronta.Dequeue();
                vysledek.Add(znakyAbecedy[u]);
                for (int v = 0; v < pocetVrcholu; v++) //prochazeni sousedu
                {
                    if (graf[u, v] == 1)
                    {
                        graf[u, v] = 0;

                        stupneVrcholu[v]--;

                        if (stupneVrcholu[v] == 0)
                            fronta.Enqueue(v);
                    }
                }
            }

            if (vysledek.Count != pocetVrcholu) //Jsou ypracovany vsechny vrcholy? Pokud ne, je v grafu cyklus
            {
                Console.WriteLine("Udelal jsi neco blbe");
            }
            else
            {
                Console.WriteLine("Spravne poradi:");

                foreach (char c in vysledek)
                    Console.Write(c + " ");
            }
        }
        static void VypisGraf(int[,] graf, int pocetVrcholu) //Vypis grafu
        {
            for (int i = 0; i < pocetVrcholu; i++)
            {
                for (int j = 0; j < pocetVrcholu; j++)
                {
                    Console.Write(graf[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}