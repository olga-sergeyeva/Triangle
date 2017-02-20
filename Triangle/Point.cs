using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Point
    {
        public double x;
        public double y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public static void GeneratePoints(Point[] points)
        {
            Random Generator = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = Generator.Next(0, 10);
                points[i].y = Generator.Next(0, 10);
            }
        }

        public static void PrintPoints(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write(points[i].x + " ");
                Console.Write(points[i].y + " ");
            }
        }
    }
}
