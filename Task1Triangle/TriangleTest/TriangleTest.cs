using System;
using Task1Triangle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleTest
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A triangle is not valid with the arguments like these.")]
        public void CreateFromThreeSides_InvalidSides_ArgumentException()
        {
            // Arrange:
            double side1 = 50;
            double side2 = 70;
            double side3 = 10;

            // Act:
            var result = Triangle.CreateFromThreeSides(side1, side2, side3);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Triangle parameters cannot be negative or null.")]
        public void CreateFromTwoSidesAndAngle_InvalidAngle_ArgumentException()
        {
            // Arrange:
            double side1 = 3;
            double side2 = 4;
            double angle1 = 0;

            // Act:
            var result = Triangle.CreateFromTwoSidesAndAngle(side1, side2, angle1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Triangle parameters cannot be negative or null.")]
        public void CreateFromSideAndTwoAngles_InvalidAnglesAndSides_ArgumentException()
        {
            // Arrange:
            double side1 = -10;
            double angle1 = 800;
            double angle2 = -15;

            // Act:
            var result = Triangle.CreateFromSideAndTwoAngles(side1, angle1, angle2);

        }

        [TestMethod]
        public void GetArea_CorrectSides_AreaEquals10()
        {
            // Arrange:
            double side1 = 4;
            double side2 = 5;
            double side3 = 6;

            // Act:
            Triangle triangleObj = Triangle.CreateFromThreeSides(side1, side2, side3);
            var result = triangleObj.GetArea();

            // Assert:
            Assert.AreEqual(10, result, 10e-1);

        }

        [TestMethod]
        public void GetArea_CorrectSides_AreaEquals6()
        {
            // Arrange:
            double side1 = 3;
            double side2 = 4;
            double angle1 = 90;

            // Act:
            Triangle triangleObj = Triangle.CreateFromTwoSidesAndAngle(side1, side2, angle1);
            var result = triangleObj.GetArea();

            // Assert:
            Assert.AreEqual(6, result);

        }

        [TestMethod]
        public void GetArea_CorrectSides_AreaEquals27()
        {
            // Arrange:
            double side1 = 8;
            double angle1 = 60;
            double angle2 = 60;

            // Act:
            Triangle triangleObj = Triangle.CreateFromSideAndTwoAngles(side1, angle1, angle2);
            var result = triangleObj.GetArea();

            // Assert:
            Assert.AreEqual(27, result, 10e-1);

        }
    }

}
