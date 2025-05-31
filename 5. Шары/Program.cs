using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split(' ');
        double XN = double.Parse(firstLine[0]);
        double YN = double.Parse(firstLine[1]);
        double ZN = double.Parse(firstLine[2]);
        double RN = double.Parse(firstLine[3]);
        int M = int.Parse(Console.ReadLine());

        List<Sphere> spheres = new List<Sphere>();
        spheres.Add(new Sphere(XN, YN, ZN, RN));

        for (int i = 0; i < M; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            double Xi = double.Parse(line[0]);
            double Yi = double.Parse(line[1]);
            double Zi = double.Parse(line[2]);
            double Ri = double.Parse(line[3]);
            spheres.Add(new Sphere(Xi, Yi, Zi, Ri));
        }
        for (int i = 1; i <= M; i++)
        {
            List<Sphere> spheresnow = spheres.GetRange(0, i + 1);
            if (AreAllSpheresIntersecting(spheresnow))
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(0);
    }
     static bool AreAllSpheresIntersecting(List<Sphere> spheres)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            bool intersects = false;
            for (int j = 0; j < spheres.Count; j++)
            {
                if (i != j && AreIntersecting(spheres[i], spheres[j]))
                {
                    intersects = true;
                    break;
                }
            }
            if (!intersects)
                return false;
        }
        return true;
    }

    static bool AreIntersecting(Sphere s1, Sphere s2)
    {
        double dx = s1.X - s2.X;
        double dy = s1.Y - s2.Y;
        double dz = s1.Z - s2.Z;
        double dist = dx * dx + dy * dy + dz * dz;
        double radiussum = s1.Radius + s2.Radius;
        return dist < radiussum * radiussum;
    }
}
    class Sphere
{
    public double X {get;}
    public double Y {get;}
    public double Z {get;}
    public double Radius {get;}
    public Sphere(double x, double y, double z, double radius)
    {
        X = x;
        Y = y;
        Z = z;
        Radius = radius;
    }
}
