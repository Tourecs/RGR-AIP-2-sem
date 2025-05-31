using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        List<(int to, int dist)>[] graph = new List<(int, int)>[N + 1];
        for (int i = 0; i <= N; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < M; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int u = int.Parse(parts[0]);
            int v = int.Parse(parts[1]);
            int w = int.Parse(parts[2]);
            graph[u].Add((v, w));
            graph[v].Add((u, w));
        }

        int[] road = new int[N + 1];
        for (int i = 0; i <= N; i++)
            road[i] = int.MaxValue;

            road[1] = 0;
            var priortyque = new SortedSet<(int road, int city)>();
            priortyque.Add((0, 1));

        while (priortyque.Count > 0)
        {
            var current = priortyque.Min;
            priortyque.Remove(current);

            int roadnow = current.road;
            int citynow = current.city;

            if (roadnow > road[citynow])
                continue;

            if (citynow == N)
                break;

            foreach (var edge in graph[citynow])
            {
                int nextcity = edge.to;
                int weight = edge.dist;
                int newroad = roadnow + weight;
                if (newroad < road[nextcity])
                {
                    if (road[nextcity] != int.MaxValue)
                        priortyque.Remove((road[nextcity], nextcity));

                    road[nextcity] = newroad;
                    priortyque.Add((newroad, nextcity));
                }
            }
        }

        Console.WriteLine(road[N] == int.MaxValue ? -1 : road[N]);
    }
}
