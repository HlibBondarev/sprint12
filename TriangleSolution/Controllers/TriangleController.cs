using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        //1) Create an ASP.Net Core MVC application which performs appropriate calculations for triangles. Design all classes and methods in your own way.
        //   The application should handle the following requests: Create an Info action that shows the info about a triangle in a form as follows:
        //   ------------------------------------------------------------
        //   Triangle:
        //   ([side_1], [side_2], [side_3])
        //   Reduced:
        //   ([side_1 / perimeter], [side_2 / perimeter], [side_3 / perimeter])
        //   Area = XX
        //   Perimeter = YY
        //   ------------------------------------------------------------
        //   Here[side_1], [side_2], [side_3] are[side1], [side2], [side3] arranged in ascending order.
        public string Info(Triangle triangle)
        {
            return triangle.GetInfo();
        }

        //2) Create an Area action that calculates the area of a triangle
        public string Area(Triangle triangle)
        {
            return string.Format("{0:F4}", triangle.GetArea());
        }

        // 3)Create a Perimeter action that calculates the perimeter of a triangle
        //   [hostname]/triangle/Perimeter? side1 = 10 & side2 = 20 & side3 = 25
        public string Perimeter(Triangle triangle)
        {
            return triangle.GetPerimeter().ToString();
        }

        // 4) Create an IsRightAngled action that returns boolean True or False depending on the
        //    triangle is right-angled or not
        public bool IsRightAngled(Triangle triangle)
        {
            return triangle.IsRightAngled();
        }

        // 5) Create an IsEquilateral action that returns boolean True or False depending on the
        //    triangle is equilateral or not
        public bool IsEquilateral(Triangle triangle)
        {
            return triangle.IsEquilateral();
        }

        // 6) Create an IsIsosceles action that returns boolean True or False depending on the
        //    triangle is isosceles or not
        public bool IsIsosceles(Triangle triangle)
        {
            return triangle.IsIsosceles();
        }

        // 7) Create an AreCongruent action that returns boolean True or False depending on two triangles
        //    are congruent or not
        public bool AreCongruent(Triangle triangle1, Triangle triangle2)
        {
            return triangle1.AreCongruent(triangle2);
        }

        // 8) Create an AreSimilar action that returns boolean Return True or False depending on two triangles
        // // are similar or not
        public bool AreSimilar(Triangle triangle1, Triangle triangle2)
        {
            return triangle1.AreSimilar(triangle2);
        }

        // 9) Create an InfoGreatestPerimeter action that returns the info about the triangle with greatest
        //    perimeter (given the array of triangles). The form of result should be as in task1.
        public string InfoGreatestPerimeter(Triangle[] trianglesArray)
        {
            return Triangle.InfoGreatestPerimeter(trianglesArray);
        }

        // 10) Create an InfoGreatestArea action that returns the info about the triangle with greatest Area
        //     (given the array of triangles). The form of result should be as in task1.
        public string InfoGreatestArea(Triangle[] trianglesArray)
        {
            return Triangle.InfoGreatestArea(trianglesArray);
        }

        // 11) Create an NumbersPairwiseNotSimilar action that returns pairs of triangles chosen from the given
        //     array which are pairwise non-similar
        public string NumbersPairwiseNotSimilar(Triangle[] trianglesArray)
        {
            return Triangle.NumbersPairwiseNotSimilar(trianglesArray);
        }
    }
}
