using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Triangle
    {
        Edge[] edges = new Edge[3];
        Point[] vertices = new Point[3];

        public Triangle(Point[] vertices, Edge[] edges)
        {
            this.vertices = vertices;
            this.edges = edges;
        }

        public static bool CheckTriangle(Edge[] edges)
        {
            double a, b, c; //a, b, c - длины сторон
            a = Edge.GetLength(edges[0].v1, edges[0].v2);
            b = Edge.GetLength(edges[1].v1, edges[1].v2);
            c = Edge.GetLength(edges[2].v1, edges[2].v2);

            if ((a + b > c) && (b + c > a) && (c + a > b))
                return true;
            else return false;
        }

        public static int GetTriangleType(Edge[] edges)
        {
            double a, b, c; //a, b, c - длины сторон
            a = Edge.GetLength(edges[0].v1, edges[0].v2);
            b = Edge.GetLength(edges[1].v1, edges[1].v2);
            c = Edge.GetLength(edges[2].v1, edges[2].v2);

            if (((a * a + b * b == c * c) || (b * b + c * c == a * a) || (c * c + a * a == b)) & ((a == b) || (a == c) || (b == c)))
                return 1; //(right and isosceles) прямоугольный и равнобедренный
            else if ((a * a + b * b == c * c) || (b * b + c * c == a * a) || (c * c + a * a == b))
                return 2; //(right) прямоугольный
            else if ((a == b) || (a == c) || (b == c))
                return 3; //(isosceles) равнобедренный
            else return 4; //(normal) обычный
        }

        public static double GetPerimeter(Edge[] edges)
        {
            return Edge.GetLength(edges[0].v1, edges[0].v2) + Edge.GetLength(edges[1].v1, edges[1].v2) + Edge.GetLength(edges[1].v1, edges[1].v2);
        }

        public static double GetArea(Edge[] edges)
        {
            double a, b, c, s; //a, b, c - длины сторон, s - (semiperimeter) полупериметр
            a = Edge.GetLength(edges[0].v1, edges[0].v2);
            b = Edge.GetLength(edges[1].v1, edges[1].v2);
            c = Edge.GetLength(edges[2].v1, edges[2].v2);
            s = GetPerimeter(edges) / 2;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
