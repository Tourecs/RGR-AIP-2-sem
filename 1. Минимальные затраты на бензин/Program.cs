using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] cost = new int[N + 1];
        string[] COST = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i <= N; i++)
            cost[i] = int.Parse(COST[i - 1]);
            int M = int.Parse(Console.ReadLine());
        List<int>[] graph = new List<int>[N + 1];

        for (int i = 1; i <= N; i++) 
            graph[i] = new List<int>();

        for (int i = 0; i < M; i++)
        {
            string[] edge = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }
        int[] minroad = new int[N + 1];
        for (int i = 0; i <= N; i++)
            minroad[i] = int.MaxValue;

        minroad[1] = 0;
        var priorityquite = new SortedSet<(int road, int city)>();
        priorityquite.Add((minroad[1], 1));
        while (priorityquite.Count > 0)
        {
            var (roadnow, citynow) = priorityquite.Min;
            priorityquite.Remove(priorityquite.Min);
            if (citynow == N)
                break;
            foreach (var neighbor in graph[citynow])
            {
                int newroad = roadnow + cost[citynow];
                if (newroad < minroad[neighbor])
                {
                    minroad[neighbor] = newroad;
                    priorityquite.Add((newroad, neighbor));
                }
            }
        }
        if (minroad[N] == int.MaxValue)
            Console.WriteLine(-1);
        else
            Console.WriteLine(minroad[N]);
    }
}