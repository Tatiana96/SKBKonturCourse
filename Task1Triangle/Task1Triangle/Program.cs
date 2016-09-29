using System;
using TriangleCalculation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Triangle
{
    public class Triangle
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }

        private static bool TriangleIsExist(double side1, double side2, double side3)
        {
            return (side1 + side2 > side3) && (side2 + side3 > side1) && (side3 + side1 > side2);
        } // TriangleIsExists : существует ли треугольник

        private Triangle(double side1, double side2, double side3) {

            if (!TriangleIsExist(side1, side2, side3))
            {
                throw new ArgumentException();
            } // проверка существования треугольника

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        } // Triangle

        public static Triangle ObjectFromThreeSides(double side1, double side2, double side3) {
            return new Triangle(side1, side2, side3);
        } // создание треугольника по трем сторонам

        public static Triangle ObjectFromTwoSidesAndAngle(double side1, double side2, double angle) {
            double side3 = MathCalculation.UseСosineTheorem(side1, side2, angle);
            return new Triangle(side1, side2, side3);
        } // создание треугольника по двум сторонам и углу

        public static Triangle ObjectFromSideAndTwoAngles(double knownSide, double angle1, double angle2) {
            double[] requiredSides; // две неизвестные стороны
            requiredSides = MathCalculation.UseSinesTheorem(knownSide, angle1, angle2);
            return new Triangle(requiredSides[0], requiredSides[1], knownSide);
        } // создание треугольника по стороне и углу
		
	public double GetAreaOfTriangle() {
            return MathCalculation.UseHeronFormula(Side1, Side2, Side3);
        } // возвращение площади треугольника

    }
    class Program
    {
        static void Main(string[] args) {
        }
    }
}
