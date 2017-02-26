using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void GeneratePoints(Point[] points)
        {
            Random Generator = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = Generator.Next(-10, 10);
                points[i].y = Generator.Next(-10, 10);
            }
        }

        static void PrintPoints(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write(points[i].x + " ");
                Console.Write(points[i].y + " ");
            }
        }

        static void Main(string[] args)
        {
            double AvgRightPerimeter = 0, AvgIsoscelesArea = 0; //cредний периметр прямоугольных треугольников, средняя площадь равнобедренных треугольников
            int RighTriangleCounter = 0, IsoscelesTriangleCounter = 0; //счетчик прямоугольных треугольников, счетчик равнобедренных треугольников

            Console.Write("Введите число треугольников в массиве: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Выберите действие ");
            Console.Write("1 - Сгенерировать координаты точек треугольника, 2 - Ввести координаты точек треугольника с клавиатуры: ");
            int option = Convert.ToInt32(Console.ReadLine());

            Point[] vertices = new Point[3]
            {
                new Point(),
                new Point(),
                new Point()
            };

            Triangle[] triangles = new Triangle[n];

            switch (option)
            {
                case 1:
                    for (int i = 0; i < triangles.Length; i++)
                    {
                        Console.Write("Координаты точек треугольника {0}: ", i + 1);
                        for (int j = 0; j < vertices.Length; j++)
                          GeneratePoints(vertices);

                        PrintPoints(vertices);
                        Console.WriteLine();

                        triangles[i] = new Triangle(vertices);

                        if (triangles[i].CheckTriangle(vertices)) //проверка треугольника на существование
                        {
                            int type = triangles[i].GetTriangleType(vertices); //получает значение, соответствующее определенному типу треугольника
                            if (type == 1 | type == 2)
                            {
                                AvgRightPerimeter += triangles[i].GetPerimeter(vertices);
                                RighTriangleCounter++;
                            }

                            if (type == 1 | type == 3)
                            {
                                AvgIsoscelesArea += triangles[i].GetArea(vertices);
                                IsoscelesTriangleCounter++;
                            }
                            Console.WriteLine("Периметр треугольника {0} = {1}", i + 1, triangles[i].GetPerimeter(vertices));
                            Console.WriteLine("Площадь треугольника {0} = {1}", i + 1, triangles[i].GetArea(vertices));
                        }
                    }

                    break;

                case 2:
                    for (int i = 0; i < triangles.Length; i++)
                    {
                        for (int j = 0; j < vertices.Length; j++)
                        {
                            Console.Write("Введите координату x точки {0} треугольника {1}: ", j, i + 1);
                            vertices[j].x = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Введите координату y точки {0} треугольника {1}: ", j, i + 1);
                            vertices[j].y = Convert.ToDouble(Console.ReadLine());
                        }

                        PrintPoints(vertices);
                        Console.WriteLine();
                        
                        triangles[i] = new Triangle(vertices);
                        if (triangles[i].CheckTriangle(vertices)) //проверка треугольника на существование
                        {
                            int type = triangles[i].GetTriangleType(vertices); //получает значение, соответствующее определенному типу треугольника
                            if (type == 1 | type == 2)
                            {
                                AvgRightPerimeter += triangles[i].GetPerimeter(vertices);
                                RighTriangleCounter++;
                            }

                            if (type == 1 | type == 3)
                            {
                                AvgIsoscelesArea += triangles[i].GetArea(vertices);
                                IsoscelesTriangleCounter++;
                            }
                            Console.WriteLine("Периметр треугольника {0} = {1}", i + 1, triangles[i].GetPerimeter(vertices));
                            Console.WriteLine("Площадь треугольника {0} = {1}", i + 1, triangles[i].GetArea(vertices));
                        }
                    }

                    break;
            }
            Console.WriteLine("Средний периметр всех прямоугольных треугольников равен {0}", AvgRightPerimeter /= RighTriangleCounter);
            Console.WriteLine("Cредняя площадь всех равнобедренных треугольников равна {0}", AvgIsoscelesArea /= IsoscelesTriangleCounter);
            Console.ReadLine();
        }
    }
}
