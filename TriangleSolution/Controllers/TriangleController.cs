using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        // Each request should return an error page in case if the triangle is invalid (e.g. (10, 20, 100)) 
        public IActionResult Error(string exceptionMessage) => BadRequest($"Exception message:{exceptionMessage}");

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
        [NonAction]
        public string Info(Triangle triangle) => triangle.GetInfo();
        [ActionName("Info")]
        public IActionResult InfoAction(double side1, double side2, double side3)
        {
            try
            {
                return Content(Info(new Triangle(side1, side2, side3)));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        //2) Create an Area action that calculates the area of a triangle
        [NonAction]
        public string Area(Triangle triangle) => string.Format("{0:F4}", triangle.GetArea());
        [ActionName("Area")]
        public IActionResult AreaAction(double side1, double side2, double side3)
        {
            try
            {
                return Content(Area(new Triangle(side1, side2, side3)));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 3)Create a Perimeter action that calculates the perimeter of a triangle
        [NonAction]
        public string Perimeter(Triangle triangle) => string.Format("{0:F0}", triangle.GetPerimeter());
        [ActionName("Perimeter")]
        public IActionResult PerimeterAction(double side1, double side2, double side3)
        {
            try
            {
                return Content(Perimeter(new Triangle(side1, side2, side3)));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 4) Create an IsRightAngled action that returns boolean True or False depending on the
        //    triangle is right-angled or not
        [NonAction]
        public bool IsRightAngled(Triangle triangle) => triangle.IsRightAngled();
        [ActionName("IsRightAngled")]
        public IActionResult IsRightAngledAction(double side1, double side2, double side3)
        {
            try
            {
                return Content(IsRightAngled(new Triangle(side1, side2, side3)).ToString());
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 5) Create an IsEquilateral action that returns boolean True or False depending on the
        //    triangle is equilateral or not
        [NonAction]
        public bool IsEquilateral(Triangle triangle)
        {
            return triangle.IsEquilateral();
        }
        [ActionName("IsEquilateral")]
        public IActionResult IsEquilateralAction(double side1, double side2, double side3)
        {
            try
            {
                return Content(IsEquilateral(new Triangle(side1, side2, side3)).ToString());
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 6) Create an IsIsosceles action that returns boolean True or False depending on the
        //    triangle is isosceles or not
        [NonAction]
        public bool IsIsosceles(Triangle triangle)
        {
            return triangle.IsIsosceles();
        }
        [ActionName("IsIsosceles")]
        public IActionResult IsIsoscelesAction(double side1, double side2, double side3)
        {
            try
            {
                return Content(IsIsosceles(new Triangle(side1, side2, side3)).ToString());
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 7) Create an AreCongruent action that returns boolean True or False depending on two triangles
        //    are congruent or not
        [NonAction]
        public bool AreCongruent(Triangle triangle1, Triangle triangle2)
        {
            return Triangle.AreCongruent(triangle1, triangle2);
        }
        [ActionName("AreCongruent")]
        public IActionResult AreCongruentAction(Triangle tr1, Triangle tr2)
        {
            try
            {
                return Content(AreCongruent(new Triangle(tr1.Side1, tr1.Side2, tr1.Side3),
                                            new Triangle(tr2.Side1, tr2.Side2, tr2.Side3)).ToString());
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }


        // 8) Create an AreSimilar action that returns boolean Return True or False depending on two triangles
        //    are similar or not
        [NonAction]
        public bool AreSimilar(Triangle triangle1, Triangle triangle2)
        {
            return Triangle.AreSimilar(triangle1, triangle2);
        }
        [ActionName("AreSimilar")]
        public IActionResult AreSimilarAction(Triangle tr1, Triangle tr2)
        {
            try
            {
                return Content(AreSimilar(new Triangle(tr1.Side1, tr1.Side2, tr1.Side3),
                                          new Triangle(tr2.Side1, tr2.Side2, tr2.Side3)).ToString());
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 9) Create an InfoGreatestPerimeter action that returns the info about the triangle with greatest
        //    perimeter (given the array of triangles). The form of result should be as in task1.
        [NonAction]
        public string InfoGreatestPerimeter(Triangle[] trianglesArray)
        {
            return Triangle.InfoGreatestPerimeter(trianglesArray);
        }
        [ActionName("InfoGreatestPerimeter")]
        public IActionResult InfoGreatestPerimeterAction(Triangle[] tr)
        {
            try
            {
                return Content(InfoGreatestPerimeter(tr));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 10) Create an InfoGreatestArea action that returns the info about the triangle with greatest Area
        //     (given the array of triangles). The form of result should be as in task1.
        [NonAction]
        public string InfoGreatestArea(Triangle[] trianglesArray)
        {
            return Triangle.InfoGreatestArea(trianglesArray);
        }
        [ActionName("InfoGreatestArea")]
        public IActionResult InfoGreatestAreaAction(Triangle[] tr)
        {
            try
            {
                return Content(InfoGreatestArea(tr));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }

        // 11) Create an NumbersPairwiseNotSimilar action that returns pairs of triangles chosen from the given
        //     array which are pairwise non-similar
        [NonAction]
        public string NumbersPairwiseNotSimilar(Triangle[] trianglesArray)
        {
            return Triangle.NumbersPairwiseNotSimilar(trianglesArray);
        }
        [ActionName("NumbersPairwiseNotSimilar")]
        public IActionResult NumbersPairwiseNotSimilarAction(Triangle[] tr)
        {
            try
            {
                return Content(NumbersPairwiseNotSimilar(tr));
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { exceptionMessage = e.Message });
            }
        }
    }
}
