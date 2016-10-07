using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2FifteenPuzzle;

namespace GameTest
{
    [TestClass]
    public class GameTests
    {
        protected virtual Game CreateGameObjectForTest(params int[] valuesArray)
        {
            return new Game(valuesArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_InvalidMatrixSize_ThrowArgumentException()
        {
            CreateGameObjectForTest(0, 1, 2, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_NonsequentialValues_ArgumentException()
        {
            CreateGameObjectForTest(9, 14, 3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Shift_ZeroValueIsNotNearby_ArgumentException()
        {
            // Arrange:
            Game gameObject = CreateGameObjectForTest(1, 2, 3, 0, 4);

            // Act:
            int invalidValue = 1;
            gameObject.Shift(invalidValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetLocation_IvalidValue_OutsideOfMatrix()
        {
            Game gameObject = CreateGameObjectForTest(1, 2, 0, 3);
            int invalidValue = 10;
            gameObject.GetLocation(invalidValue);
        }

        [TestMethod]
        public void Indexer_CorrectIndex_ValueIsFound()
        {
            // Arrange:
            Game gameObject = CreateGameObjectForTest(0, 1, 2, 3, 4, 5, 6, 7, 8);

            // Act:
            int requiredValue = 5;
            int xIndex = 1;
            int yIndex = 2;

            // Assert:
            Assert.AreEqual(gameObject[xIndex, yIndex], requiredValue);
        }

        [TestMethod]
        public void Game_CorrectValues_GameObjectIsNotNull()
        {
            Game gameObject = CreateGameObjectForTest(0, 1, 2, 3, 4, 5, 6, 7, 8);
            Assert.IsNotNull(gameObject);
        }

        [TestMethod]
        public void GetLocation_CorrectValue_ReturnRightLocation()
        {
            // Arrange:
            Game gameObject = CreateGameObjectForTest(0, 1, 2, 3);

            // Act:
            int requiredValue = 1;
            var indexForTest = new Index { };

            indexForTest = gameObject.GetLocation(requiredValue);
            var requiredIndex = new Index { x = 0, y = 1 };

            // Assert:
            Assert.IsTrue(indexForTest.x == requiredIndex.x && indexForTest.y == requiredIndex.y);
        }
        [TestMethod]
        public void Shift_ZeroValueIsNearby_ValuesShifts()
        {
            // Arrange:
            Game gameObject = CreateGameObjectForTest(3, 0, 2, 1);
            int requiredValue = 3;
            gameObject.Shift(requiredValue);

            // Act:
            var currentIndex = new Index { x = 0, y = 0 };
            var zeroIndex = new Index { x = 0, y = 1 };

            var currentIndexAfterShift = new Index { };
            var zeroIndexAfterShift = new Index { };

            currentIndexAfterShift = gameObject.GetLocation(requiredValue);
            zeroIndexAfterShift = gameObject.GetLocation(0);

            // Assert:
            Assert.IsTrue(zeroIndex.x == currentIndexAfterShift.x && currentIndex.y == zeroIndexAfterShift.y);
            Assert.IsTrue(currentIndex.x == zeroIndexAfterShift.x && zeroIndex.y == currentIndexAfterShift.y);
        }
    }
}
