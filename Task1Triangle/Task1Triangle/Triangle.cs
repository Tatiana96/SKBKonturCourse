using System;
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

        private Triangle(double side1, double side2, double side3)
        {

            if (!TriangleExists(side1, side2, side3))
            {
                throw new ArgumentException("A triangle is not valid with the arguments like these.");
            }

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public static Triangle CreateFromThreeSides(double side1, double side2, double side3)
        {
            if (!ValidateSidesAndAngles(side1, side2, side3))
            {
                throw new ArgumentException("Triangle parameters cannot be negative or null.");
            }
            return new Triangle(side1, side2, side3);
        }

        public static Triangle CreateFromTwoSidesAndAngle(double side1, double side2, double angle1)
        {
            if (!ValidateSidesAndAngles(side1, side2, angle1))
            {
                throw new ArgumentException("Triangle parameters cannot be negative or null.");
            }
            double side3 = GetSideUsingСosineTheorem(side1, side2, angle1);
            return new Triangle(side1, side2, side3);
        }

        public static Triangle CreateFromSideAndTwoAngles(double side1, double angle1, double angle2)
        {
            if (!ValidateSidesAndAngles(side1, angle1, angle2))
            {
                throw new ArgumentException("Triangle parameters cannot be negative or null.");
            }
            double[] requiredSides;
            requiredSides = GetTwoSidesUsingSinesTheorem(side1, angle1, angle2);
            return new Triangle(side1, requiredSides[0], requiredSides[1]);
        }
		
		public double GetArea()
        {
            double semiperimeter = (Side1 + Side2 + Side3) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - Side1) * (semiperimeter - Side2) * (semiperimeter - Side3));
            return area;
        }

        private static bool TriangleExists(double side1, double side2, double side3)
        {
            return (side1 + side2 > side3) && (side2 + side3 > side1) && (side3 + side1 > side2);
        }

        private static bool ValidateSidesAndAngles(params double[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] <= 0)
                    return false;
            }
            return true;
        }

        private static double DegreesToRadian(double Degrees)
        {
            return (Degrees * Math.PI) / 180;
        }

        private static double GetSideUsingСosineTheorem(double side1, double side2, double angle1)
        {
            double side3 = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2) - 2 * Math.Cos(DegreesToRadian(angle1)));
            return side3;
        }

        private static double[] GetTwoSidesUsingSinesTheorem(double side1, double angle1, double angle2)
        {
            double angle3;
            angle3 = 180 - (angle1 + angle2);

            double[] otherSides = new double[2];
            otherSides[0] = side1 * (Math.Sin(DegreesToRadian(angle1)) / Math.Sin(DegreesToRadian(angle3))); // находим вторую сторону
            otherSides[1] = side1 * (Math.Sin(DegreesToRadian(angle2)) / Math.Sin(DegreesToRadian(angle3))); // находим третью сторону

            return otherSides;
        }

    }
    
}
