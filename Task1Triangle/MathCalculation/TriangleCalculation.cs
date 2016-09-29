using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculation
{
    public class MathCalculation
    {
        public static double DegreesToRadian(double Degrees) {
            return (Degrees * Math.PI) / 180;
        } // double DegToRad : перевод градусов в радианы

        public static double UseСosineTheorem(double side1, double side2, double angle)
        {
            double side3 = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2) - 2 * Math.Cos( DegreesToRadian(angle) ) );
            return side3;
        } // double UseСosineTheorem : применение теоремы косинусов

        public static double[] UseSinesTheorem(double side, double angle1, double angle2)
        {
            double angle3;
            // находим еще один угол, используя теорему о сумме углов треугольника
            angle3 = 180 - (angle1 + angle2);

            double[] otherSides = new double[2];
            otherSides[0] = side * (Math.Sin( DegreesToRadian(angle1) ) / Math.Sin( DegreesToRadian(angle3) ) ); // находим вторую сторону
            otherSides[1] = side * (Math.Sin( DegreesToRadian(angle2) ) / Math.Sin( DegreesToRadian(angle3) ) ); // находим третью сторону

            return otherSides;
        } // double UseSinesTheorem : применение теоремы синусов

        public static double UseHeronFormula(double side1, double side2, double side3)
        {
            double semiperimeter = (side1 + side2 + side3) / 2; // полупериметр треугольника
            double area = Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));
            return area;
        } // double UseHeronFormula : применение формулы Герона

    } // class MathCalculation
}
