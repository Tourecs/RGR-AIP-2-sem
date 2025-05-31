using System;

class Program
{
    static void Main()
    {
        string[] sizes = Console.ReadLine().Split(' ');
        int N = int.Parse(sizes[0]);
        int M = int.Parse(sizes[1]);
        int[,] mines = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int j = 0; j < M; j++)
            {
                mines[i, j] = int.Parse(line[j]);
            }
        }
        int[,] mintime = new int[N, M];
        int[,] parent = new int[N, M];
        for (int j = 0; j < M; j++)
        {
            mintime[0, j] = mines[0, j];
            parent[0, j] = -1;
        }
        for (int i = 1; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                int minparent = int.MaxValue;
                int minindex = -1;
                if (j - 1 >= 0 && mintime[i - 1, j - 1] < minparent)
                {
                    minparent = mintime[i - 1, j - 1];
                    minindex = j - 1;
                }
                if (mintime[i - 1, j] < minparent)
                {
                    minparent = mintime[i - 1, j];
                    minindex = j;
                }
                if (j + 1 < M && mintime[i - 1, j + 1] < minparent)
                {
                    minparent = mintime[i - 1, j + 1];
                    minindex = j + 1;
                }

                mintime[i, j] = minparent + mines[i, j];
                parent[i, j] = minindex;
            }
        }
        int minTime = int.MaxValue;
        int lastindex = -1;
        for (int j = 0; j < M; j++)
        {
            if (mintime[N - 1, j] < minTime)
            {
                minTime = mintime[N - 1, j];
                lastindex = j;
            }
        }
        int[] path = new int[N];
        int current = lastindex;
        for (int i = N - 1; i >= 0; i--)
        {
            path[i] = current + 1;
            current = parent[i, current];
        }
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(path[i]);
        }
    }
}
