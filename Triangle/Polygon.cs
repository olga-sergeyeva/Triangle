using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Polygon
    {
        public Point[] points;
        private Edge[] edges;

        public Polygon(Point[] points)
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

        public Triangle[] TriangulatePolygon(Point[] points)
        {
            Point[] temp = new Point[3];
            Triangle[] triangles = new Triangle[points.Length - 2];

            for (int i = 0; i < points.Length - 2; i++)
            {
                temp[0] = points[0];
                for (int j = 1; j < temp.Length; j++)
                    temp[j] = points[i + j];

                triangles[i] = new Triangle(temp);
            }

            return triangles;
        }

        public double GetPerimeter(Point[] points)
        {
            double perimeter = 0;
            edges = CreateEdges(points);

            for (int i = 0; i < points.Length; i++)
                perimeter += edges[i].GetLength(edges[i].v1, edges[i].v2);

            return perimeter;
        }

        public double GetArea(Point[] points)
        {
            double area = 0;
            Point[] temp = new Point[3];
            Triangle[] triangles = new Triangle[points.Length - 2];

            triangles = TriangulatePolygon(points);
            for (int i = 0; i < points.Length - 2; i++)
            {
                temp[0] = points[0];
                for (int j = 1; j < temp.Length; j++)
                    temp[j] = points[i + j];

                area += triangles[i].GetArea(temp);
            }

            return area;
        }
    }
}
