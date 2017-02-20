using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Edge
    {
        public Point v1; //(vertice1) вершина1
        public Point v2; //(vertice2) вершина2

        public Edge(Point v1, Point v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public static double GetLength(Point v1, Point v2)
        {
            return Math.Sqrt(Math.Pow((v2.x - v1.x), 2) + Math.Pow((v2.y - v1.y), 2));
        }
    }
}
