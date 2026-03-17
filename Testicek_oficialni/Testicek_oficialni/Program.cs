internal class Program
{
    private static void Main(string[] args)
    {
        int N = 4; //pocet mest
        int[,] sousednost = new int[3, 2] //sousedici mesta
        {
                {1, 2},
                {2, 3},
                {3, 4}
        };
        bool vedlesebe = false;
        List<int> seznam = new List<int>();
        List<int> seznam2 = new List<int>();

        VedleSebe(1, 4);

        int VedleSebe(int start, int cil)
        {
            for (int i = 0; i < N - 1; i++)
            {
                if (start == sousednost[i, 0] && cil == sousednost[i, 1])
                {
                    Console.WriteLine("Start a cíl jsou hned vedle sebe!");
                    vedlesebe = true;
                    return start;
                }
                else
                {
                    Console.WriteLine("Start a cíl jsou moc daleko, musím pokračovat!");
                }
            }
            Console.WriteLine("Bohužel nejsou vedle sebe :(");
            return start;
        }

        int[] DoSirky(int start, int cil)
        {
            for (int i = 0; i < N - 1; i++)
            {
                if (start == sousednost[i, 0])
                {
                    seznam.Add(sousednost[i, 1]);
                }

            }
            return start;

            for (int i = 0; i < seznam.Count(); i++) 
            {
                for (int j = 0; j < N - 1; j++)
                {
                    if (seznam[i] == sousednost[j, 0])
                    {
                        seznam2.Add(sousednost[j, 1]);
                    }
                }
            }
        }
    }
}