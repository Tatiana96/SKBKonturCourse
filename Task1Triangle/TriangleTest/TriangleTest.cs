using System;
using TriangleCalculation;
using Task1Triangle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleTest
{
    [TestClass]
    public class TriangleClassTest
    {
        [TestMethod]
        public void testTranslationFromDegreesToRadianForCorrectCalculation()
        {
            // Arrange:
            double angle = 60;

            // Act:
            var result = MathCalculation.DegreesToRadian(angle);

            // Assert:
            Assert.AreEqual(1, result, 10e-2);
        } // тестирование перевода градусов в радианы

        [TestMethod]
        public void testUsingCosineTheoremForCorrectCalculation()
        {
            // Arrange:
            double side1 = 3;
            double side2 = 4;
            double angle = 90;

            // Act:
            var result = MathCalculation.UseСosineTheorem(side1, side2, angle);

            // Assert:
            Assert.AreEqual(5, result);
        } // тестирование теоремы косинусов

        [TestMethod]
        public void testUsingSinesTheoremForCorrectCalculation()
        {
            // Arrange:
            double knownSide = 5;
            double angle1 = 60;
            double angle2 = 60;

            // Act:
            var result = MathCalculation.UseSinesTheorem(knownSide, angle1, angle2);

            // Assert:
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(5, result[0], 10e-1);
            Assert.AreEqual(5, result[1], 10e-1);
        } // тестирование теоремы синусов

        [TestMethod]
        public void testUsingHeronFormulaForCorrectCalculation()
        {
            // Arrange:
            double side1 = 4;
            double side2 = 5;
            double side3 = 6;

            // Act:
            var result = MathCalculation.UseHeronFormula(side1, side2, side3);

            // Assert:
            Assert.AreEqual(10, result, 10e-2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A triangle is not valid with the arguments like these.")]
        public void testTriangleIsExistIfArgumentException()
        {
            // Arrange:
            double angle1 = 800;
            double angle2 = 500;
            double side1 = -1;
            double side2 = 150;
            double side3 = 0;

            // Act:
            var result0 = Triangle.ObjectFromThreeSides(side1, side2, side3);
            var result1 = Triangle.ObjectFromTwoSidesAndAngle(side1, side2, angle1);
            var result2 = Triangle.ObjectFromSideAndTwoAngles(side3, angle1, angle2);

        } // тест создания треугольника с некорректными данными
      }

}
