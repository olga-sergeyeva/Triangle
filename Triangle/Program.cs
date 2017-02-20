using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double AvgRightPerimeter = 0, AvgIsoscelesArea = 0;
            int RighTriangleCounter = 0, IsoscelesTriangleCounter = 0;

            Console.Write("Введите число треугольников в массиве: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Point[] vertices = new Point[3]
            {
                new Point(),
                new Point(),
                new Point()
            };

            Triangle[] triangles = new Triangle[n];

            for (int i = 0; i < triangles.Length; i++)
            {
                Console.WriteLine("Координаты точек треугольника {0}: ", i + 1);
                for(int j = 0; j < vertices.Length; j++)
                {
                    Point.GeneratePoints(vertices);
                    Point.PrintPoints(vertices);
                }

                Edge[] edges = new Edge[3]
                    {
                        new Edge(vertices[0], vertices[1]),
                        new Edge(vertices[1], vertices[2]),
                        new Edge(vertices[2], vertices[0])
                    };

                triangles[i] = new Triangle(vertices, edges);

                int type = Triangle.GetTriangleType(edges);
                if (Triangle.CheckTriangle(edges))
                {
                    if (type == 1 | type == 2)
                    {
                        AvgRightPerimeter += Triangle.GetPerimeter(edges);
                        RighTriangleCounter++;
                    }

                    if (type == 1 | type == 3)
                    {
                        AvgIsoscelesArea += Triangle.GetArea(edges);
                        IsoscelesTriangleCounter++;
                    }
                }

            }

            AvgRightPerimeter /= IsoscelesTriangleCounter;
            AvgIsoscelesArea /= IsoscelesTriangleCounter;

            Console.WriteLine("Средний периметр всех прямоугольных треугольников равен {0}", AvgRightPerimeter);
            Console.WriteLine("Cредняя площадь всех равнобедренных треугольников равна {0}", AvgIsoscelesArea);
            Console.ReadLine();
        }
    }
}
