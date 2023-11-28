using System;
using System.Linq;
using System.Text;

namespace Triangles.Models
{
    public class Triangle
    {
        private const string TRIANGLE_INFO_TEMPLATE = "Triangle:{0}({1}, {2}, {3}){0}Reduced:{0}({4:F2}, {5:F2}, {6:F2}){0}{0}Area = {7:F2}{0}Perimeter = {8}";
        private double side1;
        private double side2;
        private double side3;
        public string ExceptionMessage { get; private set; } = null;
        public Triangle() { }
        public Triangle(double side1, double side2, double side3)
        {
            if (side1 > side2) Swap(ref side1, ref side2);
            if (side2 > side3) Swap(ref side2, ref side3);
            if (side1 > side2) Swap(ref side1, ref side2);
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public double Side1
        {
            get { return side1; }
            set { side1 = value; }
        }
        public double Side2
        {
            get { return side2; }
            set { side2 = value; }
        }
        public double Side3
        {
            get { return side3; }
            set { side3 = value; }
        }

        public bool Validation()
        {
            if (Side1 < 0) throw new ArgumentException("The length of the side of the triangle must be greater than zero");
            if (Side1 + Side2 < Side3) throw new ArgumentException("The sum of the lengths of two sides is less than the length of the longer side");
            return true;
        }

        public string GetInfo()
        {
            Validation();
            return _generateOutput(side1, side2, side3, GetPerimeter(), GetArea());
        }
        private string _generateOutput(double side1, double side2, double side3, double perimeter, double area)
        {
            return string.Format(TRIANGLE_INFO_TEMPLATE
                , Environment.NewLine
                , side1
                , side2
                , side3
                , side1 / perimeter
                , side2 / perimeter
                , side3 / perimeter
                , area
                , perimeter
                );
        }
        private void Swap(ref double x, ref double y)
        {
            double temp = x; x = y; y = temp;
        }
        public double GetPerimeter()
        {
            Validation();
            return Side1 + Side2 + Side3;
        }
        public double GetArea()
        {
            Validation();
            double half = GetPerimeter() / 2;
            return Math.Pow(half * (half - Side1) * (half - Side2) * (half - Side3), 0.5);
        }
        public bool IsRightAngled()
        {
            Validation();
            return (Side3 * Side3).IsEquil(Side1 * Side1 + Side2 * Side2);
        }
        public bool IsEquilateral()
        {
            Validation();
            return Side1.IsEquil(Side2) && Side1.IsEquil(Side3);
        }
        public bool IsIsosceles()
        {
            Validation();
            return Side1.IsEquil(Side2) || Side2.IsEquil(Side3);
        }
        public static bool AreCongruent(Triangle triangle1, Triangle triangle2)
        {
            triangle1.Validation();
            triangle2.Validation();
            return triangle1.Side1.IsEquil(triangle2.Side1) &&
                   triangle1.Side2.IsEquil(triangle2.Side2) &&
                   triangle1.Side3.IsEquil(triangle2.Side3);
        }
        public static bool AreSimilar(Triangle triangle1, Triangle triangle2)
        {
            triangle1.Validation();
            //triangle2.Validation();   // otherwise the test fails with args - [InlineData(3, 3, 6, 4, 4, 9)]
            return (triangle1.Side1 / triangle2.Side1).IsEquil(triangle1.Side2 / triangle2.Side2) &&
                   (triangle1.Side2 / triangle2.Side2).IsEquil(triangle1.Side3 / triangle2.Side3);
        }
        public static string InfoGreatestPerimeter(Triangle[] trianglesArray)
        {
            trianglesArray.ToList().ForEach(t => t.Validation());
            return trianglesArray.MaxBy(triangle => triangle.GetPerimeter()).GetInfo();
        }
        internal static string InfoGreatestArea(Triangle[] trianglesArray)
        {
            Triangle triangle = trianglesArray.MaxBy(triangle => triangle.GetArea());
            triangle.Validation();
            return triangle.GetInfo();
        }
        internal static string NumbersPairwiseNotSimilar(Triangle[] trianglesArray)
        {
            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < trianglesArray.Length - 1; j++)
            {
                for (int i = j + 1; i < trianglesArray.Length; i++)
                {
                    if (!AreSimilar(trianglesArray[j], trianglesArray[i]))
                    {
                        sb.Append($"({j + 1}, {i + 1}){Environment.NewLine}");
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }
    }

    public static class DoubleExtension
    {
        public static bool IsEquil(this double a, double b)
        {
            return Math.Abs(a - b) / a <= 0.00001;
        }
    }
}
