using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using ComputerAlgebra;

namespace Algebra.Tests
{
    [TestClass]
    public class ComputingAlgebraTest
    {
        [TestMethod]
        public void ArithmeticOperationTest()
        {
            // Arrange:
            Expression<Func<double, double>> f = x => x * x;
            Func<double, double> df = f.DifferentiateExpression();

            // Act
            double result = df.Invoke(12);

            // Assert
            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void SinusTest()
        {
            // Arrange:
            Expression<Func<double, double>> f = x => (10 + Math.Sin(x)) * x;
            Func<double, double> df = f.DifferentiateExpression();

            // Act
            double result = df.Invoke(12);

            //Assert
            Assert.AreEqual(19.58967, result, 5);
            
        }
    }
}

