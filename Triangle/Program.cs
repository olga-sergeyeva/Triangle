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
            double AvgRightPerimeter = 0, AvgIsoscelesArea = 0; //cредний периметр прямоугольных треугольников, средняя площадь равнобедренных треугольников
            int RighTriangleCounter = 0, IsoscelesTriangleCounter = 0; //счетчик прямоугольных треугольников, счетчик равнобедренных треугольников

            Console.Write("Введите число треугольников в массиве: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Point[] vertices = new Point[3]
            {
                new Point(),
                new Point(),
                new Point()
            };

            Edge[] edges = new Edge[3]
            {
                new Edge(vertices[0], vertices[1]),
                new Edge(vertices[1], vertices[2]),
                new Edge(vertices[2], vertices[0])
            };

            Triangle[] triangles = new Triangle[n];

            triangles[0] = new Triangle(vertices, edges);
            for (int i = 0; i < triangles.Length; i++)
            {
                Console.Write("Координаты точек треугольника {0}: ", i + 1);
                for (int j = 0; j < vertices.Length; j++)
                    Point.GeneratePoints(vertices);
                Point.PrintPoints(vertices);
                Console.WriteLine();

                triangles[i] = new Triangle(vertices, edges);

                if (Triangle.CheckTriangle(edges)) //проверка треугольника на существование
                {
                    int type = Triangle.GetTriangleType(edges); //получает значение, соответствующее определенному типу треугольника
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

                    Console.WriteLine("Периметр треугольника {0} = {1}", i + 1, Triangle.GetPerimeter(edges));
                    Console.WriteLine("Площадь треугольника {0} = {1}", i + 1, Triangle.GetArea(edges));
                }
            }

            Console.WriteLine("Средний периметр всех прямоугольных треугольников равен {0}", AvgRightPerimeter /= RighTriangleCounter);
            Console.WriteLine("Cредняя площадь всех равнобедренных треугольников равна {0}", AvgIsoscelesArea /= IsoscelesTriangleCounter);
            Console.ReadLine();
        }
    }
}
