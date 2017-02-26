using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Triangle
    {
        public Point[] points;
        private Edge[] edges;

        public Triangle(Point[] points)
        {
            this.points = points;
        }

        private Edge[] CreateEdges(Point[] points)
        {
            Edge[] edges = new Edge[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                if (i < points.Length - 1)
                    edges[i] = new Edge(points[i], points[i + 1]);
                else edges[i] = new Edge(points[i], points[0]);
            }
            return edges;
        }

        public bool CheckTriangle(Point[] points)
        {
            edges = CreateEdges(points);
            double a = 0, b = 0, c = 0;
            a = edges[0].GetLength(edges[0].v1, edges[0].v2);
            b = edges[1].GetLength(edges[1].v1, edges[1].v2);
            c = edges[2].GetLength(edges[2].v1, edges[2].v2);

            if ((a + b > c) && (b + c > a) && (c + a > b))
                return true;
            else return false;
        }

        public int GetTriangleType(Point[] points)
        {
            edges = CreateEdges(points);
            double a = 0, b = 0, c = 0;
            a = edges[0].GetLength(edges[0].v1, edges[0].v2);
            b = edges[1].GetLength(edges[1].v1, edges[1].v2);
            c = edges[2].GetLength(edges[2].v1, edges[2].v2);

            if (((a * a + b * b == c * c) | (b * b + c * c == a * a) | (c * c + a * a == b * b)) & ((a == b) | (a == c) | (b == c)))
                    return 1; //(right and isosceles) прямоугольный и равнобедренный
                else if ((a * a + b * b == c * c) | (b * b + c * c == a * a) | (c * c + a * a == b * b))
                    return 2; //(right) прямоугольный
            else if ((a == b) | (a == c) | (b == c))
                return 3; //(isosceles) равнобедренный
            else return 4; //(normal) обычный     
        }

        public double GetPerimeter(Point[] points)
        {
            edges = CreateEdges(points);
            double a = 0, b = 0, c = 0;
            a = edges[0].GetLength(edges[0].v1, edges[0].v2);
            b = edges[1].GetLength(edges[1].v1, edges[1].v2);
            c = edges[2].GetLength(edges[2].v1, edges[2].v2);

            return a + b + c;
        }

        public double GetArea(Point[] points)
        {
            edges = CreateEdges(points);
            double a = 0, b = 0, c = 0, s = 0;
            a = edges[0].GetLength(edges[0].v1, edges[0].v2);
            b = edges[1].GetLength(edges[1].v1, edges[1].v2);
            c = edges[2].GetLength(edges[2].v1, edges[2].v2);
            s = GetPerimeter(points) / 2;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
