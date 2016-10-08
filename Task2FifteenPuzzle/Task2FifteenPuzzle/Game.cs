using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2FifteenPuzzle
{
    public struct Index
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Game : IGame
    {
        protected int[,] MatrixValues { get; set; }
        protected int MatrixSize { get; set; }

        protected Index[] MatrixIndexArray;

        public Game(params int[] valuesArray)
        {
            ValidateMatrixValues(valuesArray);

            MatrixSize = (int)Math.Sqrt(valuesArray.Length);

            MatrixIndexArray = new Index[valuesArray.Length];
            MatrixValues = new int[MatrixSize, MatrixSize];

            for (var i = 0; i < MatrixSize; i++)
            {
                for (var j = 0; j < MatrixSize; j++)
                {
                    var index = new Index
                    {
                        x = i,
                        y = j,
                    };

                    var currentvalue = valuesArray[i * MatrixSize + j];
                    MatrixValues[i, j] = currentvalue;
                    try
                    {
                        MatrixIndexArray[currentvalue] = index;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("Invalid value: nonsequential values.");
                    }

                }
            }
        }

        public Game(Game gameObject)
        {
            MatrixValues = (int[,])gameObject.MatrixValues.Clone();
            MatrixIndexArray = (Index[])gameObject.MatrixIndexArray.Clone();          
        }

        public virtual int this[int x, int y]
        {
            get
            {
                if (x >= MatrixSize || y >= MatrixSize)
                    throw new ArgumentException("Incorrectly sets the index");
                else
                    return MatrixValues[x, y];
            }
            private set { ; }
        }

        public virtual Index GetLocation(int requiredValue)
        {
            if (requiredValue >= 0 && requiredValue >= MatrixIndexArray.Length)
                throw new ArgumentException("Invalid value of tile position: it is outside of field.");

            return MatrixIndexArray[requiredValue];
        }

        public virtual IGame Shift(int requiredValue)
        {
            var currentIndex = MatrixIndexArray[requiredValue];
            var zeroIndex = MatrixIndexArray[0];

            if ( (Math.Abs(currentIndex.x - zeroIndex.x) + Math.Abs(currentIndex.y - zeroIndex.y) ) != 1)
                throw new ArgumentException("Zero value must be nearby.");

            MatrixValues[currentIndex.x, currentIndex.y] = 0;
            MatrixValues[zeroIndex.x, zeroIndex.y] = requiredValue;

            MatrixIndexArray[requiredValue].x = zeroIndex.x;
            MatrixIndexArray[requiredValue].y = zeroIndex.y;
            MatrixIndexArray[0].x = currentIndex.x;
            MatrixIndexArray[0].y = currentIndex.y;

            return this;
        }

        protected static void ValidateMatrixValues(params int[] matrixValuesArray)
        {
            var lenghtMatrixValuesArray = matrixValuesArray.Length;

            if (matrixValuesArray.Distinct().Count() != matrixValuesArray.Length)
            {
                throw new ArgumentException("Invalid values: it isn't unique.");
            }

            if (Math.Sqrt(lenghtMatrixValuesArray) % 1 != 0)
            {
                throw new ArgumentException("Ivalid number of values: it must be square.");
            }

            if (lenghtMatrixValuesArray == 0)
            {
                throw new ArgumentException("Invalid number of values: it's zero.");
            }

            if (matrixValuesArray.Any(number => number < 0) )
            {
                throw new ArgumentException("Invalid value: it can't be negative.");
            }

            if (matrixValuesArray.SingleOrDefault(x => x == 0) > 1)
            {
                throw new ArgumentException("Invalid values: must be the one zero value.");
            }
        }
    }
}
