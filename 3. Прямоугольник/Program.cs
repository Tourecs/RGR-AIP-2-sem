using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        int K = int.Parse(Console.ReadLine());
        bool[,] grid = new bool[M, N];
        for (int i = 0; i < K; i++)
        {
            string[] coords = Console.ReadLine().Split();
            int x = int.Parse(coords[0]) - 1;
            int y = int.Parse(coords[1]) - 1;
            grid[y, x] = true;
        }
        int[] heights = new int[N];
        int maxarea = 0;
        for (int row = 0; row < M; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (grid[row, col])
                    heights[col] = 0;
                else
                    heights[col]++;
            }
            maxarea = Math.Max(maxarea, MaxRectangleArea(heights));
        }
        Console.WriteLine(maxarea);
    }
    static int MaxRectangleArea(int[] heights)
    {
        int maxarea = 0;
        Stack<int> stack = new Stack<int>();
        int index = 0;

        while (index < heights.Length)
        {
            if (stack.Count == 0 || heights[index] >= heights[stack.Peek()])
            {
                stack.Push(index++);
            }
            else
            {
                int top = stack.Pop();
                int area = heights[top] * (stack.Count == 0 ? index : index - stack.Peek() - 1);
                maxarea = Math.Max(maxarea, area);
            }
        }
        while (stack.Count > 0)
        {
            int top = stack.Pop();
            int area = heights[top] * (stack.Count == 0 ? index : index - stack.Peek() - 1);
            maxarea = Math.Max(maxarea, area);
        }
         return maxarea;
    }
}